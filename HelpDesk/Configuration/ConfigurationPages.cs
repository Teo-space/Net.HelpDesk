using Infrastructure.Filters.PageFilters;
using Infrastructure.Filters;

namespace HelpDesk.Configuration;

public static class ConfigurationPages
{
    public static void Configure(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllersWithViews(options =>
        {
			options.Filters.Add(typeof(CounterAttribute));
			//options.Filters.Add(typeof(CustomExceptionFilterAttribute));
		});

        builder.Services.AddRazorPages(options =>
        {
            options.Conventions.ConfigureFilter(new ValidatorPageFilter());
            options.Conventions.ConfigureFilter(new CounterPageFilter());

            //options.Conventions.AuthorizeFolder("/");
            //options.Conventions.AuthorizeFolder("/SupportRequest");

            //AllowAnonymousToFolder
            //AllowAnonymousToAreaFolder
            //options.Conventions.AuthorizePage("/Contact");
            //options.Conventions.AuthorizeFolder("/Private");
        })
        .AddMvcOptions(options =>
        {
			options.Filters.Add(typeof(CounterAttribute));
			//options.Filters.Add(typeof(CustomExceptionFilterAttribute));
		});

    }
}
