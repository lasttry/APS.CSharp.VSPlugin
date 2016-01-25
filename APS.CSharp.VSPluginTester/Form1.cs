using APS.CSharp.VSPlugin;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APS.CSharp.VSPluginTester
{



    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bttGenerate_Click(object sender, EventArgs e)
        {
            Schema s = new Schema();

            s.ApsVersion = "2.0";
            s.Name = "Addon";
            s.Id = "http://www.parallels.com/Office365/Addon/1.0";
            s.Implements = new string[] { "http://aps-standard.org/types/core/resource/1.0" };
            s.Access = new Access();
            s.Access.Admin = true;

            s.Properties = new Dictionary<string, VSPlugin.Property>();
            s.Properties.Add("adminName", new VSPlugin.Property()
            {
                Type = "string",
                Description = "description",
                Required = false,
                Readonly = true,
                Final = true,
                Encrypted = true,
                Unit = "gb",
                Default = "string",
                Format = "date-time",
                Pattern = "^[a-zA-Z][0-9a-zA-Z_\\-]*",
                Title = "title",
                Headline = true,
                MinLength = 3,
                MaxLength = 20,
                MinItems = 2,
                MaxItems = 30,
                UniqueItems = true,
                EnumValues = new List<string>(),
                EnumTitles = new List<string>(),
                Access = new Access()
            });
            s.Properties["adminName"].EnumTitles.Add("enumtitle1");
            s.Properties["adminName"].EnumTitles.Add("enumtitle2");
            s.Properties["adminName"].EnumValues.Add("enumvalue1");
            s.Properties["adminName"].EnumValues.Add("enumvalue2");
            s.Properties["adminName"].Access.Admin = true;

            s.Properties.Add("simpleString", new VSPlugin.Property()
            {
                Type = "string",
                Required = true
            });
            s.Properties.Add("admin_password", new VSPlugin.Property()
            {
                Type = "string",
                Encrypted = true,
                Required = true
            });

            s.Properties.Add("array", new VSPlugin.Property()
            {
                Type = "array",
                Items = new ArraySchema()
                {
                    Type = "string"
                },
                Encrypted = true,
                Required = true
            });

            s.Operations = new Dictionary<string, Operation>();
            s.Operations.Add("verify", new Operation()
            {
                Verb = "POST",
                Path = "/verify",
                Static = false,
                Access = new Access(),
                Parameters = new Dictionary<string, Parameters>(),
                ErrorResponse = new ErrorResponse(),
            });
            s.Operations["verify"].Access.Admin = true;
            s.Operations["verify"].Parameters.Add("arguments", new Parameters() {
                Kind = "body",
                Type = "object",
                Required = false
            });
            s.Operations["verify"].ErrorResponse.Type = "object";
            s.Operations["verify"].ErrorResponse.Properties = new ErrorProperty();
            s.Operations["verify"].ErrorResponse.Properties.Code = "long";
            s.Operations["verify"].ErrorResponse.Properties.Message = "string";

            s.Structures = new Dictionary<string, Structure>();
            s.Structures.Add("Person", new Structure()
            {
                Type = "object",
                Properties = new Dictionary<string, StructureProperty>()
            });
            s.Structures["Person"].Properties.Add("firstName", new StructureProperty()
            {
                Type = "string",
                Required = true
            });
            s.Structures["Person"].Properties.Add("lastName", new StructureProperty()
            {
                Type = "string",
            });
            s.Structures["Person"].Properties.Add("books", new StructureProperty()
            {
                Type = "array",
                Items = new ArraySchema()
                {
                    Type = "string"
                }
            });
            s.Relations = new Dictionary<string, Relation>();
            s.Relations.Add("offers", new Relation()
            {
                Type = "http://examples.apsdemo.org/vpscloud/offers/1.0",
                Collection = true,
                Requirement = "requiremente"
            });

            s.Relations.Add("contexts", new Relation()
            {
                Type = "http://examples.apsdemo.org/vpscloud/contexts/1.0",
                Collection = true,
                Required = true
            });

            APSSchemaGenerator a = new APSSchemaGenerator();
            txtGenerated.Text = a.ConvertClass(s);

            Generator g = new Generator();

        }

        private void Form1_Info(object sender, string message)
        {
            textBox1.Text += message + "\r\n";
        }
    }
}
