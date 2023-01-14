namespace Tests.SupportRequestCreate;

using static HelpDesk.Pages.SupportRequest.CreateModel;

public class SupportRequestCreateValidatorTests
{

	static CreateSupportRequestCommandValidator validator = new CreateSupportRequestCommandValidator();

	[Fact]
	public void TestIsValid()
	{
		var testModel = new CreateSupportRequestCommand(
			"Name", 
			"Description", 
			Guid.NewGuid(), 
			"creator@gmail.com", 
			"creator@gmail.com");

		validator.Validate(testModel).IsValid.Should().BeTrue();
	}


	[Fact]
	public void TestNameEmpty()
	{
		var testModel = new CreateSupportRequestCommand(
			"",
			"Description",
			Guid.NewGuid(),
			"creator@gmail.com",
			"creator@gmail.com");

		validator.Validate(testModel).IsValid.Should().BeFalse();
	}
	[Fact]
	public void TestNameBig()
	{
		var testModel = new CreateSupportRequestCommand(
			"qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm",
			"Description",
			Guid.NewGuid(),
			"creator@gmail.com",
			"creator@gmail.com");

		validator.Validate(testModel).IsValid.Should().BeFalse();
	}


	[Fact]
	public void TestDescriptionEmpty()
	{
		var testModel = new CreateSupportRequestCommand(
			"Name",
			"",
			Guid.NewGuid(),
			"creator@gmail.com",
			"creator@gmail.com");

		validator.Validate(testModel).IsValid.Should().BeFalse();
	}
	[Fact]
	public void TestDescriptionBig()
	{
		var testModel = new CreateSupportRequestCommand(
			"Name",
			@"qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm
qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm
qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm
qwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnm",
			Guid.NewGuid(),
			"creator@gmail.com",
			"creator@gmail.com");

		validator.Validate(testModel).IsValid.Should().BeFalse();
	}

	[Fact]
	public void TestCreatorId()
	{
		var testModel = new CreateSupportRequestCommand(
			"Name",
			"Description",
			Guid.Empty,
			"creator@gmail.com",
			"creator@gmail.com");

		validator.Validate(testModel).IsValid.Should().BeFalse();
	}

	[Fact]
	public void TestCreatorNameEmty()
	{
		var testModel = new CreateSupportRequestCommand(
			"Name",
			"Description",
			Guid.NewGuid(),
			"",
			"creator@gmail.com");

		validator.Validate(testModel).IsValid.Should().BeFalse();
	}
	[Fact]
	public void TestCreatorNameInvalid()
	{
		var testModel = new CreateSupportRequestCommand(
			"Name",
			"Description",
			Guid.NewGuid(),
			"creatorgmail.com",
			"creator@gmail.com");

		validator.Validate(testModel).IsValid.Should().BeFalse();
	}

	[Fact]
	public void TestCreatorEmailEmpty()
	{
		var testModel = new CreateSupportRequestCommand(
			"Name",
			"Description",
			Guid.NewGuid(),
			"creator@gmail.com",
			"");

		validator.Validate(testModel).IsValid.Should().BeFalse();
	}
	[Fact]
	public void TestCreatorEmailInvalid()
	{
		var testModel = new CreateSupportRequestCommand(
			"Name",
			"Description",
			Guid.NewGuid(),
			"creator@gmail.com",
			"creatorgmail.com");

		validator.Validate(testModel).IsValid.Should().BeFalse();
	}



}
