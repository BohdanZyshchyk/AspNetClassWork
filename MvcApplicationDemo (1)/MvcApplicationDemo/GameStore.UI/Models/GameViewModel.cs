using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStore.UI.Models
{
    public class GameViewModel
    {
        public int Id { get; set; }
        [Display(Name="Назва гри:")]
        [Required(ErrorMessage ="Введіть, будь ласка, назву гри")]
        [MinLength(2)]
        [StringLength(100)]
        //[RegularExpression("")]
        public string Name { get; set; }
        
        [Display(Name="Рік:")]
        [Range(1980, 2020, ErrorMessage ="Рік не повинен бути більшим за 2020 та меншим за 1980")]
        [Required(ErrorMessage = "Введіть, будь ласка, рік")]
        public int Year { get; set; }
        
        [Display(Name="Опис:")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Must be not empty")]
        public string Description { get; set; }
        
        [Display(Name="Зображення:")]
        public string Image { get; set; }
        
        [Display(Name="Жанр:")]
        [Required(ErrorMessage ="Оберіть жанр")]
        public string Genre { get; set; }
        
        [Display(Name="Розробник:")]
        [Required(ErrorMessage ="Оберіть розробника")]
        public string Developer { get; set; }

        [Display(Name ="Ціна")]
        [Required(ErrorMessage = "Введіть ціну")]
        public int Price { get; set; }
    }
}