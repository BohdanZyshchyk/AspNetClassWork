using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplicationGameDemo.Models
{
    public class GameCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Enter name!!!")]
        [Display(Name="Game name:")]
        [MinLength(2)]
        [StringLength(100)]
        //[RegularExpression("")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter year!!!")]
        [Display(Name="Game year:")]
        [Range(1980, 2020 , ErrorMessage = "Year from 1980 to 2020")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Enter Description!!!")]
        [Display(Name= "Description:")]
        public string Description { get; set; }

        [Display(Name= "Image:")]
        public string Image { get; set; }

        /*navigation properties*/
        [Required(ErrorMessage = "Choose Genre!!!")]
        [Display(Name= "Genre:")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Choose Developer!!!")]
        [Display(Name= "Developer:")]
        public string Developer { get; set; }
    }
}