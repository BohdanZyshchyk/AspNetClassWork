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
    public class GenreService : IGenreService
    {
        private readonly IGenericRepository<Genre> repoGen;
        public GenreService(IGenericRepository<Genre> _gen)
        {
            repoGen = _gen;
        }

        public void AddGenre(Genre Genre)
        {
            repoGen.Create(Genre);
        }

        public void Delete(int id)
        {
            repoGen.Delete(repoGen.Find(id));
        }

        public ICollection<Genre> GetAllGenres()
        {
            return repoGen.GetAll().ToList();
        }

        public Genre GetGenre(int id)
        {
            return repoGen.Find(id);
        }

        public void Update(Genre Genre)
        {
            var found = repoGen.Find(Genre.Id);
            found = Genre;
            repoGen.Update(found);
        }
    }
}
