﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseJWTApplication.ApiAngular.Helpers;
using BaseJWTApplication.DataAccess;
using BaseJWTApplication.DataAccess.Entity;
using BaseJWTApplication.Domain.Interfaces;
using BaseJWTApplication.DTO.Models.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaseJWTApplication.ApiAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly EFContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTTokenService _jWTTokenService;
        public AcountController(
            EFContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IJWTTokenService jWTTokenService)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _jWTTokenService = jWTTokenService;
        }
        [HttpPost("register")]
        public async Task<ResultDTO> RegisterUserAsync([FromBody] UserRegisterDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new ResultErrorDTO
                    {
                        Status = 200,
                        Message = "ERROR",
                        Errors = CustomValidator.GetErrorsByModel(ModelState)
                    };
                }
                var user = new User()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.Phone
                };

                var userProfile = new UserAdditionalInfo()
                {
                    Address = model.Address,
                    Image = "default.jpg",
                    FullName = model.FullName,
                    Id = user.Id
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    return new ResultErrorDTO
                    {
                        Message = "Error",
                        Status = 500,
                        Errors = CustomValidator.GetErrorsByIdentityResults(result)
                    };
                }
                else
                {
                    result = _userManager.AddToRoleAsync(user, "User").Result;
                    _context.UserAdditionalInfos.Add(userProfile);
                    _context.SaveChanges();
                }

                return new ResultDTO
                {
                    Status = 200,
                    Message = "OK"
                };

            }
            catch (Exception)
            {
                return new ResultDTO
                {
                    Message = "ServerError",
                    Status = 200
                };
            }
        }

        [HttpPost("login")]
        public async Task<ResultDTO> LoginUserAsync([FromBody] UserLoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return new ResultErrorDTO
                {
                    Status = 403,
                    Message = "Invalid data for login",
                    Errors = CustomValidator.GetErrorsByModel(ModelState)
                };
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
            {
                return new ResultErrorDTO
                {
                    Status = 401,
                    Message = "Error",
                    Errors = new List<string>()
                    {
                        "Incorrect login or password"
                    }
                }; 
            }
            else
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                await _signInManager.SignInAsync(user,false);

                return new ResultLoginDTO
                {
                    Status = 200,
                    Message = "OK",
                    Token = _jWTTokenService.CreateToken(user)
                };
            }
        }



    }
}
