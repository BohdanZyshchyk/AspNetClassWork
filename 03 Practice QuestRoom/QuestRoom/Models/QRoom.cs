using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuestRoom.Models
{
    public class QRoom
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int TimeMinutes { get; set; }
        public int NumbPlayers { get; set; }
        public int Age { get; set; }
        [Range(1,5)]
        public int Difficulty { get; set; }
        [Range(1,5)]
        public int Horror { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public int Rating { get; set; }
        public string Address { get; set; }

        /*navigation properties*/
        public virtual ICollection<Image> Images{ get; set; }
        public QRoom()
        {
            Images = new List<Image>();
        }
    }
}