using GameStore.DAL;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplicationContext();
            context.Database.Log = Log;
            foreach (var item in context.Games.Include(x=>x.Genre).Include(x=>x.Developer))
            {
                Console.WriteLine($"{item.Name} => {item.Genre.Name} => {item.Developer}");
            }

            var res = context.Genres.Where(x => x.Name == "Shooter");
        }

        private static void Log(string obj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(obj);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
