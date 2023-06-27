﻿using Data.Interface.Models;
using Data.Interface.Models.WikiMc;
using Data.Interface.Repositories;
using Data.Sql.Repositories;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.WebRequestMethods;

namespace HealthyFoodWeb.Utility
{
    public static class SeedData
    {
        private const int MIN_GAME_COUNT = 20;
        private const int MIN_STORE_COUNT = 20;
        private const int MIN_CART_COUNT = 20;
        private static Random _random = new Random();

        public static void Seed(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                SeedUsers(scope);
                SeedManufacturer(scope);
                SeedStoreItems(scope);
                SeedGameCategory(scope);
                SeedGame(scope);
                SeedReview(scope);
                SeedCart(scope);
                SeedCartTags(scope);
            }
        }

        private static void SeedCart(IServiceScope scope)
        {
            var cartRepository = scope.ServiceProvider.GetRequiredService<ICartRepository>();
            var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
            var cartTagRepository = scope.ServiceProvider.GetRequiredService<ICartTagRepository>();


            if (!cartRepository.Any())
            {
                var user = userRepository.GetFirst();
                var tags = cartTagRepository.GetAll();
                var productdefault = new Cart
                {
                    Name = "Salat",
                    Price = 3,
                    Customer = user,
                    ImgUrl = "https://podacha-blud.com/uploads/posts/2022-12/1670444503_60-podacha-blud-com-p-legkii-salat-foto-63.jpg",
                    Tags = new List<CartTags> { tags.Random() }
                };
                cartRepository.Add(productdefault);
            }

            if (cartRepository.Count() < MIN_CART_COUNT)
            {
                var randomUser = userRepository.GetFirst();

                for (int i = 0; i < MIN_CART_COUNT; i++)
                {
                    var product = new Cart
                    {
                        Name = $"Sup {i}",
                        Price = 10 +i,
                        Customer = randomUser,
                        ImgUrl = "https://avatars.dzeninfra.ru/get-zen_doc/1945957/pub_5d887e5fa06eaf00ad1d7740_5d887e691d656a00ad33d1e0/scale_1200"
                    };
                    cartRepository.Add(product);
                }
            }
        }

        private static void SeedCartTags(IServiceScope scope)
        {
            var defaultTags = new List<string> { "Vegetarian", "Vegan", "Lactose-free", "Low-calorie", "Sugar-free" };

            var cartTagsRepository = scope.ServiceProvider
                .GetRequiredService<ICartTagRepository>();

            foreach (var tag in defaultTags)
            {
                if (cartTagsRepository.Get(tag) == null)
                {
                    var cartTagCatalog = new CartTags
                    {
                        Name = tag
                    };
                    cartTagsRepository.Add(cartTagCatalog);
                }
            }
        }

        private static void SeedUsers(IServiceScope scope)
        {
            var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();

            var admin = userRepository.GetByName("Admin");
            if (admin == null)
            {
                admin = new User
                {
                    Name = "Admin",
                    Password = "123",
                    AvatarUrl = "NoAvatar",
                    Role = MyRole.Admin
                };
                userRepository.Add(admin);
            }

            if (admin.Role != MyRole.Admin)
            {
                admin.Role = MyRole.Admin;
                userRepository.Update(admin);
            }
        }

        private static void SeedManufacturer(IServiceScope scope)
        {
            var manufacturerRepository = scope.ServiceProvider.GetRequiredService<IManufacturerRepository>();

            if (!manufacturerRepository.Any())
            {
                var adminManufacturer = new Manufacturer
                {
                    Name = "AdminManufacturer",
                };
                manufacturerRepository.Add(adminManufacturer);
            }
        }

        private static void SeedStoreItems(IServiceScope scope)
        {
            var storeCatalogueRepository = scope.ServiceProvider.GetRequiredService<IStoreCatalogueRepository>();
            var manufacturerRep = scope.ServiceProvider.GetRequiredService<IManufacturerRepository>();

            if (!storeCatalogueRepository.Any())
            {
                var manufacturer = manufacturerRep.GetFirst();
                var adminItem = new StoreItem
                {
                    Name = "Admin",
                    Price = 16,
                    ImageUrl = "NoImage",
                    Manufacturer = manufacturer

                };
                storeCatalogueRepository.Add(adminItem);
            }

            if (storeCatalogueRepository.Count() < MIN_STORE_COUNT)
            {
                var manufacturer = manufacturerRep.GetFirst();

                for (int i = 0; i < MIN_STORE_COUNT; i++)
                {
                    var adminItem = new StoreItem
                    {
                        Name = $"Admin{i}",
                        Price = 1 + i,
                        ImageUrl = "NoImage",
                        Manufacturer = manufacturer

                    };
                    storeCatalogueRepository.Add(adminItem);
                }
            }
        }
       
        private static void SeedGame(IServiceScope scope)
        {
            var gameRepository = scope.ServiceProvider.GetRequiredService<IGameRepository>();
            var genreRepository = scope.ServiceProvider.GetRequiredService<IGameCategoryRepository>();

            if (gameRepository.Count() < MIN_GAME_COUNT)
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var randomUser = userRepository.GetFirst();
                var genres = genreRepository.GetAll();

                for (int i = 0; i < MIN_GAME_COUNT; i++)
                {
                    var game = new Game
                    {
                        Name = $"RichGame№{i}",
                        Price = 1 + _random.Next(100),
                        CoverUrl = "https://i.imgur.com/eOtEAB7.jpg",
                        Creater = randomUser,
                        Genres = new List<GameCategory> { genres.Random() }
                    };
                    gameRepository.Add(game);
                }
            }

        }
        
        private static void SeedReview(IServiceScope scope)
        {
            var reviewRepository = scope.ServiceProvider.GetRequiredService<IReviewRepository>();
            if (!reviewRepository.Any())
            {
                var review = new Review
                {
                    TextReview = "",
                    Date = DateTime.Now
                };
            }
        }

        private static void SeedGameCategory(IServiceScope scope)
        {
            var defaultGenres = new List<string> { "Action", "Fight", "RPG", "Horror", "Hentai" };

            var gameCategoryRepository = scope.ServiceProvider
                .GetRequiredService<IGameCategoryRepository>();

            foreach (var genreName in defaultGenres)
            {
                if (gameCategoryRepository.Get(genreName) == null)
                {
                    var gameCatalog = new GameCategory
                    {
                        Name = genreName
                    };
                    gameCategoryRepository.Add(gameCatalog);
                }
            }
        }

        private static void SeedWikiTag(IServiceScope scope)
        {
            var defaultTags = new List<string> { "Protein", "Fat", "Carb", "Muscles", "Polyunsaturated fats", "Complex carbs" };

            var tagRepository = scope.ServiceProvider
                .GetRequiredService<IWikiTagRepository>();

            foreach (var tagName in defaultTags)
            {
                if (tagRepository.Get(tagName) == null)
                {
                    var tagCatalog = new WikiTags
                    {
                        TagName = tagName
                    };
                    tagRepository.Add(tagCatalog);
                }
            }
        }

        private static void SeedWikiMcImage(IServiceScope scope)
        {
            var wikiMcImagesRepository = scope.ServiceProvider.GetRequiredService<IWikiMcRepository>();

            if (!wikiMcImagesRepository.Any())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var tagRepository = scope.ServiceProvider.GetRequiredService<IWikiTagRepository>();
                var tags = tagRepository.GetAll().ToDictionary(x => x.TagName, x => x);
                var randomUser = userRepository.GetFirst();
                var image1 = new WikiMcImage
                {
                    ImgUrl = "https://avatars.dzeninfra.ru/get-zen_doc/41204/pub_5b00259fad0f222dd299aae7_5b005a50a936f4e52e30b616/scale_1200",
                    Year = 2023,
                    ImgType = ImgTypeEnum.Proteins,
                    ImageUploader = randomUser,
                    Tags = new List<WikiTags> { tags["Protein"], tags["Muscles"] },
                };
                wikiMcImagesRepository.Add(image1);

                var image2 = new WikiMcImage
                {
                    ImgUrl = "https://www.health.com/thmb/nxURaqGxebTJBMzXi5jZpaAL02Q=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/Healthy-Fats-Food-GettyImages-1301412044-2000-8ab23a10624d42df85fa3f37d7c76a6b.jpg",
                    Year = 2023,
                    ImgType = ImgTypeEnum.Fats,
                    ImageUploader = randomUser,
                    Tags = new List<WikiTags> { tags["Fat"], tags["Polyunsaturated fats"] },
                };
                wikiMcImagesRepository.Add(image2);

                var image3 = new WikiMcImage
                {
                    ImgUrl = "https://medlineplus.gov/images/Carbohydrates_share.jpg",
                    Year = 2023,
                    ImgType = ImgTypeEnum.Carbs,
                    ImageUploader = randomUser,
                    Tags = new List<WikiTags> { tags["Carb"], tags["Complex carbs"] },
                };
                wikiMcImagesRepository.Add(image3);
            }
        }
    }
}