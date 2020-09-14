using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace News.DataAccess.Entity
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public string CommentAuthor { get; set; }
        public virtual tblNews News { get; set; }
    }
}
