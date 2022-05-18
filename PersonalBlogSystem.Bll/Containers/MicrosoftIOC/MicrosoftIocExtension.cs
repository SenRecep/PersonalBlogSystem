using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using PersonalBlogSystem.Bll.Concrete;
using PersonalBlogSystem.Bll.Interfaces;
using PersonalBlogSystem.Bll.Loggers.Serilog;
using PersonalBlogSystem.Dal.Concrete.DapperContrib.Contexts;
using PersonalBlogSystem.Dal.Concrete.DapperContrib.Repositories;
using PersonalBlogSystem.Dal.Concrete.EntityFrameworkCore.Contexts;
using PersonalBlogSystem.Dal.Interfaces;

using Serilog;

using System.Reflection;

namespace PersonalBlogSystem.Bll.Containers.MicrosoftIOC;

public static class MicrosoftIocExtension
{

    public static void AddDependencies(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("ServerConnection");
        string? migrationName = Assembly.GetCallingAssembly().FullName;


        services.AddTransient<DPDbContext>(opt => new(connectionString));

        services.AddDbContext<EFDbContext>(opt =>
            opt.UseSqlServer(connectionString, sqlOpt =>
                sqlOpt.MigrationsAssembly(migrationName)
                )
        );

        services.AddHttpContextAccessor();

        #region Repositoryies
        services.AddTransient(typeof(IGenericRepository<>), typeof(DPGenericRepository<>));
        services.AddTransient<ICategoryRepository, DPCategoryRepository>();
        services.AddTransient<IBlogRepository, DPBlogRepository>();
        #endregion
        #region Services
        services.AddTransient(typeof(IGenericService<>), typeof(GenericManager<>));
        services.AddTransient<ICategoryService, CategoryManager>();
        services.AddTransient<IBlogService, BlogManager>();

        #endregion

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }

    public static void AddValidationDependencies(this IMvcBuilder mvcBuilder)
    {
        mvcBuilder.AddFluentValidation(opt =>
            opt.RegisterValidatorsFromAssemblyContaining(typeof(MicrosoftIocExtension))
        );
    }


    public static void AddConfiguredSwaggerGen(this IServiceCollection services,Assembly assembly)
    {
        services.AddSwaggerGen(c =>
         {
             c.SwaggerDoc("v1", new OpenApiInfo
             {
                 Version = "v1",
                 Title = "Personal Blog System API",
                 Description = "Personal Blog System API",
                 TermsOfService = new Uri("https://senrecep.com"),
                 Contact = new OpenApiContact
                 {
                     Name = "Recep Şen",
                     Email = "me@senrecep.com",
                     Url = new Uri("https://senrecep.com"),
                 },
                 License = new OpenApiLicense
                 {
                     Name = "MIT",
                     Url = new Uri("https://github.com/SenRecep/PersonalBlogSystem/blob/master/LICENSE"),
                 }
             });

             // Set the comments path for the Swagger JSON and UI.
             var xmlFile = $"{assembly.GetName().Name}.xml";
             var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
             c.IncludeXmlComments(xmlPath);
         });
    }
    public static void AddConfiguredSerilog(this ILoggingBuilder logging)
    {
        logging.ClearProviders();
        logging.AddSerilog(SerilogLogConfiguration.CreateLoggerConfiguration());
    }
}
