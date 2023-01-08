using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Infrastructure.SQRS
{

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.TryAddSingleton<IQueryDispatcher, QueryDispatcher>();

            /*
			// INFO: Using https://www.nuget.org/packages/Scrutor for registering all Query and Command handlers by convention
			services.Scan(selector =>
			{
				selector.FromCallingAssembly()
						.AddClasses(filter =>
						{
							filter.AssignableTo(typeof(IQueryHandler<,>));
						})
						.AsImplementedInterfaces()
						.WithSingletonLifetime();
			});
			services.Scan(selector =>
			{
				selector.FromCallingAssembly()
						.AddClasses(filter =>
						{
							filter.AssignableTo(typeof(ICommandHandler<,>));
						})
						.AsImplementedInterfaces()
						.WithSingletonLifetime();
			});
			*/
        }
    }





}
