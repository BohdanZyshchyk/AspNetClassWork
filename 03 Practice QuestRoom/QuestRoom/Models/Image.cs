using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuestRoom.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public QRoom QRoom { get; set; }
    }
}