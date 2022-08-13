using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User_Service.Helps;
using User_Service.IServices;

namespace JWT_API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class JWTLoginController : ControllerBase
    {
        private readonly JWTSettings jwtSettings;
        private readonly IUserService userService;

        public JWTLoginController(IOptions<JWTSettings> jwtSettings, IUserService userService)
        {
            this.jwtSettings = jwtSettings.Value;
            this.userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult> Login(string userName, string userPwd)
        {
            var innerPwd = MD5Helper.MD5Encrypt32(userPwd);
            var user = (await userService.Query(u => u.UserName == userName && u.UserPwd == innerPwd)).FirstOrDefault();
            if (user == null) return NotFound("账号或密码错误！");
            List<Claim> claims = new List<Claim>()//不要放太多东西 数据的传输也是耗时的
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            DateTime expirationTime = DateTime.Now.AddHours(jwtSettings.ExpirationHour);
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);
            var jwtToken = new JwtSecurityToken(issuer: jwtSettings.Issuer, audience: jwtSettings.Audience, claims: claims, expires: expirationTime, signingCredentials: credentials);
            string jwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Ok(jwt);
        }
    }

}
