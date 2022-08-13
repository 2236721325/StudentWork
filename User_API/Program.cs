using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.BaseRepositorys;
using Shared.BaseServices;
using System.Text;
using User_API.JWTs;
using User_DLL.Contexts;
using User_DLL.IRepositorys;
using User_DLL.Models;
using User_DLL.Models.Extensions;
using User_DLL.Repositorys;
using User_Service.IServices;
using User_Service.Services;

namespace User_API
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

            builder.Services.AddScoped<DbContext, UserDbContext>();//表明MyDbContext是DbContext的具体实现
            //JWT 验证 这些api要求登录状态下可访问
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //配置JWT身份验证方案
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //使用JWT身份验证挑战

            }).AddJwtBearer(option =>
            {
                var jwtSettings = builder.Configuration.GetSection("JWT").Get<JWTSettings>();

                byte[] keyBytes = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
                var secretKey = new SymmetricSecurityKey(keyBytes);
                //验证的配置添加
                option.TokenValidationParameters = new()
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = secretKey
                };

            });

            //Valitor注入
            builder.Services.AddScoped<IValidator<User>, UserValidator>();
            builder.Services.AddScoped<IValidator<CheckRecord>, CheckRecordValidator>();
            //AutoMapper
            builder.Services.AddAutoMapper(typeof(CustomAutoMapperProfile));

            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ICheckRecordRepository, CheckRecordRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ICheckRecordService, CheckRecordService>();



            var app = builder.Build();
            
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthentication();//验证是否登录 的中间件
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

       
    }
}