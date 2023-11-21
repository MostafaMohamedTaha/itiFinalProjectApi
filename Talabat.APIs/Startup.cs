#region imports
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using Talabat.APIs.Extensions;
using Talabat.APIs.Middlewares;
using Talabat.Repository.Data;
using Talabat.Repository.Identity;

#endregion

namespace Talabat.APIs
{
    public class Startup
    {
        #region ctor

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        #endregion

        #region services
        public void ConfigureServices(IServiceCollection services)
        {
            #region services standard

            services.AddControllers();
            services.AddSwaggerServices();
            services.AddApplicationServices();
            #endregion

            #region db

            services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region singleton

            services.AddSingleton<IConnectionMultiplexer>(S =>
            {
                var connection = ConfigurationOptions.Parse(Configuration.GetConnectionString("Redis"));
                return ConnectionMultiplexer.Connect(connection);
            });
            #endregion

            #region identity

            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"));
            });
            services.AddIdentityServices(Configuration);
            services.AddCors(
                options =>
                {
                    options.AddPolicy("CorsPolicy", Policy => Policy.AllowAnyOrigin()
                                                                   .AllowAnyHeader()
                                                                   .AllowAnyMethod()
                                                                   .SetIsOriginAllowed(origin => true));
                });
            #endregion

        }
        #endregion

        #region middle wares
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region middle wares env

            app.UseMiddleware<ExceptionMiddleware>();
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwaggerDocumentation();
            }
            #endregion

            #region standard middle wares
            app.UseHttpsRedirection();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseStaticFiles();
            app.UseRouting();

            #endregion

            #region new middle wares
            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion
        }
        #endregion

    }
}
