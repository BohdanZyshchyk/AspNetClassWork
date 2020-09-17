using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Store.Models.Custom
{
    [Table("tblUserAdditionalInfo")]
    public class UserAdditionalInfo
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Image { get; set; }
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}