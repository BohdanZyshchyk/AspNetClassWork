using BaseJWTApplication.DataAccess;
using BaseJWTApplication.DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWTApplication.Domain.Interfaces
{
    public interface IJWTTokenService
    {

        public string CreateToken(User user);
    }
}
