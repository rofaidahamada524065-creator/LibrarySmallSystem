
using LibrarySmallSystem.Data;
using LibrarySmallSystem.Mapping;
using LibrarySmallSystem.Repos.Impelementation;
using LibrarySmallSystem.Repos.Interface;
using LibrarySmallSystem.UnitOfWorkk;
using Microsoft.EntityFrameworkCore;

namespace LibrarySmallSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
            });
            builder.Services.AddAutoMapper(typeof(MappingProfail));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICategoryCustom, CatigoryCustom>();
            builder.Services.AddScoped<IBookCustom, BookCustom>();
            
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
