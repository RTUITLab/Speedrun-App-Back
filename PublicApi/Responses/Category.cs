using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicApi.Responses
{

    public class Category
    {
        public string id { get; set; }
        public string name { get; set; }
        public string weblink { get; set; }
        public string type { get; set; }
        public string rules { get; set; }
        public Players players { get; set; }
        public bool miscellaneous { get; set; }
        public CategoryLink[] links { get; set; }
    }

    public class Players
    {
        public string type { get; set; }
        public int value { get; set; }
    }

    public class CategoryLink
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

}
