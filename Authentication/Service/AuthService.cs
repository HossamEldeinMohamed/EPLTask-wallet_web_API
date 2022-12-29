
using Auth.DTO;
using Auth.IService;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnitOfWorkLayer.Interface;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Auth.IService.Service
{
    public class AuthService : IAuth
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork unitOfWork;

        private readonly IConfiguration _config;

        public AuthService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration config, ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
            _context = context;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response> Login(LoginDTO model)
        {
            var user = _context.Users.SingleOrDefault(x => x.PhoneNumber == model.Phone);
            if (user == null)
                return new Response { Code = 401, Message = "the phone number in incorrect" };

            var result = await _signInManager.PasswordSignInAsync(user.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);  
                return new Response { Code= 200 , Data = new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                }
                };
            }
            return new Response { Code = 401, Message = "Unauthorized" };
        }

        public async Task<Response> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return new Response { Code=200};
            }
            catch (Exception e)
            {
                return new Response { Code = 404 , Message = e.Message};
            }

        }

        public async Task<Response> Register(RegisterDTO model)
        {
            var ckeckEmail = await _userManager.FindByEmailAsync(model.Email);
            var ckeckPhoneNumber = _context.Users.SingleOrDefault(x => x.PhoneNumber == model.Phone);
            if (ckeckEmail != null || ckeckPhoneNumber !=null)
                return new Response { Code = 400 , Message ="Email or Phone Number was Found"};
            var user = new IdentityUser { UserName = model.Email, Email = model.Email ,PhoneNumber=model.Phone };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                Wallet wallet = new Wallet { Balance = 1000, UserId = user.Id };
                 await unitOfWork.Wallet.InsertAsync(wallet);
                unitOfWork.Save();

                await _signInManager.SignInAsync(user, isPersistent: false);
                return new Response { Code = 200 , Data = user};
            }               
            else
                return new Response { Code = 404 , Message="fail"};
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}  
