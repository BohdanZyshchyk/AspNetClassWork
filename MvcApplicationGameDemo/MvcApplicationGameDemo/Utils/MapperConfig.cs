using AutoMapper;
using GameStore.DAL.Entities;
using MvcApplicationGameDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationGameDemo.Utils
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            // Model => ViewModel
            CreateMap<Game, GameCreateViewModel>()
                .ForMember(x=> x.Genre, y=> y.MapFrom(z => z.Genre.Name))
                .ForMember(x => x.Developer, y => y.MapFrom(z => z.Developer.Name));

            CreateMap<GameCreateViewModel, Game>()
              .ForMember(x => x.Genre, y => y.MapFrom(z => new Genre { Name = z.Genre}))
              .ForMember(x => x.Developer, y => y.MapFrom(z => new Developer { Name = z.Developer }));
        }
    }
}