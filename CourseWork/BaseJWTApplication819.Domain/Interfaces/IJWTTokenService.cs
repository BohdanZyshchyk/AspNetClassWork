﻿using BaseJWTApplication819.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseJWTApplication819.Domain.Interfaces
{
    public interface IJWTTokenService
    {
        string CreateToken(User user);
    }
}
