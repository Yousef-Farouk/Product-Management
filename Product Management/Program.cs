using Microsoft.EntityFrameworkCore;
using Product_Management.Models;
using Product_Management.Repository;
using Product_Management.Service;
using Product_Management.UnitOfWorks;

namespace Product_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<ProductManagementContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")).UseLazyLoadingProxies();
            });

            builder.Services.AddScoped<UnitOfWork>();

            builder.Services.AddScoped<ProductService>();

            builder.Services.AddScoped<ClientService>();

            //builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
