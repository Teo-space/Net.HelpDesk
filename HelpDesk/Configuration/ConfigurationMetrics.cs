using Infrastructure.Filters.PageFilters;
using Infrastructure.Filters;
using DataBase.Contexts;

namespace HelpDesk.Configuration
{
    public static class ConfigurationMetrics
    {
        public static void Configure(this WebApplicationBuilder builder)
        {
            ConfigureMiniProfiler(builder);
			ConfigureMetrics(builder);


            builder.Services
                .AddHealthChecks()
                .AddDbContextCheck<DataContext>();
            
            builder.Services.AddSwaggerGen();
        }

        public static void ConfigureMiniProfiler(WebApplicationBuilder builder)
        {
            builder.Services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.TrackConnectionOpenClose = true;
                options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;

                options.EnableMvcFilterProfiling = true;
                options.MvcFilterMinimumSaveMs = 1.0m;
                options.EnableMvcViewProfiling = true;

            })
            .AddEntityFramework();
        }

        public static void ConfigureMetrics(WebApplicationBuilder builder)
        {
			builder.Services.AddMetrics();
			builder.Services.AddMetricsEndpoints(config =>
			{
				config.MetricsEndpointEnabled = true;
				config.MetricsTextEndpointEnabled = true;
			});
			builder.Services.AddMetricsTrackingMiddleware();
			builder.Services.AddMetricsReportingHostedService();
		}




    }
}
