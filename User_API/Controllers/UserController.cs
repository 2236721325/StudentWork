using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_DLL.Models;
using User_DLL.Models.DTOs;
using User_DLL.Models.InputModels;
using User_Service.IServices;

namespace User_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly IMapper _Mapper;
        private readonly IValidator<User> _validator;


        public UserController(IUserService userService, IMapper mapper, IValidator<User> validator)
        {
            _UserService = userService;
            _Mapper = mapper;
            _validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody]RegisterModel user_in)
        {
            var user = _Mapper.Map<RegisterModel, User>(user_in);
            var vResult=await _validator.ValidateAsync(user);
            if (!vResult.IsValid) return BadRequest(vResult.Errors);
            await _UserService.AddAsync(user);
            return Ok("注册成功！");
        }
       
    }

}
