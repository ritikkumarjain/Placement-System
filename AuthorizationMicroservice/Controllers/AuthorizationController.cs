using AuthorizationMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {

        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public AuthorizationController(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        //To Add a new user
        [HttpPost("[action]")]
        public async Task<ActionResult<Login>> NewUser(LoginDetail loginDetail)
        {

            _context.LoginDetails.Add(loginDetail);
            await _context.SaveChangesAsync();

            return Ok("User Added");
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login loginUser)
        {
            string universityId = loginUser.UniversityId;
            string Password = loginUser.Password;
            var user = await _context.LoginDetails.FindAsync(universityId);
            if (user == null)
                return Ok(new { message = "Invalid Id" });
            if (user.Password == Password)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role,user.Role),
                    //new Claim(ClaimTypes.SerialNumber ,user.UniversityId)
                };
                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Issuer"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );
                var newtoken = "";
                if (user.Role == "Student")
                    newtoken = new JwtSecurityTokenHandler().WriteToken(token);
                else if (user.Role == "Coordinator")
                    newtoken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = newtoken, Identity = user.Role, University = user.UniversityId});
            }
            return Ok(new { message = "Invalid Password" });
        }
    }
}
