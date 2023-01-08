namespace Infrastructure.SQRS
{
    class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider) =>
            _serviceProvider = serviceProvider;

        Task<TQueryResult> IQueryDispatcher.Dispatch<TQuery, TQueryResult>
            (TQuery query, CancellationToken cancellation)
        //where TQuery : class, IQuery
        {
            var handler = _serviceProvider
                .GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
            return handler.Handle(query, cancellation);
        }
    }
}
