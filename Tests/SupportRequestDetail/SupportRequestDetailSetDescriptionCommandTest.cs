using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static HelpDesk.Pages.SupportRequest.DetailModel;

namespace Tests.SupportRequestDetail;

public class SupportRequestDetailSetDescriptionCommandTest
{
	SetDescriptionCommandValidator validator = new();

	[Fact]
	public void TestValid()
	{
		var model = new SetDescriptionCommand(Guid.NewGuid(), "Description");

		validator.TestValidate(model)
			.ShouldNotHaveValidationErrorFor(x => x.Id);

		validator.TestValidate(model)
			.ShouldNotHaveValidationErrorFor(x => x.Description);
	}


	[Fact]
	public void TestIdEmpty()
	{
		var model = new SetDescriptionCommand(Guid.Empty, "");

		validator.TestValidate(model).ShouldHaveValidationErrorFor(x => x.Id);
	}


	[Fact]
	public void TestDescriptionEmpty()
	{
		var model = new SetDescriptionCommand(Guid.Empty, "");
		validator.TestValidate(model)
			.ShouldHaveValidationErrorFor(x => x.Description);
	}
	[Fact]
	public void TestDescriptionMaximumLength()
	{
		var model = new SetDescriptionCommand(Guid.Empty,
			@"qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm
qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm
qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm
qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm
qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm
");
		validator.TestValidate(model)
			.ShouldHaveValidationErrorFor(x => x.Description);
	}


}
