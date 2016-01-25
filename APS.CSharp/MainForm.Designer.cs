namespace APS.CSharp
{
    partial class frmAPSCSharp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtWorkingFolder = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fbdBinFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.lblInfos = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lvLibraries = new System.Windows.Forms.ListView();
            this.lvClasses = new System.Windows.Forms.ListView();
            this.chAssembly = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClasses = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsbDetails = new System.Windows.Forms.ListBox();
            this.txtSchema = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtWorkingFolder
            // 
            this.txtWorkingFolder.Location = new System.Drawing.Point(12, 49);
            this.txtWorkingFolder.Name = "txtWorkingFolder";
            this.txtWorkingFolder.Size = new System.Drawing.Size(406, 20);
            this.txtWorkingFolder.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblInfos
            // 
            this.lblInfos.AutoSize = true;
            this.lblInfos.Location = new System.Drawing.Point(12, 9);
            this.lblInfos.Name = "lblInfos";
            this.lblInfos.Size = new System.Drawing.Size(406, 13);
            this.lblInfos.TabIndex = 1;
            this.lblInfos.Text = "In order to create the schemas of your APS you first need to select the working f" +
    "older";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Working Folder";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(426, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 19);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lvLibraries
            // 
            this.lvLibraries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAssembly});
            this.lvLibraries.Location = new System.Drawing.Point(12, 75);
            this.lvLibraries.Name = "lvLibraries";
            this.lvLibraries.Size = new System.Drawing.Size(238, 218);
            this.lvLibraries.TabIndex = 4;
            this.lvLibraries.UseCompatibleStateImageBehavior = false;
            this.lvLibraries.View = System.Windows.Forms.View.Details;
            this.lvLibraries.SelectedIndexChanged += new System.EventHandler(this.lvLibraries_SelectedIndexChanged);
            // 
            // lvClasses
            // 
            this.lvClasses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chClasses});
            this.lvClasses.Location = new System.Drawing.Point(256, 75);
            this.lvClasses.Name = "lvClasses";
            this.lvClasses.Size = new System.Drawing.Size(238, 218);
            this.lvClasses.TabIndex = 5;
            this.lvClasses.UseCompatibleStateImageBehavior = false;
            this.lvClasses.View = System.Windows.Forms.View.Details;
            this.lvClasses.SelectedIndexChanged += new System.EventHandler(this.lvClasses_SelectedIndexChanged);
            // 
            // chAssembly
            // 
            this.chAssembly.Text = "Assemblies";
            this.chAssembly.Width = 230;
            // 
            // chClasses
            // 
            this.chClasses.Text = "Classes";
            this.chClasses.Width = 230;
            // 
            // lsbDetails
            // 
            this.lsbDetails.FormattingEnabled = true;
            this.lsbDetails.Location = new System.Drawing.Point(500, 75);
            this.lsbDetails.Name = "lsbDetails";
            this.lsbDetails.Size = new System.Drawing.Size(340, 381);
            this.lsbDetails.TabIndex = 6;
            // 
            // txtSchema
            // 
            this.txtSchema.Location = new System.Drawing.Point(846, 12);
            this.txtSchema.Multiline = true;
            this.txtSchema.Name = "txtSchema";
            this.txtSchema.Size = new System.Drawing.Size(502, 532);
            this.txtSchema.TabIndex = 7;
            // 
            // frmAPSCSharp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 556);
            this.Controls.Add(this.txtSchema);
            this.Controls.Add(this.lsbDetails);
            this.Controls.Add(this.lvClasses);
            this.Controls.Add(this.lvLibraries);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInfos);
            this.Controls.Add(this.txtWorkingFolder);
            this.Name = "frmAPSCSharp";
            this.Text = "APS.CSharp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWorkingFolder;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog fbdBinFolder;
        private System.Windows.Forms.Label lblInfos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lvLibraries;
        private System.Windows.Forms.ListView lvClasses;
        private System.Windows.Forms.ColumnHeader chAssembly;
        private System.Windows.Forms.ColumnHeader chClasses;
        private System.Windows.Forms.ListBox lsbDetails;
        private System.Windows.Forms.TextBox txtSchema;
    }
}

