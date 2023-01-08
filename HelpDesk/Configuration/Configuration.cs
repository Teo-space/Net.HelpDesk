namespace HelpDesk.Configuration;

public static class Configuration
{
    public static void ConfigureAll(this WebApplicationBuilder builder)
    {
        ConfigurationIdentity.Configure(builder);
        //ConfigurationRateLimiter.Configure(builder);
        ConfigurationServices.Configure(builder);

        ConfigurationMetrics.Configure(builder);
        ConfigurationPages.Configure(builder);




        var app = builder.Build();
        ConfigurationUse.Configure(app);
        app.Run();
    }


}
