using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.BaseRepositorys;
using Shared.BaseServices;
using System.Text;
using User_DLL.Contexts;
using User_DLL.IRepositorys;
using User_DLL.Models;
using User_DLL.Models.Extensions;
using User_DLL.Repositorys;
using User_Service.Helps;
using User_Service.IServices;
using User_Service.Services;

namespace JWT_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(
               builder.Configuration.GetConnectionString("DefaultConnection"), x =>
               x.MigrationsAssembly("User_DLL")//迁移存放在User_DLL
               ));
            //JWT
            builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("JWT"));//也是依赖注入 注入的时候带有默认值（appsettings读取）
            

            builder.Services.AddUser_Service();//自己写的拓展方法


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();


            app.MapControllers();



            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.Run();
        }
    }
}