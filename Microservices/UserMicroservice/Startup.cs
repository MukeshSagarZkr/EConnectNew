using Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using UserMicroservice.Repository;
using WebApi.Helpers;

namespace UserMicroservice
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		// add services to the DI container
		public void ConfigureServices(IServiceCollection services)
		{
		  
			services.AddCors();
			services.AddControllers();

			// configure strongly typed settings object
			services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
			// configure DI for application services

			services.AddScoped<ILoginService, LoginService>();
			
			//services.AddMvc().AddWebApiConventions();

			//services.Configure<FormOptions>(options =>
			//{
			//    options.ValueCountLimit = 100000; //default 1024
			//    options.ValueLengthLimit = int.MaxValue; //not recommended value
			//    options.MultipartBodyLengthLimit = long.MaxValue; //not recommended value
			//    options.MemoryBufferThreshold = Int32.MaxValue;
			//});
			//services.AddMvc(options =>
			//{
			//    options.MaxModelBindingCollectionSize = int.MaxValue;
			//});

		}

		// configure the HTTP request pipeline
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseRouting();

			// global cors policy
			app.UseCors(x => x
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());

			// custom jwt auth middleware
			app.UseMiddleware<JwtMiddleware>();
		  //  app.UseMiddleware<RequestLoggingMiddleware>();
			app.UseEndpoints(x => x.MapControllers());
		   
		}
	}
}
