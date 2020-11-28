using HtmlAgilityPack;
using PublicApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Web.Services
{
    public class StreamsService : IStreamsApi
    {
        private readonly ISpeedrunRefit gamesInterfaseRefit;

        public StreamsService(
            ISpeedrunRefit gamesInterfaseRefit)
        {
            this.gamesInterfaseRefit = gamesInterfaseRefit;
        }
        public async Task<List<Stream>> GetStreams(string country = "", string haspb = "on", int start = 0)
        {
            var message = await gamesInterfaseRefit.Streams(country, haspb, start);
            var content = await message.Content.ReadAsStringAsync();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);
            var list = new List<Stream>();

            var cells = htmlDoc.DocumentNode.SelectNodes("div[contains(@class, 'stream-cell')]");
            foreach (var cell in cells)
            {
                var stream = new Stream();
                stream.twichUrl = cell.SelectSingleNode("a[1]")?.Attributes["href"]?.Value ?? "no twich url";
                if (stream.twichUrl.StartsWith("https://www.twitch.tv/"))
                {
                    stream.id = stream.twichUrl[(stream.twichUrl.LastIndexOf('/') + 1)..];
                }
                stream.previewImage = cell.SelectSingleNode(".//img[contains(@class, 'stream-preview')]")?.Attributes["src"]?.Value;
                var streamsLinkNode = cell.SelectSingleNode(".//a[contains(@class, 'cover-link')]");
                stream.streamsLink = streamsLinkNode?.Attributes["href"]?.Value ?? "";
                if (!string.IsNullOrEmpty(stream.streamsLink))
                {
                    stream.streamsLink = "https://www.speedrun.com" + stream.streamsLink;
                }
                var streamImageNode = streamsLinkNode.SelectSingleNode("img");
                stream.gameTitle = streamImageNode?.Attributes["title"]?.Value ?? "no game title";
                stream.gameCoverImage = streamImageNode?.Attributes["src"]?.Value ?? "no game cover image";
                if (stream.gameCoverImage != "no game cover image")
                {
                    stream.gameCoverImage = "https://www.speedrun.com" + stream.gameCoverImage;
                }
                stream.streamTitle = cell.SelectSingleNode("./a")?.InnerText ?? "no stream title";
                var small = cell.SelectSingleNode(".//small");
                stream.watchingCount = int.TryParse(
                    string.Join("", Regex
                                        .Matches(small.GetDirectInnerText(), @"\d")
                                        .Select(m => m.Value)),
                    out var parsed) ? parsed : -1;
                stream.flagImage = cell.SelectSingleNode(".//img[contains(@class, 'flagicon')]")?.Attributes["src"]?.Value ?? "no flag icon";
                if (stream.flagImage != "no flag icon")
                {
                    stream.flagImage = "https://www.speedrun.com" + stream.flagImage;
                }
                stream.nickName = cell.SelectSingleNode(".//a[contains(@class, 'link-username') or parent::small]")?.InnerText ?? "no username";
                list.Add(stream);
            }
            return list;
        }
    }
}
