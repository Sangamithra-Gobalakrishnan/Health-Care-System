using HealthCareAPI.Interfaces;
using HealthCareAPI.Models;
using HealthCareAPI.Models.Context;
using HealthCareAPI.Models.DTO;
using HealthCareAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HealthCareAPI
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

            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("AngularCORS", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });


            //User defined Services
            builder.Services.AddDbContext<HealthCareContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("UserCon"));
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            builder.Services.AddScoped<IManageUser<LoginDTO, DoctorDTO, PatientDTO,StatusDTO>, ManageUserService>();
            builder.Services.AddScoped<IUserRepo<User, string>,UserRepo>();
            builder.Services.AddScoped<IDoctorRepo<Doctor>, DoctorRepo>();
            builder.Services.AddScoped<IPatientRepo<Patient>, PatientRepo>();
            builder.Services.AddScoped<IDoctorDTOUserAdapter, DoctorDTOUserAdapter>();
            builder.Services.AddScoped<IPatientDTOUserAdapter, PatientDTOUserAdapter>();
            builder.Services.AddScoped<IGenerateToken<LoginDTO>, GenerateTokenService>();
            builder.Services.AddScoped<IGenerateUserId, UserIDService>();
            builder.Services.AddScoped<IFilterService<Doctor, Patient>, FilterService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AngularCORS");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}