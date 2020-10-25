using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseJWTApplication819.DataAccess.Entity
{
    public class Meme
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public virtual User User { get; set; }
        public virtual List<Comment> Comments {get; set;}
        public Meme()
        {
            Comments = new List<Comment>();
        }
    }
}
