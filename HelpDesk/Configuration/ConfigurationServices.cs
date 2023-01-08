using DataBase.Contexts;
using FluentValidation.AspNetCore;
using FluentValidation;
using HtmlTags;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HelpDesk.Configuration;

public static class ConfigurationServices
{
    public static void Configure(this WebApplicationBuilder builder)
    {

        builder.Services.AddLogging();
        builder.Services.AddCors();

        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromHours(6);
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.Strict;
            options.Cookie.HttpOnly = true;
            //options.Cookie.IsEssential = true;
            //options.Cookie.Name = ".HelpDesk.Session";
        });

        builder.Services.AddHtmlTags();
        {
            //builder.Services.AddMemoryCache();
            //builder.Services.AddDistributedMemoryCache();
            //builder.Services.TryAddSingleton<IMemoryCache, MemoryCache>();
        }

        builder.Services.AddDbContext<DataContext>(options =>
        {
			//options.UseInMemoryDatabase("DataBase");
			options.UseSqlite($"Data Source=DataBase/SQLite/DataBase.db");
        });

        {
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

        builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

		

	}
}
