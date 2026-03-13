using Ecom.BLL.Managers.CategoryManager;
using Ecom.BLL.Managers.ProductManager;
using Ecom.DAL.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Ecom.DAL.Repositories.CategoryRepository;
using WebApplication2.Ecom.DAL.Repositories.ProductRepository;

namespace Ecom.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                throw new InvalidOperationException("connection string 'DefualtConnection' was not found !!");

            builder.Services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });


            builder.Services.AddScoped<ICategoryManager, CategoryManager>();
            builder.Services.AddScoped<IProductManager,ProductManager>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
