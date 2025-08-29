namespace SampleMvcApp
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            Program.Configuration = app.Configuration;
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Customer}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
