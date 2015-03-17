using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webtool
{
    public partial class CompressorForm : Form
    {
        public CompressorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string projectDirectory = this.projectDirectory.Text;
            if (!string.IsNullOrEmpty(projectDirectory.Trim()))
            {
                Compressor.Compress(projectDirectory, string.Empty);
            }
        }
    }
}
