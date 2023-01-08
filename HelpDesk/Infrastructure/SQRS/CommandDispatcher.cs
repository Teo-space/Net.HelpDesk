namespace Infrastructure.SQRS
{
    class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider) =>
            _serviceProvider = serviceProvider;

        Task<TCommandResult> ICommandDispatcher.Dispatch<TCommand, TCommandResult>
            (TCommand command, CancellationToken cancellation)
        {
            var handler = _serviceProvider
                .GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();

            return handler.Handle(command, cancellation);
        }
    }
}
