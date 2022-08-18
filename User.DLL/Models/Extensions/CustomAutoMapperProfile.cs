using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_DLL.Models.DTOs;
using User_DLL.Models.InputModels;

namespace User_DLL.Models.Extensions
{
    public class CustomAutoMapperProfile : Profile
    {
        public CustomAutoMapperProfile()
        {
            CreateMap<CheckRecord, UserDTO>().ReverseMap();
            CreateMap<CheckRecord, CheckRecordDTO>().ReverseMap();
            CreateMap<RegisterModel, User>().ReverseMap();
        }
    }
}
