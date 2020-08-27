using AutoMapper;
using GameStore.DAL.Entities;
using GameStore.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.UI.Utils
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            // Game => GameViewModel

            CreateMap<Game, GameViewModel>()
            // string genre <- Genre.Name
                .ForMember(x => x.Genre, opt => opt.MapFrom(z => z.Genre.Name))
            // string developer <- Developer.Name
                .ForMember(x => x.Developer, opt => opt.MapFrom(z => z.Developer.Name));

            // GameViewModel => Game
            CreateMap<GameViewModel, Game>()
                // Genre genre <- new Genre {Name = z.Genre (string)}
                .ForMember(x => x.Genre, opt => opt.MapFrom(z => new Genre { Name = z.Genre }))
                .ForMember(x => x.Developer, opt => opt.MapFrom(z => new Developer { Name = z.Developer }));
            CreateMap<Developer, DeveloperViewModel>();
            CreateMap<DeveloperViewModel, Developer>();


        }
    }
}