using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class SpeedranResponseWrapper<T>
    {
        public T data { get; set; }
        public Pagination pagination { get; set; }
    }
    public class Pagination
    {
        public int offset { get; set; }
        public int max { get; set; }
        public int size { get; set; }
        public Link[] links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

}
