using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseJWTApplication.DTO.Models.Results
{
    public class ResultDTO
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
