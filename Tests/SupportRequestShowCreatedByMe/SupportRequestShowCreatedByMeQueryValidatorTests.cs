using static HelpDesk.Pages.SupportRequest.ShowCreatedByMeModel;

namespace Tests.SupportRequestShowCreatedByMe;


public class SupportRequestShowCreatedByMeQueryValidatorTests
{
    ShowCreatedByMeQueryValidator validator = new();

	[Fact]
	public void TestIsValid()
	{
		var ValidTestModel = new ShowCreatedByMeQuery(Guid.NewGuid());
		//validator.Validate(ValidTestModel).IsValid.Should().BeTrue();
		validator.TestValidate(ValidTestModel)
			.ShouldNotHaveValidationErrorFor(x => x.UserId);
	}

	[Fact]
	public void TestEmpty()
	{
		var EmptyTestModel = new ShowCreatedByMeQuery(Guid.Empty);
		//validator.Validate(EmptyTestModel).IsValid.Should().BeFalse();
		validator.TestValidate(EmptyTestModel)
			.ShouldHaveValidationErrorFor(x => x.UserId);
	}
}
