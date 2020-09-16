using GameStore.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GameStore.DAL.Initializer
{
    public class GamesInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.Roles.Any())
            {
                IdentityRole roleAdmin = new IdentityRole()
                {
                    Name = "Admin",
                };
                IdentityRole roleUser = new IdentityRole()
                {
                    Name = "User",
                };
                roleManager.Create(roleAdmin);
                roleManager.Create(roleUser);
            }
            var userManager = new UserManager<AppUser>(new UserStore<AppUser>(context));
            if (!userManager.Users.Any())
            {
                AppUser user = new AppUser()
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                };
                userManager.Create(user, "Qwerty-1");
                userManager.AddToRole(user.Id, "Admin");
            }
            var genre = new List<Genre> {
                new Genre {Name = "Action"},
                new Genre {Name = "Shooter"},
                new Genre {Name = "RPG"},
                new Genre {Name = "Sport Simulator"},
                new Genre {Name = "Strategy"},
                new Genre {Name = "MMORPG"},
                new Genre {Name = "Rasing"}
            };

            var developer = new List<Developer> {
                new Developer {Name="RockStar"},
                new Developer {Name="EA"},
                new Developer {Name="Epic"},
                new Developer {Name="Playrix"},
                new Developer {Name="Ghost Games"},
                new Developer {Name="Ubisoft"},
                new Developer {Name="Activision"},
                new Developer {Name="Bethesda"}

            };

            var games = new List<Game>
            {
                new Game {Name="FarCry", Description="FarCry info...", Genre=genre.FirstOrDefault(x => x.Name=="Shooter"), Year=2018, Image="https://upload.wikimedia.org/wikipedia/ru/4/42/Far_Cry_%D0%BE%D0%B1%D0%BB%D0%BE%D0%B6%D0%BA%D0%B0.png",
                Developer=developer.FirstOrDefault(x => x.Name=="Ubisoft"), Price = 123},
                new Game {Name="Assassins Creed", Description="Assassins info...", Genre=genre.FirstOrDefault(x => x.Name=="Action"), Year=2018, Image="https://ubistatic19-a.akamaihd.net/marketingresource/ru-ru/assassins-creed/assassins-creed-odyssey/assets/images/ack_announce-slide_keyart_361691.jpg",
                Developer=developer.FirstOrDefault(x => x.Name=="Ubisoft"), Price = 78},
                new Game {Name="GTA 5", Description="GTA 5 info...", Genre=genre.FirstOrDefault(x => x.Name=="MMORPG"), Year=201, Image="https://cdn2.unrealengine.com/Diesel%2Fproductv2%2Fgrand-theft-auto-v%2Fhome%2FGTAV_EGS_Artwork_1920x1080_Hero-Carousel_V06-1920x1080-1503e4b1320d5652dd4f57466c8bcb79424b3fc0.jpg?h=1080&resize=1&w=1920",
                Developer=developer.FirstOrDefault(x => x.Name=="RockStar"), Price = 45},
                new Game {Name="FIFA", Description="FIFA info...", Genre=genre.FirstOrDefault(x => x.Name=="Strategy"), Year=1990, Image="https://i1.rozetka.ua/goods/13967460/fifa_20_standartnoe_izdanie_ps4_russkaya_versiya_images_13967460598.jpg",
                Developer=developer.FirstOrDefault(x => x.Name=="Playrix"), Price = 100},
                new Game {Name="Metro", Description="Metro info...", Genre=genre.FirstOrDefault(x => x.Name=="Sport Simulator"), Year=2042, Image="https://upload.wikimedia.org/wikipedia/ru/thumb/c/c5/Metro_Exodus.png/1200px-Metro_Exodus.png",
                Developer=developer.FirstOrDefault(x => x.Name=="Activision"), Price = 40},

                new Game {Name="FarCry", Description="FarCry info...", Genre=genre.FirstOrDefault(x => x.Name=="Shooter"), Year=2018, Image="https://upload.wikimedia.org/wikipedia/ru/4/42/Far_Cry_%D0%BE%D0%B1%D0%BB%D0%BE%D0%B6%D0%BA%D0%B0.png",
                Developer=developer.FirstOrDefault(x => x.Name=="Ubisoft"), Price = 123},
                new Game {Name="Assassins Creed", Description="Assassins info...", Genre=genre.FirstOrDefault(x => x.Name=="Action"), Year=2018, Image="https://ubistatic19-a.akamaihd.net/marketingresource/ru-ru/assassins-creed/assassins-creed-odyssey/assets/images/ack_announce-slide_keyart_361691.jpg",
                Developer=developer.FirstOrDefault(x => x.Name=="Ubisoft"), Price = 78},
                new Game {Name="GTA 5", Description="GTA 5 info...", Genre=genre.FirstOrDefault(x => x.Name=="MMORPG"), Year=201, Image="https://cdn2.unrealengine.com/Diesel%2Fproductv2%2Fgrand-theft-auto-v%2Fhome%2FGTAV_EGS_Artwork_1920x1080_Hero-Carousel_V06-1920x1080-1503e4b1320d5652dd4f57466c8bcb79424b3fc0.jpg?h=1080&resize=1&w=1920",
                Developer=developer.FirstOrDefault(x => x.Name=="RockStar"), Price = 45},
                new Game {Name="FIFA", Description="FIFA info...", Genre=genre.FirstOrDefault(x => x.Name=="Strategy"), Year=1990, Image="https://i1.rozetka.ua/goods/13967460/fifa_20_standartnoe_izdanie_ps4_russkaya_versiya_images_13967460598.jpg",
                Developer=developer.FirstOrDefault(x => x.Name=="Playrix"), Price = 100},
                new Game {Name="Metro", Description="Metro info...", Genre=genre.FirstOrDefault(x => x.Name=="Sport Simulator"), Year=2042, Image="https://upload.wikimedia.org/wikipedia/ru/thumb/c/c5/Metro_Exodus.png/1200px-Metro_Exodus.png",
                Developer=developer.FirstOrDefault(x => x.Name=="Activision"), Price = 40},
                new Game {Name="FarCry", Description="FarCry info...", Genre=genre.FirstOrDefault(x => x.Name=="Shooter"), Year=2018, Image="https://upload.wikimedia.org/wikipedia/ru/4/42/Far_Cry_%D0%BE%D0%B1%D0%BB%D0%BE%D0%B6%D0%BA%D0%B0.png",
                Developer=developer.FirstOrDefault(x => x.Name=="Ubisoft"), Price = 123},
                new Game {Name="Assassins Creed", Description="Assassins info...", Genre=genre.FirstOrDefault(x => x.Name=="Action"), Year=2018, Image="https://ubistatic19-a.akamaihd.net/marketingresource/ru-ru/assassins-creed/assassins-creed-odyssey/assets/images/ack_announce-slide_keyart_361691.jpg",
                Developer=developer.FirstOrDefault(x => x.Name=="Ghost Games"), Price = 78}
            };
            context.Developers.AddRange(developer);
            context.Genres.AddRange(genre);
            context.Games.AddRange(games);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
