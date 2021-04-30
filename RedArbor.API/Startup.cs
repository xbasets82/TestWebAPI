using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using RedArbor.Process;
using RedArbor.Process.Interfaces;
using RedArbor.DAL;
using RedArbor.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.IO;

namespace RedArbor.API
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
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new Converters.DateTimeConverter());
                });
            IMapper mapper = new MapperConfiguration(mapperConfig =>{ mapperConfig.AddProfile(new Mappings.MappingProfile()); }).CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IEmployeeProcess, EmployeeProcess>();
            services.AddTransient<IEmployeeDAL, EmployeeDAL>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            loggerFactory.AddFile("Logs/mylog-{Date}.txt");
        }
    }
}
