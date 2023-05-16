﻿using HealthyFoodWeb.Models.Games;
using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers.API
{
    [ApiController]
    [Route("/api/game")]
    public class GamesApiController : Controller
    {
        private IGameService _gameService;

        public GamesApiController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [Route("GamesCount")]
        public GamesCountViewModel GetGamesCount(int budget)
        {
            var viewModel = _gameService.GetViewModelForGamesCount(budget);
            Thread.Sleep(5 * 1000);
            return viewModel;
        }
    }
}