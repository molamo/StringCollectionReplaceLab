using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCollectionReplace
{
    public class Root
    {
        public List<ReplaceSetting> ReplaceSettings { get; set; }
    }

    public class ReplaceSetting
    {
        public string find { get; set; }
        public string replace { get; set; }
    }
   
}
