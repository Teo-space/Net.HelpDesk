using FluentValidation;
using DataBase.Contexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataBase.Models;
using Mapster;


namespace HelpDesk.Pages.SupportRequest;

public class ShowAllModel : PageModel
{
	private readonly IMediator mediator;
	public ShowAllModel(IMediator mediator) => this.mediator = mediator;


	public async Task OnGet() => Result = await mediator.Send(new ShowAllQuery());


	public record ResultDto(Guid Id, string Name, string Description, Category Category, Status Status, string CreatorName);

    public List<ResultDto> Result { get; protected set; } = new();


    public record ShowAllQuery() : IRequest<List<ResultDto>>;


    public record ShowAllQueryHandler(DataContext context) : IRequestHandler<ShowAllQuery, List<ResultDto>>
	{
		public async Task<List<ResultDto>> Handle(ShowAllQuery request, CancellationToken token)
			=> await context.SupportRequests
			.AsNoTracking()
			.ProjectToType<ResultDto>()
			.ToListAsync(token);

	}
}
