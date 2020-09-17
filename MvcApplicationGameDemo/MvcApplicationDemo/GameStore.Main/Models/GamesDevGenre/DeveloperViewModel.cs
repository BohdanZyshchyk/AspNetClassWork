using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStore.Main.Models.GamesDevGenre
{
    public class DeveloperViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Назва розробника:")]
        [Required(ErrorMessage = "Введіть, будь ласка, назву розробника")]
        [StringLength(200)]
        public string Name { get; set; }
    }
}