﻿using Binbin.Linq;
using GameStore.BLL.Filters;
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

            //context.Games.Where(x=> x.Developer.Name =="EA" || x=> x.Developer.Name =="Ubisoft"...) 
            var predicates = PredicateBuilder.Create(filters[0].Predicate);
            for (int i = 1; i < filters.Count; i++)
            {
                predicates = predicates.Or(filters[i].Predicate);
            }

            var games = repo.Filter(predicates);
            return games.ToList();
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