using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Filters
{
    public class GameFilter
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public Expression<Func<Game, bool>> Predicate { get; set; }

        // var g = db.Games
    }
}
