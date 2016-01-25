using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace APS.CSharp.VSPlugin
{
    [Guid("76859D60-C594-4862-B057-8C808F21D837")]
    public class APSSchemaGenerator : IVsSingleFileGenerator
    {
        private IServiceProvider serviceProvider;
        private object site;

        public int DefaultExtension(out string InputfileRqExtension)
        {
            InputfileRqExtension = ".gen.schema";  // the extension must include the leading period
            return VSConstants.S_OK; // signal successful completion
        }

        public static DTE GetDTE()
        {
            return (DTE)Package.GetGlobalService(typeof(DTE));
        }

        public int Generate(string wszInputFilePath, string bstrInputFileContents, string wszDefaultNamespace,
          IntPtr[] rgbOutputFileContents, out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            pcbOutput = 0;
            try
            {
                DTE dte = GetDTE();

                var activeItem = dte.ActiveDocument.Name;

                ProjectItem projectItem = dte.Solution.FindProjectItem(wszInputFilePath);


                var solution = dte.Solution;
                
                var solutionProjects = dte.ActiveSolutionProjects as Array;
                if (solutionProjects == null || solutionProjects.Length == 0)
                    return VSConstants.S_FALSE;
                var activeProject = solutionProjects.GetValue(0) as Project;


                Generator g = new Generator();
                string result = "";

                var data = Encoding.Default.GetBytes(result);
                var ptr = Marshal.AllocCoTaskMem(data.Length);
                Marshal.Copy(data, 0, ptr, data.Length);

                pcbOutput = (uint)data.Length;
                rgbOutputFileContents[0] = ptr; 

                
            }
            catch (Exception e)
            {
                throw new COMException(string.Format("{0}: {1}\n{2}",
                e.GetType().Name, e.Message, e.StackTrace));
            }

            return VSConstants.S_OK;  // force an error message
        }

        public string ConvertClass(object input)
        {
            return JsonConvert.SerializeObject(input, Formatting.Indented);
        }
    }
}
