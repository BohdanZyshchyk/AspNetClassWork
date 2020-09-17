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
    public class DeveloperService : IDeveloperService
    {
        private readonly IGenericRepository<Developer> repoDev;
        public DeveloperService(IGenericRepository<Developer> _dev)
        {
            repoDev = _dev;
        }

        public void AddDeveloper(Developer developer)
        {
            repoDev.Create(developer);
        }

        public void Delete(int id)
        {
            repoDev.Delete(repoDev.Find(id));
        }

        public ICollection<Developer> GetAllDevelopers()
        {
            return repoDev.GetAll().ToList();
        }

        public Developer GetDeveloper(int id)
        {
            return repoDev.Find(id);
        }

        public void Update(Developer developer)
        {
            var found = repoDev.Find(developer.Id);
            found = developer;
            repoDev.Update(found);
        }
    }
}
