using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicApi.Responses
{

    public class Platform
    {
        public string id { get; set; }
        public string name { get; set; }
        public int released { get; set; }
        public Link[] links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

}
