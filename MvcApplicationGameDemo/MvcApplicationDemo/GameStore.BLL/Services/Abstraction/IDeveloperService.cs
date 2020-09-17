using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstraction
{
    public interface IGenreService
    {
        ICollection<Genre> GetAllGenres();
        void AddGenre(Genre genre);
        Genre GetGenre(int id);
        void Delete(int id);
        void Update(Genre genre);
    }
}
