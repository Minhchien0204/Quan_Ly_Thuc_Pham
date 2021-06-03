using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATN.Data;
using DATN.Helpers;
using DATN.Services.BoPhanService;
using DATN.Services.ChiTietBanGiaoService;
using DATN.Services.ChiTietCungCapService;
using DATN.Services.ChiTietGiaoService;
using DATN.Services.ChiTietKiemKeService;
using DATN.Services.ChiTietYeuCauService;
using DATN.Services.DinhLuongMonAnService;
using DATN.Services.GiaoVienService;
using DATN.Services.HocSinhService;
using DATN.Services.Lop;
using DATN.Services.MonAnService;
using DATN.Services.NhaCungCapService;
using DATN.Services.NhanVienService;
using DATN.Services.PhieuAnService;
using DATN.Services.PhieuBanGiaoService;
using DATN.Services.PhieuCungCapService;
using DATN.Services.PhieuGiaoService;
using DATN.Services.PhieuKiemKeService;
using DATN.Services.PhieuYeuCauService;
using DATN.Services.ThucPhamService;
using DATN.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DATN
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //add swagger
            services.AddSwaggerGen( c => 
            {
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Quan Ly Thuc Pham", Version = "v1" });
            });
            // add mapper
            services.AddAutoMapper(typeof(Startup));
            // dk dich vu xac thuc
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Secret").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            // ket noi csdl
            services.AddDbContext<DataContext>(option =>
            {
                option.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("Connection"));
            });

            /* services.AddMvc().AddJsonOptions(options => {
                 options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
             });*/

            /* services.AddMvc().AddJsonOptions(opt =>
             {
                 opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
             });*/
            services.AddMvc();
            services.AddControllers()
             .AddNewtonsoftJson(options =>
                {
                    //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });
            services.AddScoped<IAuthoRepository, AuthRepository>();
            services.AddScoped<IGiaoVienService, GiaoVienService>();
            services.AddScoped<IHocSinhService, HocSinhService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<IBoPhanServive, BoPhanService>();
            services.AddScoped<INhanVienService, NhanVienService>();
            services.AddScoped<IThucPhamService, ThucPhamService>();
            services.AddScoped<IMonAnServiece, MonAnService>();
            services.AddScoped<IDinhLuongMAService, DinhLuongMAService>();
            services.AddScoped<IPhieuAnService, PhieuAnService>();
            services.AddScoped<IPhieuYeuCauService, PhieuYeuCauService>();
            services.AddScoped<INhaCungCapService, NhaCungCapService>();
            services.AddScoped<IPhieuCungCapService, PhieuCungCapService>();
            services.AddScoped<IPhieuGiaoService, PhieuGiaoService>();
            services.AddScoped<IPhieuBanGiaoService, PhieuBanGiaoService>();
            services.AddScoped<IPhieuKiemKeService, PhieuKiemKeService>();
            services.AddScoped<IChiTietYCService, ChiTietYeuCauService>();
            services.AddScoped<IChiTietKiemKeService, ChiTietKiemKeService>();
            services.AddScoped<IChiTietCungCapService, ChiTietCungCapService>();
            services.AddScoped<IChiTietGiaoService, ChiTietGiaoService>();
            services.AddScoped<IChiTietBanGiaoService, ChiTietBanGiaoService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quan Ly Thuc Pham");
            });

            app.UseRouting();

            app.UseCors(
                    options => options.WithOrigins("http://localhost:4201", "http://localhost:4200", "http://localhost:5000").AllowAnyMethod()
                    .AllowAnyHeader()
                    //.AllowAnyOrigin()
                    .AllowCredentials()
                );

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
