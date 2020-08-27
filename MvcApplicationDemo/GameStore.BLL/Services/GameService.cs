using Binbin.Linq;
using GameStore.BLL.Filters;
using GameStore.BLL.Services.Abstraction;
using GameStore.DAL.Entities;
using GameStore.DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services
{
    public class GameService : IGameService
    {
        private readonly IGenericRepository<Game> repo;
        private readonly IGenericRepository<Genre> repoGenre;
        private readonly IGenericRepository<Developer> repoDev;
        public GameService(IGenericRepository<Game> _repo,
            IGenericRepository<Genre> _genre, IGenericRepository<Developer> _dev)
        {
            repo = _repo;
            repoGenre = _genre;
            repoDev = _dev;
        }

        public void AddGame(Game game)
        {

            var genres = repoGenre.GetAll().FirstOrDefault(x => x.Name == game.Genre.Name);

            game.Genre = genres;

            var devs = repoDev.GetAll().FirstOrDefault(x => x.Name == game.Developer.Name);
            game.Developer = devs;

            repo.Create(game);
        }

        public void Delete(int id)
        {
            repo.Delete(repo.Find(id));
        }

        public ICollection<Game> FilterGames(List<GameFilter> filters)
        {
            // filter == 
            // { Type = "Developer" , Name = "EA", Predicate = (x => x.Developer.Name == Name)}
            // { Type = "Developer" , Name = "Ubisoft", Predicate = (x => x.Developer.Name == Ubisoft)}
            // { Type = "Genre" , Name = "Ubisoft", Predicate = (x => x.Genre.Name == Shooter)}
            // { Type = "Genre" , Name = "Ubisoft", Predicate = (x => x.Genre.Name == Action)}

            //context.Games.Where(x=> x.Developer.Name =="EA" || x=> x.Developer.Name =="Ubisoft"...) 
            if (filters.Count != 0)
            {
                var predicates = new List<Expression<Func<Game, bool>>>();

                foreach (var type in filters.GroupBy(x => x.Type))
                {
                    var predicate = PredicateBuilder.Create(type.First().Predicate);
                    for (int i = 1; i < type.Count(); i++)
                    {
                        predicate = predicate.Or(type.ToArray()[i].Predicate);
                    }
                    predicates.Add(predicate);
                }

                var res = PredicateBuilder.Create(predicates[0]);
                for (int i = 1; i < predicates.Count(); i++)
                {
                    res = res.And(predicates[i]);
                }
                var games = repo.Filter(res);
                return games.ToList();
            }
            else return repo.GetAll().ToList();
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

        public Game GetGame(int id)
        {
            return repo.Find(id);
        }

        public void Update(Game game)
        {
            var found = repo.Find(game.Id);
            found = game;
            repo.Update(found);
        }
    }
}