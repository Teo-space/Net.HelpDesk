using DataBase.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HelpDesk.Pages.SupportRequest.ShowAllModel;
using static HelpDesk.Pages.SupportRequest.ShowCreatedByMeModel;

namespace HelpDesk.Pages.SupportRequest
{
    public class DetailModel : PageModel
    {
        private readonly IMediator mediator;
        public DetailModel(IMediator mediator) => this.mediator = mediator;

        public async Task OnGet(Guid Id) => Result = await mediator.Send(new DetailQuery(Id));

        public DataBase.Models.SupportRequest Result { get; set; }



        public record DetailQuery(Guid Id) : IRequest<DataBase.Models.SupportRequest>;
        public class DetailQueryValidator : AbstractValidator<DetailQuery>
        {
            public DetailQueryValidator()
            {
                RuleFor(x => x.Id).NotNull();
            }
        }


        public class QueryHandler : IRequestHandler<DetailQuery, DataBase.Models.SupportRequest>
        {
            private readonly DataContext context;
            public QueryHandler(DataContext context) => this.context = context;

            public async Task<DataBase.Models.SupportRequest?> Handle(DetailQuery request, CancellationToken token)
            {
                return await context.SupportRequests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.Id, token);
            }
        }
    }
}
