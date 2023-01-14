using DataBase.Contexts;
using DataBase.Identity;
using DataBase.Models;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace HelpDesk.Pages.SupportRequest;


public class ShowProcessedByMeModel : PageModel
{
    private readonly IMediator mediator;
    public ShowProcessedByMeModel(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public void OnGet()
    {
    }

    public record ResultDto(Guid Id, string Name, string Description, Category Category, Status Status, string CreatorName);
 
    
    public List<ResultDto> Result { get; protected set; } = new();


    public record ShowProcessedByMeQuery(Guid Id) : IRequest<List<ResultDto>>;
    public class ShowProcessedByMeQueryValidator : AbstractValidator<ShowProcessedByMeQuery>
    {
        public ShowProcessedByMeQueryValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
        }
    }


    public record ShowProcessedByMeQueryHandler(DataContext context) : IRequestHandler<ShowProcessedByMeQuery, List<ResultDto>>
    {
        public async Task<List<ResultDto>> Handle(ShowProcessedByMeQuery request, CancellationToken token)
            => await context.SupportRequests
				.AsNoTracking()
				.Where(x => x.PerformerId == request.Id)
                .ProjectToType<ResultDto>()
                .ToListAsync();
    }

}
