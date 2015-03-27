using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webtool
{
    public partial class RootForm : Form
    {
        WebtoolModel model = WebtoolService.Get();
        public RootForm()
        {
            InitializeComponent();
        }

        private void RootForm_Load(object sender, EventArgs e)
        {
            this.ComboxProject.DataSource = model.projects;
            this.ComboxProject.DisplayMember = "name";
            this.ComboxProject.ValueMember = "name";
        }

        private void BtnBuild_Click(object sender, EventArgs e)
        {
            try
            {
                Project project = model.projects[this.ComboxProject.SelectedIndex];

                // step1
                DirectoryInfo projectDirectoryInfo = new DirectoryInfo(project.projectDirectory);
                DirectoryInfo outputDirectoryInfo = DirectoryTool.CreateDirectory(project.output);
                DirectoryTool.ClearDirectory(outputDirectoryInfo);

                tip.Text = "build razor...";
                RazorTool.Build(projectDirectoryInfo, outputDirectoryInfo, project.ignoreDirectory);

                // step2
                if (project.isCompress)
                {
                    tip.Text = "compress...";
                    CompressionTool.Compress(outputDirectoryInfo, project.structure);
                }

                // step3
                if (project.isCommitSvn)
                {
                    tip.Text = "commit to svn...";
                    VersionControlSystemTool.CommitSvn();
                }

                tip.Text = "build success";
            }
            catch
            {
            }
        }

        private void ComboxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            Project project = model.projects[this.ComboxProject.SelectedIndex];
            SetProjectValue(project);
        }

        private void SetProjectValue(Project project)
        {
            this.TxtProjectDirectory.Text = project.projectDirectory;
            this.TxtUrl.Text = project.url;
            this.TxtOutput.Text = project.output;
            this.CheckboxCompress.Checked = project.isCompress;
            this.CheckboxCommitSvn.Checked = project.isCommitSvn;
        }
    }
}
