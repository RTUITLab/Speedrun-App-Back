﻿using PublicApi.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public interface ISpeedrunRefit
    {
        [Get("/api/v1/games")]
        Task<SpeedranResponseWrapper<List<Game>>> Games(int offset = 0);
        [Get("/api/v1/games/{gameId}")]
        Task<SpeedranResponseWrapper<Game>> Game(string gameId);
        [Get("/api/v1/games/{gameId}/categories")]
        Task<SpeedranResponseWrapper<List<Category>>> Categories(string gameId);
        [Get("/ajax_streams.php")]
        Task<HttpResponseMessage> Streams(string country, string haspb, int start);

        [Get("/api/v1/regions")]
        Task<SpeedranResponseWrapper<List<Region>>> Regions();
        [Get("/api/v1/platforms")]
        Task<SpeedranResponseWrapper<List<Platform>>> Platforms(int offset);

        [Get("/api/v1/leaderboards/{gameId}/category/{categoryId}")]
        Task<SpeedranResponseWrapper<Leaderboard>> Leaderboard(string gameId, string categoryId, string[] embed, int top = 100);

        [Get("/api/v1/runs")]
        Task<SpeedranResponseWrapper<List<SpeedrunAppBack.PublicApi.Responses.Run.RunModel>>> Runs(string[] embed, string orderby = "verify-date", string direction = "desc");
        [Get("/api/v1/runs")]
        Task<RunForFavorite> Runs(string gameId, string orderby = "verify-date", string direction = "desc");

    }
    public class RunForFavorite
    {
        public List<DataForFavorite> data { get; set; }
    }

    public class DataForFavorite
    {
        public string game { get; set; }
        public Times times { get; set; }
    }
}
