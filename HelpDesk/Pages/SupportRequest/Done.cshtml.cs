using DataBase.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HelpDesk.Pages.SupportRequest.DeleteModel;

namespace HelpDesk.Pages.SupportRequest
{
    public class DoneModel : PageModel
    {
        public void OnGet()
        {
        }


        public void OnPost() 
        {
        }


        public record MarkAsDoneCommand(Guid Id) : IRequest<Guid>;


        public class MarkAsDoneCommandValidator : AbstractValidator<MarkAsDoneCommand>
        {
            public MarkAsDoneCommandValidator()
            {
                RuleFor(x => x.Id).NotNull().NotEmpty();
            }
        }
        /*
		public DateTime? InWork { get; set; }
		public DateTime? Done { get; set; }


		public Guid? PerformerId { get; set; }
        public Guid PerformerName { get; set; }
        */
        public record MarkAsDoneCommandHandler(DataContext context) : IRequestHandler<MarkAsDoneCommand, Guid>
        {
            public async Task<Guid> Handle(MarkAsDoneCommand request, CancellationToken token)
            {
                throw new NotImplementedException();

                var model = this.context.SupportRequests.FirstOrDefault(x => x.Id == request.Id);
                if (model != null)
                {
                    //ѕроверка - ты исполнитель либо у теб€ есть права мен€ть и удал€ть за€вки

                    model.Done = DateTime.Now;
                    await this.context.SaveChangesAsync(token);
                }
                return request.Id;
            }
        }
        //нужно ограничение доступа

        //ѕроверка - ты исполнитель либо у теб€ есть права мен€ть и удал€ть за€вки

        //Ќаписать тест на валидатор

        //Ќаписать тест на хендлер

    }
}
