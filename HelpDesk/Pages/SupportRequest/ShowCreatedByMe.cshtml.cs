using Extensions;
using DataBase.Contexts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataBase.Models;
using FluentValidation;
using DataBase.Identity;
using Mapster;

namespace HelpDesk.Pages.SupportRequest
{
    public class ShowCreatedByMeModel : PageModel
	{
		private readonly IMediator mediator;
		private readonly SignInManager<AppIdentityUser> signInManager;
		private readonly UserManager<AppIdentityUser> UserManager;
        private readonly ILogger<ShowCreatedByMeModel> logger;
        public ShowCreatedByMeModel(
			IMediator mediator, 
			SignInManager<AppIdentityUser> signInManager,
            UserManager<AppIdentityUser> UserManager,
            ILogger<ShowCreatedByMeModel> logger)
		{
            this.mediator = mediator;
			this.signInManager = signInManager;
			this.UserManager = UserManager;
			this.logger = logger;
            //UserManager.GetUserId(User) ?? User.ClaimNameIdentifier()
        }

        public async Task OnGet()
		{
            var guid = Guid.Parse(User.ClaimNameIdentifier());
			Result = await mediator.Send(new ShowCreatedByMeQuery(guid));
            //string email = User.ClaimEmail();
            //Result = await mediator.Send(new ShowCreatedByMeQuery(email));
        }

        public record ResultDto(Guid CreatorId, string Name, string Description, Category Category, Status Status, string CreatorName);
        public List<ResultDto> Result { get; protected set; } = new();


        //public record ShowCreatedByMeQuery(string Email) : IRequest<List<DataBase.Models.SupportRequest>>;
        public record ShowCreatedByMeQuery(Guid UserId) : IRequest<List<ResultDto>>;
        public class ShowCreatedByMeQueryValidator : AbstractValidator<ShowCreatedByMeQuery>
        {
            public ShowCreatedByMeQueryValidator()
            {
                RuleFor(x => x.UserId).NotNull();
            }
        }


        public class ShowCreatedByMeQueryHandler : IRequestHandler<ShowCreatedByMeQuery, List<ResultDto>>
		{
			private readonly DataContext context;
			public ShowCreatedByMeQueryHandler(DataContext context)
			{
				this.context = context;
			}

			public async Task<List<ResultDto>>Handle(ShowCreatedByMeQuery request, CancellationToken token) 
                => await context.SupportRequests
                .AsNoTracking()
                .Where(x => x.CreatorId == request.UserId)
                //.Where(x => x.CreatorEmail == request.Email)
                .ProjectToType<ResultDto>()
                .ToListAsync(token);

        }

	}
}
