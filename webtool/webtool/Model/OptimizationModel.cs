using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webtool
{
    public class OptimizationModel
    {
        public string appDir { get; set; }
        public string baseUrl { get; set; }
        public string dir { get; set; }
        public string mainConfigFile { get; set; }
        public string optimizeCss { get; set; }
        public bool removeCombined { get; set; }
        public List<OptimizationModuleModel> modules { get; set; }
    }

    public class OptimizationModuleModel
    {
        public string Name { get; set; }
        public List<string> include { get; set; }
    }
}
