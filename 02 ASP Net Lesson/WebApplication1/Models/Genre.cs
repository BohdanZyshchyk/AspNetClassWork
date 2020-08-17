using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        //NavigationProperty Props
        public virtual ICollection<Game> Games { get; set; }
        public Genre()
        {
            Games = new List<Game>();
        }

    }
}