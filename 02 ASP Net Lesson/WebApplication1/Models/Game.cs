using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public int Year { get; set; }
        public string Descroption { get; set; }
        [Required]
        public string Image{ get; set; }

        /*navigation properties*/
        public virtual Genre Genre { get; set; }
        public virtual Developer Developer { get; set; }
    }
}