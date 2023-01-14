using FluentValidation;
using DataBase.Contexts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using DataBase.Models;
using System.Runtime.ConstrainedExecution;


namespace HelpDesk.Pages.SupportRequest
{
    public class CreateModel : PageModel
	{
		private readonly IMediator mediator;
		public CreateModel(IMediator mediator) => this.mediator = mediator;

		public async void OnGet()
        {
        }
		public async void OnPost()
		{
			var command = new CreateSupportRequestCommand(
				Data.Name, 
				Data.Description, 
				Guid.Parse(User.ClaimNameIdentifier()),
                User.ClaimName(),
                User.ClaimEmail())
				;
			Result = await this.mediator.Send(command);
		}

		public Guid Result { get; private set; }
		


		[BindProperty]
		public CreateSupportRequestDto Data { get; set; }

		public record CreateSupportRequestDto(string Name, string Description);

		public class CreateSupportRequestDtoValidator : AbstractValidator<CreateSupportRequestDto>
		{
			public CreateSupportRequestDtoValidator()
			{
				RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
				RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
			}
		}

		public record CreateSupportRequestCommand(string Name, string Description, 
			Guid CreatorId, string CreatorName, string CreatorEmail) : IRequest<Guid>;


		public class CreateSupportRequestCommandValidator : AbstractValidator<CreateSupportRequestCommand>
		{
			public CreateSupportRequestCommandValidator()
			{
				RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
				RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
				RuleFor(x => x.CreatorId).NotNull().NotEmpty();
				RuleFor(x => x.CreatorName).NotEmpty().MaximumLength(60);
				RuleFor(x => x.CreatorEmail).NotEmpty().EmailAddress();
			}
		}

		public class CreateSupportRequestHandler : IRequestHandler<CreateSupportRequestCommand, Guid>
		{
			private readonly DataContext context;
			public CreateSupportRequestHandler(DataContext context) => this.context = context;

			public async Task<Guid> Handle(CreateSupportRequestCommand request, CancellationToken token)
			{
				var Task = new DataBase.Models.SupportRequest()
				{
					Id = Guid.NewGuid(),

					CreatorId = request.CreatorId,
                    CreatorName = request.CreatorName,
					CreatorEmail = request.CreatorEmail,
                    Created = DateTime.Now,

					Name = request.Name,
					Description = request.Description,

					Category = Category.OfficeEquipment,
					Status = Status.Pending,

				};
				this.context.Add(Task);
				await this.context.SaveChangesAsync(token);
				return Task.Id;
			}


		}
	}
}
