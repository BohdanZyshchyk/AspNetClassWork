using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstraction
{
    public interface IDeveloperService
    {
        ICollection<Developer> GetAllDevelopers();
        void AddDeveloper(Developer developer);
        Developer GetDeveloper(int id);
        void Delete(int id);
        void Update(Developer developer);
    }
}
