namespace APS.CSharp.VSPluginTester
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtGenerated = new System.Windows.Forms.TextBox();
            this.bttGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(452, 594);
            this.textBox1.TabIndex = 0;
            // 
            // txtGenerated
            // 
            this.txtGenerated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtGenerated.Location = new System.Drawing.Point(470, 12);
            this.txtGenerated.Multiline = true;
            this.txtGenerated.Name = "txtGenerated";
            this.txtGenerated.Size = new System.Drawing.Size(452, 594);
            this.txtGenerated.TabIndex = 1;
            // 
            // bttGenerate
            // 
            this.bttGenerate.Location = new System.Drawing.Point(928, 570);
            this.bttGenerate.Name = "bttGenerate";
            this.bttGenerate.Size = new System.Drawing.Size(113, 36);
            this.bttGenerate.TabIndex = 2;
            this.bttGenerate.Text = "Generate";
            this.bttGenerate.UseVisualStyleBackColor = true;
            this.bttGenerate.Click += new System.EventHandler(this.bttGenerate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 618);
            this.Controls.Add(this.bttGenerate);
            this.Controls.Add(this.txtGenerated);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtGenerated;
        private System.Windows.Forms.Button bttGenerate;
    }
}

