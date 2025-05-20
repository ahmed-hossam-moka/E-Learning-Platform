using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OnlineLearningPlatform.BLL.Dtos.Auth;
using OnlineLearningPlatform.DAL.DataBase;
using OnlineLearningPlatform.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static OnlineLearningPlatform.DAL.Models.EnumsBase;

namespace OnlineLearningPlatform.BLL.Managers.Auth
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly PlatformContext _context;

        private static readonly string[] AllowedRoles = new[] { "Student", "Instructor", "Admin" };


        private readonly IConfiguration _configuration;
        public AuthManager(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration, PlatformContext context)
        {
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task<AccountDataModel> Login(LoginDto loginDto)
        {
            var accountDataModel = new AccountDataModel();

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                accountDataModel.Message = "Email or Password is incorrect!";
                return accountDataModel;
            }

            var claims = await _userManager.GetClaimsAsync(user);
            var roleslist = await _userManager.GetRolesAsync(user);

            DateTime expireon;
            var token = GenerateJwtToken(claims, out expireon);

            accountDataModel.IsAuthenticated = true;
            accountDataModel.Token = token;
            accountDataModel.Email = user.Email;
            accountDataModel.ExpiresOn = expireon;
            accountDataModel.Role = roleslist[0];

            return accountDataModel;
        }




        public async Task<AccountDataModel> Register(RegisterDto registerDto)
        {

            if (await _userManager.FindByEmailAsync(registerDto.Email) is not null)
                return new AccountDataModel { Message = "Email is already registered!" };

            if (registerDto.Password != registerDto.ConfirmPassword)
                return new AccountDataModel { Message = "password not Matche" };
            var accountDataModel = new AccountDataModel();

            if (!AllowedRoles.Contains(registerDto.Role))
                return new AccountDataModel { Message = "Invalid role." };


            var user = new ApplicationUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                Role = registerDto.Role
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                var errors = "";

                foreach (var error in result.Errors)
                    errors += $"{error.Description},";

                return new AccountDataModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, registerDto.Role);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, registerDto.Email),
                new Claim(ClaimTypes.Role, registerDto.Role)
            };
            await _userManager.AddClaimsAsync(user, claims);

            DateTime expireon;
            var token = GenerateJwtToken(claims, out expireon);


            switch (registerDto.Role)
            {
                case "Student":
                    _context.Students.Add(new Student
                    {
                        UserId = user.Id,
                        Name = registerDto.Name,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    });
                    break;

                case "Instructor":
                    _context.Instructors.Add(new Instructor
                    {
                        UserId = user.Id,
                        Name = registerDto.Name,
                        IsApproved = false,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });
                    break;

                case "Admin":
                    _context.Admins.Add(new Admin
                    {
                        UserId = user.Id,
                        Name = registerDto.Name,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    });
                    break;
            }

            await _context.SaveChangesAsync();


            return new AccountDataModel
            {
                Email = user.Email,
                ExpiresOn = expireon,
                IsAuthenticated = true,
                Token = token,
                Role = registerDto.Role
            };
        }


        private string GenerateJwtToken(IList<Claim> claims, out DateTime expireOn)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:LifeTime"])),
                signingCredentials: credentials
            );

            expireOn = token.ValidTo;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
