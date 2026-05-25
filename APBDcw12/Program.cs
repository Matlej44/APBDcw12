using APBDcw12.Data;
using APBDcw12.Services;
using Microsoft.EntityFrameworkCore;

namespace APBDcw12;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddScoped<IPatientService, PatientService>();
        builder.Services.AddDbContext<DatabaseFirstContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Docker"));
        });
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "v1");
            });
            app.MapOpenApi();
        }

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}