using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpeedrunAppBack.PublicApi.Responses.Run
{

    public class Link
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

    public class RunModel
    {
        public string id { get; set; }
        public string weblink { get; set; }
        public RunGame game { get; set; }
        public string level { get; set; }
        public string category { get; set; }
        public RunVideos videos { get; set; }
        public string comment { get; set; }
        public RunStatus status { get; set; }
        public RunPlayers players { get; set; }
        public string date { get; set; }
        public DateTime submitted { get; set; }
        public RunTimes times { get; set; }
        public RunSystem system { get; set; }
        public object splits { get; set; }
        public RunValues values { get; set; }
        public RunLink5[] links { get; set; }
        public RunPlatform platform { get; set; }
    }

    public class RunGame
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public RunNames names { get; set; }
        public string abbreviation { get; set; }
        public string weblink { get; set; }
        public int released { get; set; }
        public string releasedate { get; set; }
        public RunRuleset ruleset { get; set; }
        public bool romhack { get; set; }
        public string[] gametypes { get; set; }
        public string[] platforms { get; set; }
        public string[] regions { get; set; }
        public string[] genres { get; set; }
        public string[] engines { get; set; }
        public string[] developers { get; set; }
        public string[] publishers { get; set; }
        public Moderators moderators { get; set; }
        public DateTime? created { get; set; }
        public RunAssets assets { get; set; }
        public RunLink1[] links { get; set; }
    }
    public class RunAssets
    {
        public RunLogo logo { get; set; }
        [JsonPropertyName("cover-tiny")]
        public RunCoverTiny covertiny { get; set; }
        [JsonPropertyName("cover-small")]
        public RunCoverSmall coversmall { get; set; }
        [JsonPropertyName("cover-medium")]
        public RunCoverMedium covermedium { get; set; }
        [JsonPropertyName("cover-large")]
        public RunCoverLarge coverlarge { get; set; }
        public RunIcon icon { get; set; }
        [JsonPropertyName("trophy-1st")]
        public RunTrophy1St trophy1st { get; set; }
        [JsonPropertyName("trophy-2st")]
        public RunTrophy2Nd trophy2nd { get; set; }
        [JsonPropertyName("trophy-3st")]
        public RunTrophy3Rd trophy3rd { get; set; }
        [JsonPropertyName("trophy-4st")]
        public object trophy4th { get; set; }
        public RunBackground background { get; set; }
        public RunForeground foreground { get; set; }
    }
    public class RunNames
    {
        public string international { get; set; }
        public object japanese { get; set; }
        public string twitch { get; set; }
    }

    public class RunRuleset
    {
        public bool showmilliseconds { get; set; }
        public bool requireverification { get; set; }
        public bool requirevideo { get; set; }
        public string[] runtimes { get; set; }
        public string defaulttime { get; set; }
        public bool emulatorsallowed { get; set; }
    }

    public class Moderators
    {
        public string qjngyw8m { get; set; }
        public string _48gz7yjp { get; set; }
        public string qj29poxk { get; set; }
        public string _1xydnyxr { get; set; }
        public string _5j5d73n8 { get; set; }
        public string e8ek9yo8 { get; set; }
        public string _98rm663j { get; set; }
        public string e8ez0lp8 { get; set; }
        public string _5j56dwnx { get; set; }
        public string qxklwp68 { get; set; }
        public string j2y6v5o8 { get; set; }
        public string pj02o538 { get; set; }
        public string v813d3xp { get; set; }
        public string _98r5vpwx { get; set; }
        public string kjpeyg2x { get; set; }
        public string _48g92r2x { get; set; }
        public string v81yp7p8 { get; set; }
        public string e8e0kydj { get; set; }
        public string xz9nv648 { get; set; }
        public string _8rpemmdj { get; set; }
        public string x7q9g1v8 { get; set; }
        public string pj00k3jw { get; set; }
        public string _18qpz2qx { get; set; }
        public string _8dw7ywoj { get; set; }
        public string dx354ejl { get; set; }
        public string y8dwz5j6 { get; set; }
        public string pj0393jw { get; set; }
        public string qxkmpmj0 { get; set; }
        public string kjpkg0xq { get; set; }
        public string zx71erx7 { get; set; }
        public string v81o6wlx { get; set; }
        public string pj06z63j { get; set; }
        public string _48g34kyx { get; set; }
        public string _8rpnm0gj { get; set; }
        public string _1zxz4njq { get; set; }
        public string kjpowy8q { get; set; }
        public string _48ge6kyj { get; set; }
        public string zxz71lrj { get; set; }
        public string _48gzlzrj { get; set; }
        public string pj0679jw { get; set; }
        public string qj20vnnx { get; set; }
        public string y8dnz29j { get; set; }
        public string qxkdn6kj { get; set; }
        public string v8ln6ovx { get; set; }
        public string x7q4dgy8 { get; set; }
        public string kjpzq5kx { get; set; }
    }

    public class RunLogo
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RunCoverTiny
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RunCoverSmall
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RunCoverMedium
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RunCoverLarge
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RunIcon
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RunTrophy1St
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RunTrophy2Nd
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RunTrophy3Rd
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class Trophy4Th
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RunBackground
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RunForeground
    {
        public string uri { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

    public class RunLink1
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

    public class RunVideos
    {
        public RunLink2[] links { get; set; }
        public string text { get; set; }
    }

    public class RunLink2
    {
        public string uri { get; set; }
    }

    public class RunStatus
    {
        public string status { get; set; }
        public string examiner { get; set; }
        public string reason { get; set; }
        public DateTime verifydate { get; set; }
    }

    public class RunPlayers
    {
        public RunDatum1[] data { get; set; }
    }

    public class RunDatum1
    {
        public string rel { get; set; }
        public string id { get; set; }
        public RunNames1 names { get; set; }
        public string weblink { get; set; }
        public RunNameStyle namestyle { get; set; }
        public string role { get; set; }
        public DateTime signup { get; set; }
        public RunLocation location { get; set; }
        public RunTwitch twitch { get; set; }
        public object hitbox { get; set; }
        public RunYoutube youtube { get; set; }
        public RunTwitter twitter { get; set; }
        public RunRun speedrunslive { get; set; }
        public RunLink3[] links { get; set; }
    }

    public class RunNames1
    {
        public string international { get; set; }
        public object japanese { get; set; }
    }

    public class RunNameStyle
    {
        public string style { get; set; }
        public RunColorFrom colorfrom { get; set; }
        public RunColorTo colorto { get; set; }
        public RunColor color { get; set; }
    }

    public class RunColorFrom
    {
        public string light { get; set; }
        public string dark { get; set; }
    }

    public class RunColorTo
    {
        public string light { get; set; }
        public string dark { get; set; }
    }

    public class RunColor
    {
        public string light { get; set; }
        public string dark { get; set; }
    }

    public class RunLocation
    {
        public RunCountry country { get; set; }
        public RunRegion region { get; set; }
    }

    public class RunCountry
    {
        public string code { get; set; }
        public RunNames2 names { get; set; }
    }

    public class RunNames2
    {
        public string international { get; set; }
        public object japanese { get; set; }
    }

    public class RunRegion
    {
        public string code { get; set; }
        public RunNames3 names { get; set; }
    }

    public class RunNames3
    {
        public string international { get; set; }
        public object japanese { get; set; }
    }

    public class RunTwitch
    {
        public string uri { get; set; }
    }

    public class RunYoutube
    {
        public string uri { get; set; }
    }

    public class RunTwitter
    {
        public string uri { get; set; }
    }

    public class RunRun
    {
        public string uri { get; set; }
    }

    public class RunLink3
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

    public class RunTimes
    {
        public string primary { get; set; }
        public float primary_t { get; set; }
        public string prettyTime
        {
            get
            {
                var timeSpan = TimeSpan.FromSeconds(primary_t);
                return $"{(timeSpan.Hours > 0 ? $"{timeSpan.Hours}ч " : "")}{(timeSpan.Minutes > 0 ? $"{timeSpan.Minutes}м " : "")}{(timeSpan.Seconds > 0 ? $"{timeSpan.Seconds}c" : "")}{(timeSpan.Milliseconds > 0 ? $" {timeSpan.Milliseconds}мс" : "")}";
            }
        }
    }

    public class RunSystem
    {
        public string platform { get; set; }
        public bool emulated { get; set; }
        public string region { get; set; }
    }

    public class RunValues
    {
        public string _789j00nw { get; set; }
        public string rn11jqon { get; set; }
        public string r8r16x0n { get; set; }
        public string rn14qmvn { get; set; }
        public string jlz599ql { get; set; }
        public string kn0jkvdl { get; set; }
        public string _0nwow2dl { get; set; }
        public string yn21yye8 { get; set; }
        public string rn1k11lj { get; set; }
        public string _68k46dql { get; set; }
        public string jlz7exn2 { get; set; }
        public string kn0de0l3 { get; set; }
    }

    public class RunPlatform
    {
        public RunData1 data { get; set; }
    }

    public class RunData1
    {
        public string id { get; set; }
        public string name { get; set; }
        public int released { get; set; }
        public RunLink4[] links { get; set; }
    }

    public class RunLink4
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

    public class RunLink5
    {
        public string rel { get; set; }
        public string uri { get; set; }
    }

}
