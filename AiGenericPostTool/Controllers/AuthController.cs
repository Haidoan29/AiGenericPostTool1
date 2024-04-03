using AiGenericPostTool.DataTransferObject.AuthDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AiGenericPostTool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public AuthController(UserManager<IdentityUser> userManager, IHttpContextAccessor contextAccessor, SignInManager<IdentityUser> signInManager)
        {

            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
            _userManager = userManager;


        }

        //Dang nhap
        [HttpPost]
        [Route("doLogin")]
        public async Task<IActionResult> doLogin(DoLoginRequest request)
        {
            if (request != null)
            {
                //Tien hanh login
                var currentUser = await _userManager.FindByNameAsync(request.username);
                if (currentUser != null)
                {
                    var checkSingin = await _signInManager.PasswordSignInAsync(currentUser, request.password, false, false);
                    if (checkSingin.Succeeded)
                    {
                        //Generate token
                        var token = this.GenerateToken(currentUser.UserName);
                        dynamic response = new ExpandoObject();
                        response.token = token;
                        return Ok(response);

                    }
                }
            }
            return BadRequest("Login fail!");
        }

        //Dang ky
        [HttpPost]
        [Route("doRegister")]
        public async Task<IActionResult> doRegister(DoLoginRequest request)
        {
            if (request != null)
            {
                //Tien hanh kiem tra xem co user trung chua
                var currentUser = await _userManager.FindByNameAsync(request.username);
                if (currentUser == null)
                {

                    var newUser = await _userManager.CreateAsync(new IdentityUser(request.username), request.password);
                    if (newUser.Succeeded)
                    {
                        currentUser = await _userManager.FindByNameAsync(request.username);
                        //Generate token
                        if (currentUser != null)
                        {
                            var token = this.GenerateToken(currentUser.UserName);
                            dynamic response = new ExpandoObject();
                            response.token = token;
                            return Ok(response);

                        }

                    }
                }
            }
            return BadRequest("Register fail!");
        }

        //Generate Token

        private string GenerateToken(string username)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            // Các thông tin khác có thể thêm vào đây
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("V29ya2luZyBpcyBteSBwYXNzd29yZA=="));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "your_issuer",
                audience: "your_audience",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), // Thời gian hết hạn của token
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
