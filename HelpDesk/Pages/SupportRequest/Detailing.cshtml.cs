using DataBase.Contexts;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HelpDesk.Pages.SupportRequest.ShowAllModel;
using static HelpDesk.Pages.SupportRequest.ShowCreatedByMeModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HelpDesk.Pages.SupportRequest
{
	public class DetailModel : PageModel
	{
		private readonly IMediator mediator;
		public DetailModel(IMediator mediator) => this.mediator = mediator;


		public async Task OnGet(Guid Id) => GetResult = await mediator.Send(new DetailQuery(Id));


		public ResultDto GetResult { get; set; }

		public record ResultDto(Guid Id, string CreatorName, string CreatorEmail, DateTime Created, string Name, string Description, Category Category, Status Status);

		public record DetailQuery(Guid Id) : IRequest<ResultDto>;

		public class DetailQueryValidator : AbstractValidator<DetailQuery>
		{
			public DetailQueryValidator()
			{
				RuleFor(x => x.Id).NotNull();
			}
		}


		public class QueryHandler : IRequestHandler<DetailQuery, ResultDto>
		{
			private readonly DataContext context;
			public QueryHandler(DataContext context) => this.context = context;

			public async Task<ResultDto?> Handle(DetailQuery request, CancellationToken token)
			{
				return (await context.SupportRequests
					.AsNoTracking()
					.FirstOrDefaultAsync(x => x.Id == request.Id, token))
				?.Adapt<ResultDto>();
			}
		}








		public async Task OnPost() => GetResult = await mediator.Send(SetDescription);

		[BindProperty]
		public SetDescriptionCommand SetDescription { get; set; }

		public record SetDescriptionCommand(Guid Id, string Description) : IRequest<ResultDto>;

		public class SetDescriptionCommandValidator : AbstractValidator<SetDescriptionCommand>
		{
			public SetDescriptionCommandValidator()
			{
				RuleFor(x => x.Id).NotNull();
				RuleFor(x => x.Description).NotNull();
			}
		}
		public class SetDescriptionCommandHandler : IRequestHandler<SetDescriptionCommand, ResultDto>
		{
			private readonly DataContext context;
			public SetDescriptionCommandHandler(DataContext context) => this.context = context;

			public async Task<ResultDto?> Handle(SetDescriptionCommand request, CancellationToken token)
			{
				var supportRequest = await context.SupportRequests.FirstOrDefaultAsync(x => x.Id == request.Id, token);
				supportRequest.Description = request.Description;
				await context.SaveChangesAsync(token);
				return supportRequest.Adapt<ResultDto>();
			}
		}




	}
}
