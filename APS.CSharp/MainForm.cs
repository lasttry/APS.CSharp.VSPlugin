using APS.CSharp.SDK.Attributes;
using APS.CSharp.VSPlugin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APS.CSharp
{
    public partial class frmAPSCSharp : Form
    {

        private Assembly currentAssembly;

        public frmAPSCSharp()
        {
            InitializeComponent();
            this.txtWorkingFolder.Text = string.IsNullOrEmpty(Properties.Settings.Default.CurrentFolder) ? System.IO.Directory.GetCurrentDirectory() : Properties.Settings.Default.CurrentFolder;
            this.fbdBinFolder.SelectedPath = this.txtWorkingFolder.Text;
            FillLibraries();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = fbdBinFolder.ShowDialog(this);
            if(dr == DialogResult.OK)
            {
                this.txtWorkingFolder.Text = fbdBinFolder.SelectedPath;
                Properties.Settings.Default.CurrentFolder = fbdBinFolder.SelectedPath;
                Properties.Settings.Default.Save();
                FillLibraries();
            }
        }

        private void FillLibraries()
        {
            this.lvLibraries.Items.Clear();
            currentAssembly = null;
            
            foreach (string file in Directory.GetFiles(this.txtWorkingFolder.Text, "*.dll"))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = Path.GetFileName(file);
                lvi.Name = file;
                this.lvLibraries.Items.Add(lvi);
            }
        }

        private void lvLibraries_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentAssembly = null;
            lvClasses.Items.Clear();

            if (lvLibraries.SelectedItems.Count == 0)
                return;

            currentAssembly = Assembly.LoadFrom(Path.Combine(this.txtWorkingFolder.Text, lvLibraries.SelectedItems[0].Text));
            foreach (Type t in currentAssembly.GetTypes())
                if(t.GetCustomAttributes<ResourceBaseAttribute>().Count() > 0)
                this.lvClasses.Items.Add(new ListViewItem(t.FullName));
        }

        private void lvClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lsbDetails.Items.Clear();

            if (currentAssembly == null)
                return;

            if (lvClasses.SelectedItems.Count == 0)
                return;

            Type type = currentAssembly.GetType(lvClasses.SelectedItems[0].Text);

            Generator g = new Generator();
            txtSchema.Text = g.Generate(type);



            ResourceBaseAttribute resourceAttr = type.GetCustomAttribute<SDK.Attributes.ResourceBaseAttribute>();

            resourceAttr = type.GetCustomAttribute(typeof(ResourceBaseAttribute), false) as ResourceBaseAttribute;
            if (resourceAttr == null)
                return;



            this.lsbDetails.Items.Add("apsVersion: " + resourceAttr.ApsVersion);
            this.lsbDetails.Items.Add("id: " + resourceAttr.Id);
            if(resourceAttr.Implements != null)
                this.lsbDetails.Items.Add("implements: " + String.Join(",", resourceAttr.Implements));

            List<PropertyInfo> p = new List<PropertyInfo>();
            List<PropertyInfo> l = new List<PropertyInfo>();
            List<PropertyInfo> s = new List<PropertyInfo>();

            foreach(PropertyInfo property in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.GetCustomAttribute<SDK.Attributes.LinkAttribute>() != null)
                    l.Add(property);
                else if (property.GetCustomAttribute<SDK.Attributes.StructureAttribute>() != null)
                    s.Add(property);
                else
                    p.Add(property);
            }
            FillListItems(p, ">P>");
            FillListItems(l, ">L>");
            FillListItems(s, ">S>");
        }

        private void FillListItems(List<PropertyInfo> properties, string prefix)
        {
            foreach (PropertyInfo property in properties)
                this.lsbDetails.Items.Add(prefix + property.Name);
        }
    }
}
