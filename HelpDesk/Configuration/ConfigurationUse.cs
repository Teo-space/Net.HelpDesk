using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Prometheus;

namespace HelpDesk.Configuration;

public static class ConfigurationUse
{
    public static void Configure(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            //app.UseMigrationsEndPoint();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            //app.UseExceptionHandler("/Error");
            app.UseExceptionHandler("Infrastructure/Error");
            app.UseHsts();// The default HSTS value is 30 days.
        }

        
        //route:health
        app.UseHealthChecks("/health", new HealthCheckOptions()
        {
            Predicate = x => true,
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });//.RequireAuthorization();

        app.UseSwagger().UseSwaggerUI();

        app.UseMiniProfiler();


        app.UseMetricsAllEndpoints().UseMetricsAllMiddleware();

        app.UseMetricServer();
        //.UseHttpMetrics();


        app.UseCookiePolicy();
        app.UseSession();



        app.UseHttpsRedirection();
        app.UseStaticFiles();


        app.UseRouting();



        app.UseAuthentication();
        app.UseAuthorization();

        //app.UseRateLimiter();

        app.MapRazorPages();
        app.MapDefaultControllerRoute();
    }
}
