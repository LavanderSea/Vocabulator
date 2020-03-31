using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using VocabulatorLibrary;
using VocabulatorLibrary.Data;
using VocabulatorWeb.Serializers;
using Dictionaries = VocabulatorLibrary.Dictionaries;


namespace VocabulatorWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            var userFacades = new Dictionary<DictionaryVersion, UserFacade>
            {
                {
                    DictionaryVersion.Test,
                    new UserFacade(
                        new Dictionaries.Stub.DictionaryClient())
                },
                {
                    DictionaryVersion.MerriamWebster,
                    new UserFacade(
                        new Dictionaries.MerriamWebster.DictionaryClient(
                            new Dictionaries.MerriamWebster.ResponseParser()))
                },
                {
                    DictionaryVersion.WordApi,
                    new UserFacade(
                        new Dictionaries.WordApi.DictionaryClient(
                            new Dictionaries.WordApi.ResponseParser()))
                }
            };

            services.AddSingleton(provider => new UserFacadeFactory(userFacades));
            services.AddSingleton<IDeserializer<IEnumerable<Word>>>(provider => new RequestDeserializer());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}