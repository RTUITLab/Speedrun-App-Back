using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicApi.Responses
{

    public class PlatformsData
    {
        public PlatformsDataDatum[] data { get; set; }
    }

    public class PlatformsDataDatum
    {
        public string id { get; set; }
        public string name { get; set; }
        public int released { get; set; }
    }

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
        public Link2[] links { get; set; }
        public Players1 players { get; set; }
        public PlatformsData platforms { get; set; }
    }

    public class Values
    {
    }

    public class Players1
    {
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public string rel { get; set; }
        public string name { get; set; }
        public Link[] links { get; set; }
        public string id { get; set; }
        public Names names { get; set; }
        public string weblink { get; set; }
        public string role { get; set; }
        public DateTime signup { get; set; }
        public Location location { get; set; }
        public Twitch twitch { get; set; }
        public object hitbox { get; set; }
        public Youtube youtube { get; set; }
        public Twitter twitter { get; set; }
        public Speedrunslive speedrunslive { get; set; }
    }

    public class Names1
    {
        public string international { get; set; }
        public object japanese { get; set; }
    }

    public class Names1tyle
    {
        public string style { get; set; }
        public ColorFrom colorfrom { get; set; }
        public ColorTo colorto { get; set; }
        public Color color { get; set; }
    }

    public class ColorFrom
    {
        public string light { get; set; }
        public string dark { get; set; }
    }

    public class ColorTo
    {
        public string light { get; set; }
        public string dark { get; set; }
    }

    public class Color
    {
        public string light { get; set; }
        public string dark { get; set; }
    }

    public class Location
    {
        public Country country { get; set; }
        public Region2 region { get; set; }
    }

    public class Country
    {
        public string code { get; set; }
        public Names1 names { get; set; }
    }

    public class Region2
    {
        public string code { get; set; }
        public Names2 names { get; set; }
    }

    public class Names2
    {
        public string international { get; set; }
        public object japanese { get; set; }
    }

    public class Twitch
    {
        public string uri { get; set; }
    }

    public class Youtube
    {
        public string uri { get; set; }
    }

    public class Twitter
    {
        public string uri { get; set; }
    }

    public class Speedrunslive
    {
        public string uri { get; set; }
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
        public Times times { get; set; }
        public System system { get; set; }
        public Splits splits { get; set; }
        public Values1 values { get; set; }
    }

    public class Videos
    {
        public Link1[] links { get; set; }
        public string text { get; set; }
    }

    public class Link1
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

    public class Link2
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }


}
