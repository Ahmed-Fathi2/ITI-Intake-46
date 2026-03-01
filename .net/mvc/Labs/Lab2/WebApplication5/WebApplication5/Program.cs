namespace WebApplication5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();


            app.Use(async (HttpContext, next) =>
            {
                //await HttpContext.Response.WriteAsync(" 1) hello \n");
                Console.WriteLine("middel one before");


                await next.Invoke();

                Console.WriteLine("middel one after");

                //await HttpContext.Response.WriteAsync(" 2) hello \n");

            });

            app.Use(async (HttpContext, next) =>
            {
                //await HttpContext.Response.WriteAsync(" 3) hello \n");

                Console.WriteLine("middel two before");

                await next.Invoke();

                Console.WriteLine("middel two after");

                //await HttpContext.Response.WriteAsync(" 4) hello \n");

            });

            //app.Run(async (HttpContext) =>
            //{
            //    await HttpContext.Response.WriteAsync(" 5) hello \n");
            //});

            //// Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}
            //app.UseRouting();
            //app.UseSession();

            //app.UseAuthorization();

            app.MapStaticAssets();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
