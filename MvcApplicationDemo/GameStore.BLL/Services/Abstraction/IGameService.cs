using GameStore.BLL.Filters;
using GameStore.DAL.Entities;
using System.Collections.Generic;

namespace GameStore.BLL.Services.Abstraction
{
    public interface IGameService
    {
        ICollection<Game> GetAllGames();
        void AddGame(Game game);
        ICollection<string> GetAllGenres();
        ICollection<string> GetAllDevelopers();
        Game GetGame(int id);
        void Delete(int id);
        void Update(Game game);
        ICollection<Game> FilterGames(List<GameFilter> lists);
    }
}
