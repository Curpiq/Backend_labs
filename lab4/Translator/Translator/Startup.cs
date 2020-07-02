using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Translator.Data.Interfaces;
using Translator.Data.Repositories;

namespace Translator
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddRazorPages();
            services.AddScoped<IDictionaryRepository, DictionaryRepository>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage(); // ����� ������ ������
            app.UseStatusCodePages(); // ���������� ��� �������
            app.UseStaticFiles(); // ���������� css, �������� � ������
            app.UseRouting(); // ��������� �������������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "translation", pattern: "{controller=Dictionary}/{action=Translation}/{word?}"
                    );
            });

        }
    }
}
