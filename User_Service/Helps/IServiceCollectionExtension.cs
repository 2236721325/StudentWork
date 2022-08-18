using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.BaseRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_DLL.Contexts;
using User_DLL.IRepositorys;
using User_DLL.Models;
using User_DLL.Models.Extensions;
using User_DLL.Repositorys;
using User_Service.IServices;
using User_Service.Services;

namespace User_Service.Helps
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddUser_Service(this IServiceCollection Services)
        {
           

            //Valitor注入
            Services.AddScoped<IValidator<User>, UserValidator>();
            Services.AddScoped<IValidator<CheckRecord>, CheckRecordValidator>();
            Services.AddAutoMapper(typeof(CustomAutoMapperProfile));

            //Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));//泛型注入不要用 很坑
            Services.AddScoped<IUserRepository, UserRepository>();
            Services.AddScoped<ICheckRecordRepository, CheckRecordRepository>();
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<ICheckRecordService, CheckRecordService>();
            return Services;
        }
    }
}
