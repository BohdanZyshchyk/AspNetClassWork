using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStore.Main.Models.GamesDevGenre
{
    public class GenreViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Назва жанру:")]
        [Required(ErrorMessage = "Введіть, будь ласка, назву жанру")]
        [StringLength(200)]
        public string Name { get; set; }
    }
}