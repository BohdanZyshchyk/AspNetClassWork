using BaseJWTApplication.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using BaseJWTApplication.DataAccess.Entity;
using BaseJWTApplication.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace BaseJWTApplication.Domain.Implementations
{
    public class JWTTokenService : IJWTTokenService
    {
        private readonly EFContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public JWTTokenService(EFContext context, IConfiguration configuration, UserManager<User> userManager)
        {
            _context = context;
            _configuration = configuration;
            _userManager = userManager;
        }
        public string CreateToken(User user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            //var fullName = _context.UserAdditionalInfos.FirstOrDefault(x => x.Id == user.Id).FullName;

            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("email", user.Email.ToString()),

            };

            foreach (var role in roles)
            {
                claims.Add(new Claim("roles", role));
            }

            string jwtTokenSecretkey = _configuration.GetValue<string>("SecretPhrase");

            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenSecretkey));

            var signInCredentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);


            var jwt = new JwtSecurityToken(
                signingCredentials: signInCredentials,
                claims: claims,
                expires:DateTime.Now.AddDays(7));

            return new JwtSecurityTokenHandler().WriteToken(jwt);

        }
    }
}
