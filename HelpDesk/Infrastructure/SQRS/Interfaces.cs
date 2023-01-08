using Azure;

namespace Infrastructure.SQRS
{
    public interface IBaseRequest :
        MediatR.IBaseRequest
    {
    }
    public interface IRequest<out TResponse> :
        IBaseRequest,
        MediatR.IBaseRequest
    {
    }

    public interface IRequest :
        IRequest<MediatR.Unit>,
        MediatR.IRequest<MediatR.Unit>
    {
    }


    public interface IQuery :
        IRequest
    {
    }
    public interface IQuery<out TResponse> :
        IRequest<TResponse>
    {
    }

    public interface ICommand :
    IRequest
    {
    }
    public interface ICommand<out TResponse> :
        IRequest<TResponse>
    {
    }



    interface IQueryHandler<in TQuery, TQueryResult>
        where TQuery : IQuery
    {
        public Task<TQueryResult> Handle
            (TQuery query, CancellationToken cancellation);
    }

    interface IQueryDispatcher
    {
        public Task<TQueryResult> Dispatch<TQuery, TQueryResult>
            (TQuery query, CancellationToken cancellation)
            where TQuery : IQuery
            ;
    }

    interface ICommandHandler<in TCommand, TCommandResult>
        where TCommand : ICommand
    {
        public Task<TCommandResult> Handle
            (TCommand command, CancellationToken cancellation);
    }

    interface ICommandDispatcher
    {
        public Task<TCommandResult> Dispatch
            <TCommand, TCommandResult>(TCommand command, CancellationToken cancellation)
            where TCommand : ICommand
            ;
    }
}
