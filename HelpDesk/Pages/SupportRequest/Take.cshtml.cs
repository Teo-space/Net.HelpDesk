using DataBase.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HelpDesk.Pages.SupportRequest.DeleteModel;

namespace HelpDesk.Pages.SupportRequest
{
    public class TakeToWorkModel : PageModel
    {
        public void OnGet()
        {
        }


        public void OnPost() 
        {
            //this.User.ClaimName()
            //User.ClaimNameIdentifier()
            //проверка логина
        }


        public record TakeToWorkCommand(Guid Id, Guid UserId, string UserName) : IRequest<Guid>;


        public class TakeToWorkCommandValidator : AbstractValidator<TakeToWorkCommand>
        {
            public TakeToWorkCommandValidator()
            {
                RuleFor(x => x.Id).NotNull().NotEmpty();
                RuleFor(x => x.UserId).NotNull().NotEmpty();
                RuleFor(x => x.UserName).NotNull().NotEmpty();
            }
        }

        /*
public DateTime? InWork { get; set; }
public DateTime? Done { get; set; }


public Guid? PerformerId { get; set; }
public Guid PerformerName { get; set; }
*/
        //this.User.ClaimName()
        //User.ClaimNameIdentifier()

        //нужно ограничение доступа

        //ѕроверка что ты тот кто создал или у теб€ есть права

        //Ќаписать тест на валидатор

        //Ќаписать тест на хендлер

        public record DeleteSupportRequestCommandHandler(DataContext context) : IRequestHandler<DeleteSupportRequestCommand, Guid>
        {
            public async Task<Guid> Handle(DeleteSupportRequestCommand request, CancellationToken token)
            {
                throw new NotImplementedException();

                var model = this.context.SupportRequests.FirstOrDefault(x => x.Id == request.Id);
                if (model != null)
                {
                    model.InWork = DateTime.Now;
                    //model.PerformerId = 
                    //model.PerformerName = User.ClaimName();

                    

                    await this.context.SaveChangesAsync(token);
                }
                return request.Id;
            }
        }

    }
}
