using APS.CSharp.SDK.Attributes;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APS.CSharp.VSPlugin
{

    public delegate void InfoEventHandler(object sender, string message);

    public class Generator
    {

        public void WriteProperties(object o, StringBuilder sb)
        {
            sb.AppendLine("Properties from: " + o.GetType().Name);
            foreach (PropertyInfo pi in o.GetType().GetProperties())
                sb.AppendLine(pi.Name + ": " + pi.GetValue(o));
        }

        public string Generate(Type resource)
        {
            Schema schema = new Schema();

            ResourceBaseAttribute resourceAttr = resource.GetCustomAttribute<ResourceBaseAttribute>();
            if (resourceAttr == null)
                return null;

            // Setting the schema master attributes
            schema.Name = resource.Name;
            schema.ApsVersion = resourceAttr.ApsVersion;
            schema.Implements = resourceAttr.Implements;
            schema.Id = resourceAttr.Id;

            List<PropertyInfo> properties = new List<PropertyInfo>();
            List<PropertyInfo> links = new List<PropertyInfo>();
            List<PropertyInfo> structures = new List<PropertyInfo>();

            
            schema.Properties = new Dictionary<string, Property>();
            foreach (PropertyInfo property in resource.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.GetCustomAttribute<SDK.Attributes.RelationAttribute>() != null)
                    schema.Relations.Add(property.Name, Relation.CreateRelationObject(property));
            }
            schema.Operations = new Dictionary<string, Operation>();
            foreach(MemberInfo method in resource.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
            {
                if (method.GetCustomAttribute<OperationAttribute>() != null)
                    schema.Operations.Add(method.Name, Operation.CreateOperationObject(method));
            }
            

            return JsonConvert.SerializeObject(schema, Formatting.Indented);
        }

        IEnumerable GetDefinedTypes(ProjectItem projectItem)
        {
            // Get all child project items of the folder …
            return from ns in projectItem.FileCodeModel.CodeElements.OfType<CodeNamespace>()
                       // Get all types defined in the namespace elements …
                   from type in ns.Members.OfType<CodeType>()
                       // that are classes
                   where type.Kind == vsCMElement.vsCMElementClass
                   select type;
        }
    }
}
