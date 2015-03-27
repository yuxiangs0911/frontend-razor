namespace webtool
{
    partial class RootForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtProjectDirectory = new System.Windows.Forms.TextBox();
            this.ComboxProject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtOutput = new System.Windows.Forms.TextBox();
            this.CheckboxCompress = new System.Windows.Forms.CheckBox();
            this.BtnBuild = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.CheckboxCommitSvn = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tip = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "project directory";
            // 
            // TxtProjectDirectory
            // 
            this.TxtProjectDirectory.Location = new System.Drawing.Point(164, 94);
            this.TxtProjectDirectory.Name = "TxtProjectDirectory";
            this.TxtProjectDirectory.Size = new System.Drawing.Size(308, 21);
            this.TxtProjectDirectory.TabIndex = 2;
            // 
            // ComboxProject
            // 
            this.ComboxProject.FormattingEnabled = true;
            this.ComboxProject.Location = new System.Drawing.Point(164, 43);
            this.ComboxProject.Name = "ComboxProject";
            this.ComboxProject.Size = new System.Drawing.Size(121, 20);
            this.ComboxProject.TabIndex = 1;
            this.ComboxProject.SelectedIndexChanged += new System.EventHandler(this.ComboxProject_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "project";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "output";
            // 
            // TxtOutput
            // 
            this.TxtOutput.Location = new System.Drawing.Point(164, 181);
            this.TxtOutput.Name = "TxtOutput";
            this.TxtOutput.Size = new System.Drawing.Size(308, 21);
            this.TxtOutput.TabIndex = 4;
            // 
            // CheckboxCompress
            // 
            this.CheckboxCompress.AutoSize = true;
            this.CheckboxCompress.Location = new System.Drawing.Point(164, 230);
            this.CheckboxCompress.Name = "CheckboxCompress";
            this.CheckboxCompress.Size = new System.Drawing.Size(72, 16);
            this.CheckboxCompress.TabIndex = 5;
            this.CheckboxCompress.Text = "compress";
            this.CheckboxCompress.UseVisualStyleBackColor = true;
            // 
            // BtnBuild
            // 
            this.BtnBuild.Location = new System.Drawing.Point(164, 276);
            this.BtnBuild.Name = "BtnBuild";
            this.BtnBuild.Size = new System.Drawing.Size(121, 40);
            this.BtnBuild.TabIndex = 7;
            this.BtnBuild.Text = "build";
            this.BtnBuild.UseVisualStyleBackColor = true;
            this.BtnBuild.Click += new System.EventHandler(this.BtnBuild_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "url";
            // 
            // TxtUrl
            // 
            this.TxtUrl.Location = new System.Drawing.Point(164, 139);
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Size = new System.Drawing.Size(308, 21);
            this.TxtUrl.TabIndex = 3;
            // 
            // CheckboxCommitSvn
            // 
            this.CheckboxCommitSvn.AutoSize = true;
            this.CheckboxCommitSvn.Location = new System.Drawing.Point(257, 230);
            this.CheckboxCommitSvn.Name = "CheckboxCommitSvn";
            this.CheckboxCommitSvn.Size = new System.Drawing.Size(84, 16);
            this.CheckboxCommitSvn.TabIndex = 6;
            this.CheckboxCommitSvn.Text = "commit svn";
            this.CheckboxCommitSvn.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 334);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(546, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tip
            // 
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(36, 17);
            this.tip.Text = "ready";
            // 
            // RootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 356);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BtnBuild);
            this.Controls.Add(this.CheckboxCommitSvn);
            this.Controls.Add(this.CheckboxCompress);
            this.Controls.Add(this.ComboxProject);
            this.Controls.Add(this.TxtUrl);
            this.Controls.Add(this.TxtOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtProjectDirectory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RootForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "web tool";
            this.Load += new System.EventHandler(this.RootForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtProjectDirectory;
        private System.Windows.Forms.ComboBox ComboxProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtOutput;
        private System.Windows.Forms.CheckBox CheckboxCompress;
        private System.Windows.Forms.Button BtnBuild;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtUrl;
        private System.Windows.Forms.CheckBox CheckboxCommitSvn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tip;
    }
}