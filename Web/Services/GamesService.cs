using HtmlAgilityPack;
using PublicApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public class GamesService : IGamesApi
    {
        private readonly HttpClient httpClient;
        private readonly ISpeedrunRefit gamesInterfaseRefit;

        public GamesService(
            IHttpClientFactory httpClientFactory,
            ISpeedrunRefit gamesInterfaseRefit)
        {
            this.httpClient = httpClientFactory.CreateClient("speedrun_site");
            this.gamesInterfaseRefit = gamesInterfaseRefit;
        }
        public Task<SpeedranResponseWrapper<List<Game>>> Games(int offset = 0)
        {
            return gamesInterfaseRefit.Games(offset);
        }

        public async Task<List<GameCompact>> GetGameCompacts(int start = 0)
        {
            var content = await httpClient.GetStringAsync($"ajax_games.php?game=&platform=&unofficial=off&orderby=mostactive&title=&series=&start={start}");
            List<GameCompact> games = new List<GameCompact>();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);
            var aNodes = htmlDoc.DocumentNode.SelectNodes("div/a[@data-url]");
            foreach (var a in aNodes)
            {
                var game = new GameCompact();
                
                game.id = a?.Attributes["data-url"]?.Value ?? "no id";
                game.image =  a.SelectSingleNode("img[last()]")?.Attributes?["src"]?.Value ?? "";
                if (!string.IsNullOrEmpty(game.image))
                {
                    game.image = httpClient.BaseAddress + game.image.TrimStart('/');
                }
                game.title =  a.SelectSingleNode("div[last()]")?.InnerText ?? "No Title";
                game.activePlayers = int.TryParse(Regex.Match(a.NextSibling.NextSibling.InnerText, @"\d+").Value, out var parsed) ? parsed : -1;
                games.Add(game);
            }
            return games;
        }
    }
}
