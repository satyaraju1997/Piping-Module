using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Piping.Contracts.Services;
using Piping.DTO;
using System;
using System.Collections.Generic;
using AutoMapper;
using Serilog;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Piping.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Piping.Helper;

namespace Piping.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [EnableCors("TempCorsPolicy")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _config;
        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger, IConfiguration config)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
            _config = config;
        }

        [HttpPost("register")] //<host>/api/auth/register
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            // validate request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_userService.UserExists(userRegisterDTO.Username.ToLower()))
                return BadRequest("Username is already taken");

            var createUser = _userService.Register(userRegisterDTO);

            return StatusCode(201);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDto)
        {
            
            UserDetailDTO user = _userService.Login(userLoginDto.Username);
            if (user == null) //User login failed
            {
                _logger.LogDebug("User login failed");
                return Unauthorized();
            }
            Piping.Helper.PasswordHasher ph = new Piping.Helper.PasswordHasher();
            bool validPwd = ph.Check(user.PasswordHash, userLoginDto.Password);

            if (validPwd)
            {
                //  string pwd = ph.Hash(userLoginDto.Password);
                //generate token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["JwtToken:SecretKey"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,user.UserID.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)  ,
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                HttpContext.Session.SetString("ID", user.Username);

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                user.Token = tokenString;

                return Ok(user);
            }

            return Unauthorized();
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] UserLoginDTO userLoginDto)
        {
            _userService.Logout(userLoginDto.Username);
            return Ok();
        }

        [HttpPost("resetpasswordbyusername")]
        public async Task<IActionResult> ResetPasswordByUsername(string Username)
        {
            _userService.ResetPasswordByUsername(Username);
            return Ok();
        }

        [HttpPost("resetpasswordbyemail")]
        public async Task<IActionResult> ResetPasswordByEmail(string Email)
        {
            _userService.ResetPasswordByEmail(Email);
            return Ok();
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword([FromBody] UserPasswordDTO userPasswordDTO)
        {
            _userService.ChangePassword(userPasswordDTO);
            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("GetToken")]
        public async Task<IEnumerable<string>> GetToken()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            return new string[] { accessToken };
        }

        [HttpGet("GetTopMenu")]
        public List<MenuDTO> GetTopMenu(int UserID)
        {
            return _userService.GetTopMenu(UserID);
        }

        [HttpGet("GetQuickLink")]
        public List<QuickLinkDTO> GetQuickLink(int UserID)
        {
            return _userService.GetQuickLink(UserID, 12);
        }

        [HttpGet("GetPlantMenu")]
        public List<MenuDTO> GetPlantMenu(int CompanyID)
        {
            return _userService.GetPlantMenu(CompanyID);
        }

        [HttpGet("GetPipeMasterMenu")]
        public List<MenuDTO> GetPipeMasterMenu(int CompanyID)
        {
            return _userService.GetPipeMasterMenu(CompanyID);
        }       

        [HttpGet("GetLeftMenu")]
        public List<MenuDTO> GetLeftMenu(int CompanyID)
        {
            return _userService.GetLeftMenu(CompanyID);
        }
        [HttpGet("GetFileContent")]
        public byte[] GetFileContent(string filePath)
        {
            return Piping.Common.Utility.ConvertImageToByteArray(filePath);
        }

        [HttpGet("GetPipeMasterNextMenu")]
        public MenuDTO GetPipeMasterNextMenu(int UnitID)
        {
            return _userService.GetPipeMasterNextMenu(UnitID);
        }

        [HttpGet("GetPipeMasterPreviousMenu")]
        public MenuDTO GetPipeMasterPreviousMenu(int UnitID)
        {
            return _userService.GetPipeMasterPreviousMenu(UnitID);
        }

        [HttpGet("GetPipeMasterCurrentMenu")]
        public MenuDTO GetPipeMasterCurrentMenu(int UnitID)
        {
            return _userService.GetPipeMasterCurrentMenu(UnitID);
        }



    }
}
