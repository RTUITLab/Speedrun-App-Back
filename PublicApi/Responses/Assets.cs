using System.Text.Json.Serialization;

namespace PublicApi.Responses
{
    public class Assets
    {
        public Logo logo { get; set; }
        [JsonPropertyName("cover-tiny")]
        public CoverTiny covertiny { get; set; }
        [JsonPropertyName("cover-small")]
        public CoverSmall coversmall { get; set; }
        [JsonPropertyName("cover-medium")]
        public CoverMedium covermedium { get; set; }
        [JsonPropertyName("cover-large")]
        public CoverLarge coverlarge { get; set; }
        public Icon icon { get; set; }
        [JsonPropertyName("trophy-1st")]
        public Trophy1St trophy1st { get; set; }
        [JsonPropertyName("trophy-2st")]
        public Trophy2Nd trophy2nd { get; set; }
        [JsonPropertyName("trophy-3st")]
        public Trophy3Rd trophy3rd { get; set; }
        [JsonPropertyName("trophy-4st")]
        public object trophy4th { get; set; }
        public Background background { get; set; }
        public Foreground foreground { get; set; }
    }
}
