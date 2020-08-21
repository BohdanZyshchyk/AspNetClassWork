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
        private readonly IGenericRepository<Genre> repoGenre;
        private readonly IGenericRepository<Developer> repoDev;
        public GameServices(IGenericRepository<Game> _repo,
            IGenericRepository<Genre> _repoGenre,
            IGenericRepository<Developer> _repoDev)
        {
            repo = _repo;
            repoGenre = _repoGenre;
            repoDev = _repoDev;
        }

        public void AddGame(Game game)
        {

            var genres = repoGenre.GetAll().FirstOrDefault(x => x.Name == game.Genre.Name);
            var developer = repoDev.GetAll().FirstOrDefault(x => x.Name == game.Developer.Name);

            game.Genre = genres;
            game.Developer = developer;
            repo.Create(game);
        }

        public ICollection<string> GetAllDevelopers()
        {
            return repoDev.GetAll().Select(x => x.Name).ToList();
        }

        public ICollection<Game> GetAllGames()
        {
            return repo.GetAll().ToList();
        }

        public ICollection<string> GetAllGenres()
        {
            return repoGenre.GetAll().Select(x => x.Name).ToList();
        }
    }
}
