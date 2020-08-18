using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _04_PlanerProject.Models
{
    public class EventViewModelList
    {
        public IEnumerable<EventViewModel> Models { get; set; }
        public EventViewModelList()
        {
            Models = new List<EventViewModel>();
        }
        public int TotalCount { get; set; }
        public int ActualPage { get; set; }
        public int CountOnPage { get; set; }

    }
}