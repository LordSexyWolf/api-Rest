using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Commander{
    public class Startup{
        
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        public IConfiguration Configuration{ get;}

        public void ConfigureServices(IServiceCollection services){
            services.AddControllers();
        }

         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //ADDED AFTER TUTORIAL
            app.UseSwagger();

            //ADDED AFTER TUTORIAL
            app.UseSwaggerUI( c=> {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Commander API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}