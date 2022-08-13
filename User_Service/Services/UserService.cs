using AutoMapper;
using FluentValidation;
using Shared.BaseRepositorys;
using Shared.BaseServices;
using Shared.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_DLL.Models;
using User_DLL.Models.DTOs;
using User_Service.Helps;
using User_Service.IServices;

namespace User_Service.Services
{
    public class UserService:BaseService<User>,IUserService
    {

        public UserService(IBaseRepository<User> repository) : base(repository)
        {
        
        }

             
    }

   
}
