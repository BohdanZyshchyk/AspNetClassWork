﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class NewsViewModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public string ImageName { get; set; }
        public string Category { get; set; }
    }
}