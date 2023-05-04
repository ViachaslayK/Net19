﻿using Data.Interface.DataModels;
using Data.Interface.Models;
using Data.Interface.Repositories;

namespace Data.Fake.Repositories
{
    public class GameRepositoryFake : BaseRepository<Game>, IGameRepository
    {
        public GameRepositoryFake()
        {
            FakeDbModels.Add(new Game
            {
                Id = 1,
                Name = "Half-Life",
                CoverUrl = "data:image/jpeg;base64,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",
                Price = 10
            });
            FakeDbModels.Add(new Game
            {
                Id = 2,
                Name = "Tetris",
                CoverUrl = "https://upload.wikimedia.org/wikipedia/en/7/7d/Tetris_NES_cover_art.jpg",
                Price = 2
            });
            FakeDbModels.Add(new Game
            {
                Id = 3,
                Name = "Packman",
                Price = 1
            });
        }

        public Game GetGameAndGenres(int id)
        {
            throw new NotImplementedException();
        }

        public Game GetGameByName(string name)
        {
            return FakeDbModels.FirstOrDefault(x => x.Name == name);
        }

        public List<Game> GetGamesByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Game> GetGamesForPaginator(int page)
        {
            throw new NotImplementedException();
        }

        public GameAndPaginatorData GetGamesForPaginator(int page, int perPage)
        {
            throw new NotImplementedException();
        }

        public Game GetTheRichGameWithGenres()
        {
            throw new NotImplementedException();
        }

        public void RemoveByName(string name)
        {
            FakeDbModels.Remove(GetGameByName(name));
        }

        public void UpdateNameAndCover(int id, string name)
        {
            throw new NotImplementedException();
        }

        public void UpdateNameAndCover(int id, string name, string coverUrl)
        {
            throw new NotImplementedException();
        }
    }
}
