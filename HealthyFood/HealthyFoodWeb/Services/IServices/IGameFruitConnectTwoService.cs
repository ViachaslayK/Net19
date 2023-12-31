﻿using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services.IServices
{
    public interface IGameFruitConnectTwoService
    {
        public List<SimilarGame> GetSimilarGameList();

        public void AddGame(GetFruitConnectTwoViewModel model);
        public void RemoveGame(int id);
    }
}