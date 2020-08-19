using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstraction
{
    public interface IGameServices
    {
        ICollection<Game> GetAllGames();
    }
}
