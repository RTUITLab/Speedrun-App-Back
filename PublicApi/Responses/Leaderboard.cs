using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicApi.Responses
{
    public class Leaderboard
    {
        public string weblink { get; set; }
        public string game { get; set; }
        public string category { get; set; }
        public object level { get; set; }
        public object platform { get; set; }
        public object region { get; set; }
        public object emulators { get; set; }
        public bool videoonly { get; set; }
        public string timing { get; set; }
        public Values values { get; set; }
        public Run[] runs { get; set; }
        public Link1[] links { get; set; }
    }

    public class Values
    {
    }

    public class Run
    {
        public int place { get; set; }
        public Run1 run { get; set; }
    }

    public class Run1
    {
        public string id { get; set; }
        public string weblink { get; set; }
        public string game { get; set; }
        public object level { get; set; }
        public string category { get; set; }
        public Videos videos { get; set; }
        public string comment { get; set; }
        public Status status { get; set; }
        public Player[] players { get; set; }
        public string date { get; set; }
        public DateTime submitted { get; set; }
        public Times times { get; set; }
        public System system { get; set; }
        public Splits splits { get; set; }
        public Values1 values { get; set; }
    }

    public class Videos
    {
        public VideosLink[] links { get; set; }
        public string text { get; set; }
    }

    public class VideosLink
    {
        public string uri { get; set; }
    }

    public class Status
    {
        public string status { get; set; }
        public string examiner { get; set; }
        public DateTime? verifydate { get; set; }
    }

    public class Times
    {
        public string primary { get; set; }
        public float primary_t { get; set; }
        public string realtime { get; set; }
        public float realtime_t { get; set; }
        public object realtime_noloads { get; set; }
        public int realtime_noloads_t { get; set; }
        public string ingame { get; set; }
        public float ingame_t { get; set; }
    }

    public class System
    {
        public string platform { get; set; }
        public bool emulated { get; set; }
        public object region { get; set; }
    }

    public class Splits
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

    public class Values1
    {
        public string jlzkwql2 { get; set; }
        public string _9l737pn1 { get; set; }
        public string r8rg67rn { get; set; }
        public string wl33kewl { get; set; }
        public string dloymqd8 { get; set; }
        public string ql6g2ow8 { get; set; }
    }

    public class Player
    {
        public string rel { get; set; }
        public string name { get; set; }
        public string uri { get; set; }
        public string id { get; set; }
    }

    public class Link1
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

}
