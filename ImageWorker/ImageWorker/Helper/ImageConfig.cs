using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ImageWorker.Helper
{
    public static class ImageConfig
    {
        public static string ProductImagePath
        {
            get { return ConfigurationManager.AppSettings["ProductImagePath"]; }  
        }
        public static string DomainProject
        {
            get { return ConfigurationManager.AppSettings["DomainProject"]; }
        }
    }
}