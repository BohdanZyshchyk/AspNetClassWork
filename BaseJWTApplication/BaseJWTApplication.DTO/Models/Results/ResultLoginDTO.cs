using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWTApplication.DTO.Models.Results
{
    public class ResultLoginDTO:ResultDTO
    {
        public string Token { get; set; }
    }
}
