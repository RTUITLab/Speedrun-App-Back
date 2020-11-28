using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicApi.Responses
{
    public class Game
    {
        public string id { get; set; }
        public Names names { get; set; }
        public string abbreviation { get; set; }
        public string weblink { get; set; }
        public int released { get; set; }
        public string releasedate { get; set; }
        public Ruleset ruleset { get; set; }
        public bool romhack { get; set; }
        public object[] gametypes { get; set; }
        public string[] platforms { get; set; }
        public object[] regions { get; set; }
        public object[] genres { get; set; }
        public string[] engines { get; set; }
        public string[] developers { get; set; }
        public object[] publishers { get; set; }
        public Dictionary<string, string> moderators { get; set; }
        public DateTime? created { get; set; }
        public Assets assets { get; set; }
        public RegionLink[] links { get; set; }
    }

    public class Names
    {
        public string international { get; set; }
        public object japanese { get; set; }
        public string twitch { get; set; }
    }

    public class Ruleset
    {
        public bool showmilliseconds { get; set; }
        public bool requireverification { get; set; }
        public bool requirevideo { get; set; }
        public string[] runtimes { get; set; }
        public string defaulttime { get; set; }
        public bool emulatorsallowed { get; set; }
    }

    public class Assets
    {
        public Logo logo { get; set; }
        public CoverTiny covertiny { get; set; }
        public CoverSmall coversmall { get; set; }
        public CoverMedium covermedium { get; set; }
        public CoverLarge coverlarge { get; set; }
        public Icon icon { get; set; }
        public Trophy1St trophy1st { get; set; }
        public Trophy2Nd trophy2nd { get; set; }
        public Trophy3Rd trophy3rd { get; set; }
        public object trophy4th { get; set; }
        public Background background { get; set; }
        public Foreground foreground { get; set; }
    }

    public class Logo
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class CoverTiny
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class CoverSmall
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class CoverMedium
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class CoverLarge
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Icon
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Trophy1St
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Trophy2Nd
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Trophy3Rd
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Background
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Foreground
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
