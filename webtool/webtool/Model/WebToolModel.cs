using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webtool
{
    public class WebtoolModel
    {
        public string name { get; set; }
        public string version { get; set; }
        public List<Project> projects;
    }

    public class Project
    {
        public string name { get; set; }
        public string projectDirectory { get; set; }
        public string url { get; set; }
        public string output { get; set; }
        public bool compress { get; set; }
        public bool commitSvn { get; set; }
        public bool syncSvn { get; set; }
        public Structure structure { get; set; }
        public string ignoreDirectory { get; set; }
    }

    public class Structure
    {
        public string view { get; set; }
        public string script { get; set; }
        public string css { get; set; }
        public string image { get; set; }
    }
}
