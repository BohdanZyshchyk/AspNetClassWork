using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageWorker.Models
{
    public class CreateProductVewModel
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}