using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Entities
{
    [Table("tblCategories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public virtual ICollection<News> News { get; set; }
        public Category()
        {
            News = new List<News>();
        }
    }
}