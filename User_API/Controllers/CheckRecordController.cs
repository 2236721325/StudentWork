using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Authorize]
        public async Task<ActionResult> FindMyCheckRecord()
        {
            var id = int.Parse(this.HttpContext.User.Claims.First().Value);//获取Id
            var checks = await (await _CheckRecordService.Query(e => e.UserId == id)).ToListAsync();
            if (checks == null || checks.Count == 0) return NotFound("id不存在或者该id不存在打卡记录");
            return Ok(_Mapper.Map<List<CheckRecord>, List<CheckRecordDTO>>(checks));
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> FindMyLastCheckRecord()
        {
            var id = int.Parse(this.HttpContext.User.Claims.First().Value);//获取Id
            var check = (await _CheckRecordService.Query(e => e.UserId == id)).OrderBy(e => e.Id).LastOrDefault();
            if (check == null) return NotFound("id不存在或者 该id不存在打卡记录");
            return Ok(_Mapper.Map<CheckRecord, CheckRecordDTO>(check));
        }

        [HttpPost]
        [Authorize]//请求的时候需要带上JWT返回的Token// 用Postman做测试 //已经登陆状态下 就不需要别的参数
        public async Task<ActionResult> Add(bool isDanger)
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
                IDCard = idCard
            };
            var r = _validator.Validate(checkRecord);
            if (!r.IsValid) return BadRequest(r.Errors.Select(e=>e.ErrorMessage));
            await _CheckRecordService.AddAsync(checkRecord);
            return Ok("创建成功");
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddByIdCard(bool isDanger, string idCard)
        {
            string showStr;
            if (isDanger) showStr = "阳性";
            else showStr = "阴性";
            var user = (await _UserService.Query(e => e.IDCard == idCard)).FirstOrDefault();
            if (user == null) return NotFound();

            var checkRecord = new CheckRecord()
            {
                UserId = user.Id,
                IsDanger = isDanger,
                Name = showStr,
                IDCard = idCard
            };
            var r = _validator.Validate(checkRecord);
            if (!r.IsValid) return BadRequest(r.Errors);
            await _CheckRecordService.AddAsync(checkRecord);
            return Ok("创建成功");
        }


        [HttpPost]
        public async Task<ActionResult> FindByIDCard(string idCard)
        {
            var checks = (await _CheckRecordService.Query(e => e.IDCard == idCard)).ToList();
            if (checks == null || checks.Count() == 0) return NotFound("该身份证号对应用户不存在");
            return Ok(_Mapper.Map<List<CheckRecord>, List<CheckRecordDTO>>(checks));
        }
        [HttpPost]
        public async Task<ActionResult> FindByIDCard_startTimeFilter(string idCard, TimePeriod timePeriod)
        {
            var checks = (await _CheckRecordService.Query(e => e.IDCard == idCard))
                .Where(e => e.CreateTime >= timePeriod.StartTime && e.CreateTime <= timePeriod.EndTime).ToList();

            if (checks == null || checks.Count() == 0) return NotFound();
            return Ok(_Mapper.Map<List<CheckRecord>, List<CheckRecordDTO>>(checks));
        }
        [HttpPost]
        public async Task<ActionResult> FindByName(string name)
        {
            var r = (await _UserService.Query(e => e.Name.Contains(name)))
                .Include(e => e.CheckRecords)
                .Select(e => new { name = e.Name,id=e.Id, checkRecords = e.CheckRecords.Select(e => new { e.Id, e.Name, e.CreateTime, e.IDCard }) }) ;
            if (r == null || r.Count() == 0) return NotFound("该名称对应用户不存在");
            return Ok(r);
        }
        [HttpPost]//Linq 真是个好东西
        public async Task<ActionResult> FindByName_startTimeFilter(string name, TimePeriod timePeriod)
        {
            var checks = (await _UserService.Query(e =>e.Name.Contains(name))).Include(e => e.CheckRecords)
                .Select(e => new
                {
                    name = e.Name,
                    id=e.Id,
                    checkRecords = e.CheckRecords
                    .Where(e => e.CreateTime >= timePeriod.StartTime && e.CreateTime <= timePeriod.EndTime)
                    .Select(e => new
                    {
                        e.Id,
                        e.Name,
                        e.CreateTime,
                        e.IDCard
                    })
               });

            if (checks == null || checks.Count() == 0) return NotFound();
            return Ok(checks);
        }
        [HttpPost]
        public async Task<ActionResult> FindByPhoneNumber(string phoneNumber)
        {
            var r = (await _UserService.Query(e => e.PhoneNumber == phoneNumber)).Include(e => e.CheckRecords)
                .Select(e => new { phoneNumber = e.PhoneNumber,id=e.Id, checkRecords = e.CheckRecords.Select(e => new { e.Id ,e.Name, e.CreateTime, e.IDCard }) });
            if (r == null || r.Count() == 0) return NotFound("该电话号码对应用户不存在");
            return Ok(r);
        }
        [HttpPost]
        public async Task<ActionResult> FindByPhoneNumber_startTimeFilter(string phoneNumber, TimePeriod timePeriod)
        {
            var checks = (await _UserService.Query(e => e.PhoneNumber == phoneNumber)).Include(e => e.CheckRecords)
                .Select(e => new
                {
                    phoneNumber = e.PhoneNumber,
                    id=e.Id,
                    checkRecords = e.CheckRecords
                    .Where(e => e.CreateTime >= timePeriod.StartTime && e.CreateTime <= timePeriod.EndTime)
                    .Select(e => new
                    {
                        e.Id,
                        e.Name,
                        e.CreateTime,
                        e.IDCard
                    })
                });

            if (checks == null || checks.Count() == 0) return NotFound();
            return Ok(checks);
        }

    }

}
