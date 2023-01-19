using DataBase.Contexts;
using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static HelpDesk.Pages.SupportRequest.CreateModel;

namespace HelpDesk.Pages.SupportRequest
{
    public class DeleteModel : PageModel
    {
        public void OnGet()
        {
        }


        public async Task OnPost() 
        { 

        }


        public record DeleteSupportRequestCommand(Guid Id) : IRequest<Guid>;


        public class DeleteSupportRequestCommandValidator : AbstractValidator<DeleteSupportRequestCommand>
        {
            public DeleteSupportRequestCommandValidator()
            {
                RuleFor(x => x.Id).NotNull().NotEmpty();
            }
        }


        public record DeleteSupportRequestCommandHandler(DataContext context) : IRequestHandler<DeleteSupportRequestCommand, Guid>
        {
            public async Task<Guid> Handle(DeleteSupportRequestCommand request, CancellationToken token)
            {
                var model = this.context.SupportRequests.FirstOrDefault(x => x.Id == request.Id);
                if(model != null)
                {
                    this.context.SupportRequests.Remove(model);
                    await this.context.SaveChangesAsync(token);
                }
                return request.Id;
            }
        }
        //нужно ограничение доступа

        //Написать тест на валидатор

        //Написать тест на хендлер
    }
}
