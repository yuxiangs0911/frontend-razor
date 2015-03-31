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
                Project project = GetProject();

                // step1 create directory
                DirectoryInfo projectDirectoryInfo = new DirectoryInfo(project.projectDirectory);
                DirectoryInfo outputDirectoryInfo = DirectoryTool.CreateDirectory(project.output);
                DirectoryTool.ClearDirectory(outputDirectoryInfo);

                // step2 sync svn  
                if (project.syncSvn)
                {
                    tip.Text = "sync svn...";
                    VersionControlSystemTool.UpdateSvn(projectDirectoryInfo.FullName);
                }

                // step2 build razor
                tip.Text = "build razor...";
                RazorTool.Build(projectDirectoryInfo, outputDirectoryInfo, project.ignoreDirectory, project.url);

                // step3 compress 
                if (project.compress)
                {
                    tip.Text = "compress...";
                    CompressionTool.Compress(outputDirectoryInfo, project.structure);
                }

                // step4 commit
                if (project.commitSvn)
                {
                    tip.Text = "commit to svn...";
                    VersionControlSystemTool.CommitSvn(outputDirectoryInfo.FullName, "razor-build");
                }

                tip.Text = "build success";
                MessageBox.Show("build success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + ex.Message);
                tip.Text = "build exception";
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
            this.CheckboxCompress.Checked = project.compress;
            this.CheckboxCommitSvn.Checked = project.commitSvn;
            this.CheckboxSyncSvn.Checked = project.syncSvn;
        }

        private Project GetProject()
        {
            Project p = model.projects[this.ComboxProject.SelectedIndex];
            p.projectDirectory = TxtProjectDirectory.Text;
            p.url = TxtUrl.Text;
            p.output = TxtOutput.Text;
            p.compress = CheckboxCompress.Checked;
            p.commitSvn = CheckboxCommitSvn.Checked;
            p.syncSvn = CheckboxSyncSvn.Checked;
            return p;
        }
    }
}
