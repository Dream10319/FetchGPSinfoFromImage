using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fetchgeoinfo
{
    public class GPSInfo
    {
        public string version {  get; set; }
        public string latref { get; set; }
        public string lonref { get; set; }
        public string lat {  get; set; }
        public string lon { get; set; }
        public string altref { get; set; }
        public string alt { get; set; }
    }
}
