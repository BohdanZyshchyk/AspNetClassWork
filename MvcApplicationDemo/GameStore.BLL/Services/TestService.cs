using GameStore.BLL.Services.Abstraction;
using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class TestService //: IGameService
    {
        public void AddGame(Game game)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> GetAllDevelopers()
        {
            throw new NotImplementedException();
        }

        public ICollection<Game> GetAllGames()
        {
            return new List<Game>()
            {
                new Game{ Name = "11111"},
                new Game{ Name = "22222"},
                new Game{ Name = "33333"}
            };
        }

        public ICollection<string> GetAllGenres()
        {
            throw new NotImplementedException();
        }
    }
}
