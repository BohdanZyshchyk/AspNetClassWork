using System;
using System.Collections.Generic;
using System.Text;

namespace NewsASPCORE.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DatePost { get; set; }
        public string LinkImage { get; set; }
        public string Description { get; set; }
    }
}
