using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_PlanerProject.Models
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Date { get; set; }
    }
}