using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_DLL.Models.DTOs;

namespace User_DLL.Models.Extensions
{
    public class CustomAutoMapperProfile : Profile
    {
        public CustomAutoMapperProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CheckRecord, CheckRecordDTO>().ReverseMap();
        }
    }
}
