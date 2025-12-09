using Microsoft.Data.SqlClient;
using System.Data.Common;
using ibll = Movie.BLL.Repositories;
using bll = Movie.BLL.Services;
using idal = Movie.DAL.Repositories;
using dal = Movie.DAL.Services;

namespace Movie.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Appelle d'accès au fichier de configuration
            IConfiguration Configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Definir les instances de dépendances qui seront distribué dans les services qui en ont besoin
            builder.Services.AddScoped<DbConnection>(sp => new SqlConnection(Configuration.GetConnectionString("TechnoMovie.Database")));
            builder.Services.AddScoped<idal.IFilmRepository, dal.FilmService>();
            builder.Services.AddScoped<ibll.IFilmRepository, bll.FilmService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
