using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using uni_project.Core.Entity.AuthModel;
using uni_project.Core.Entity.ReturnModels;
using uni_project.Core.Entity.ReturnModels.MessageModel;

namespace uni_project.Repositrory.AuthRepository
{
    public class AuthRepository
    {
        private readonly IConfiguration _configuration;
        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GenerateToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebTokenConfig:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["JsonWebTokenConfig:issuer"],
                audience: _configuration["JsonWebTokenConfig:audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public BaseResponseModel Login(AuthUserPassModel authmodel)
        {
            if(authmodel != null && authmodel.Username == "admin" && authmodel.Password == "@dmIn")
            {
                string token = GenerateToken(authmodel.Username);
                return new BaseResponseModel(true, new AuthResponseModel(token,"ورود با موفقیت انجام شد."));
            }
            else
            {
                return new BaseResponseModel(false, new MessageModel("اطلاعات وارد شده نادرست می باشد."));
            }
        }
    }
}
