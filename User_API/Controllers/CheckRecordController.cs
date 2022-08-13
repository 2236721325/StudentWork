using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User_DLL.Models;
using User_DLL.Models.DTOs;
using User_DLL.Models.InputModels;
using User_Service.IServices;

namespace User_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CheckRecordController : ControllerBase
    {
        private readonly ICheckRecordService _CheckRecordService;
        private readonly IMapper _Mapper;
        private readonly IValidator<CheckRecord> _validator;
        private readonly IUserService _UserService;


        public CheckRecordController(IMapper mapper, IValidator<CheckRecord> validator, ICheckRecordService checkRecordService, IUserService userService)
        {
            _Mapper = mapper;
            _validator = validator;
            _CheckRecordService = checkRecordService;
            _UserService = userService;
        }

        [HttpPost]
        [Authorize]//请求的时候需要带上JWT返回的Token// 用Postman做测试
        public async Task<ActionResult> AddCheckRecord(bool isDanger)
        {
            var id = int.Parse(this.HttpContext.User.Claims.First().Value);//获取Id
            string showStr;
            if (isDanger) showStr = "阳性";
            else showStr = "阴性";
            var idCard = (await _UserService.FindAsync(id)).IDCard;
            var checkRecord = new CheckRecord()
            {
                UserId = id,
                IsDanger = isDanger,
                Name = showStr,
                IDCard=idCard
            };
            await _CheckRecordService.AddAsync(checkRecord);
            return Ok("创建成功");
        }
        [HttpPost]
        public async Task<ActionResult> FindCheckRecordsByIDCard(string idCard, bool useTimeFilter,TimePeriod? timePeriod)
        {
            var user = (await _UserService.Query(e => e.IDCard == idCard)).FirstOrDefault();
            if (user==null) return NotFound("该身份证号对应用户不存在");
            var query = user.CheckRecords.AsQueryable();
            if(useTimeFilter)
            {
                if (timePeriod==null) return BadRequest("若开启时间段查询，时间段必须存在");
                query = query.Where(e => e.CreateTime >= timePeriod.Value.StartTime && e.CreateTime <= timePeriod.Value.EndTime);
            }
            return Ok(_Mapper.Map<IQueryable<CheckRecord>, IQueryable<CheckRecordDTO>>(query));
        }

        [HttpPost]
        public async Task<ActionResult> FindCheckRecordsByName(string Name, bool useTimeFilter, TimePeriod? timePeriod)
        {
            var user = (await _UserService.Query(e => e.Name == Name)).FirstOrDefault();
            if (user == null) return NotFound("该名称对应用户不存在");
            var query = user.CheckRecords.AsQueryable();
            if (useTimeFilter)
            {
                if (timePeriod == null) return BadRequest("若开启时间段查询，时间段必须存在");
                query = query.Where(e => e.CreateTime >= timePeriod.Value.StartTime && e.CreateTime <= timePeriod.Value.EndTime);
            }
            return Ok(_Mapper.Map<IQueryable<CheckRecord>, IQueryable<CheckRecordDTO>>(query));
        }
        [HttpPost]
        public async Task<ActionResult> FindCheckRecordsByPhoneNumber(string phoneNumber, bool useTimeFilter, TimePeriod? timePeriod)
        {
            var user = (await _UserService.Query(e => e.PhoneNumber == phoneNumber)).FirstOrDefault();
            if (user == null) return NotFound("该名称对应用户不存在");
            var query = user.CheckRecords.AsQueryable();
            if (useTimeFilter)
            {
                if (timePeriod == null) return BadRequest("若开启时间段查询，时间段必须存在");
                query = query.Where(e => e.CreateTime >= timePeriod.Value.StartTime && e.CreateTime <= timePeriod.Value.EndTime);
            }
            return Ok(_Mapper.Map<IQueryable<CheckRecord>, IQueryable<CheckRecordDTO>>(query));
        }
    }

}
