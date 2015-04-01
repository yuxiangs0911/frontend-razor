using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webtool
{
    public class WebtoolService
    {
        public static WebtoolModel Get()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\webtool.json";
            string json = File.ReadAllText(path).Replace(@"\", @"\\");
            WebtoolModel model = JsonConvert.DeserializeObject<WebtoolModel>(json);
            return model;
        }
    }
}
