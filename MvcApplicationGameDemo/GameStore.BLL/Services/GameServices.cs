using GameStore.BLL.Services.Abstraction;
using GameStore.DAL.Entities;
using GameStore.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class GameServices: IGameServices
    {
        private readonly IGenericRepository<Game> repo;
        public GameServices(IGenericRepository<Game> _repo)
        {
            repo = _repo;
        }

        public ICollection<Game> GetAllGames()
        {
            return repo.GetAll().ToList();
        }
    }
}
