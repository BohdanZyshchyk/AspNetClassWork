using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Entities
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string ImageName { get; set; }
        public Category Category { get; set; }
    }
}