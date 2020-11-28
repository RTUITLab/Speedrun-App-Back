using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GamesService> logger;

        public GamesService(
            IHttpClientFactory httpClientFactory,
            ISpeedrunRefit gamesInterfaseRefit,
            ILogger<GamesService> logger)
        {
            this.httpClient = httpClientFactory.CreateClient("speedrun_site");
            this.gamesInterfaseRefit = gamesInterfaseRefit;
            this.logger = logger;
        }
        public Task<SpeedranResponseWrapper<List<Game>>> Games(int offset = 0)
        {
            return gamesInterfaseRefit.Games(offset);
        }

        public async Task<List<GameCompact>> GetGameCompacts(int start = 0, string platform = "", string orderby = "mostactive", bool unoffical = false)
        {
            var content = await httpClient.GetStringAsync($"ajax_games.php?game=&platform={platform}&unofficial={(unoffical ? "on" : "off")}&orderby={orderby}&title=&series=&start={start}");
            List<GameCompact> games = new List<GameCompact>();
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(content);
            var aNodes = htmlDoc.DocumentNode.SelectNodes("//a[@data-url]");
            if (aNodes == null)
            {
                return games;
            }
            foreach (var a in aNodes)
            {
                try
                {
                    var game = new GameCompact();

                    game.id = a?.Attributes["data-url"]?.Value ?? "no id";
                    game.image = a.SelectSingleNode("img[last()]")?.Attributes?["src"]?.Value ?? "";
                    if (!string.IsNullOrEmpty(game.image))
                    {
                        game.image = httpClient.BaseAddress + game.image.TrimStart('/');
                    }
                    game.title = a.SelectSingleNode("div[last()]")?.InnerText ?? "No Title";
                    try
                    {
                        game.activePlayers = int.TryParse(Regex.Match(a.NextSibling.NextSibling.InnerText, @"\d+").Value, out var parsed) ? parsed : -1;
                    }
                    catch
                    {
                        game.activePlayers = -1;
                    }
                    games.Add(game);
                }
                catch (Exception ex)
                {
                    logger.LogWarning(ex, "can't parse node");
                }
            }
            return games;
        }
    }
}
