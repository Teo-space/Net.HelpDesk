using static HelpDesk.Pages.SupportRequest.ShowCreatedByMeModel;
using static HelpDesk.Pages.SupportRequest.ShowProcessedByMeModel;

namespace Tests.SupportRequestShowProcessedByMe;


public class SupportRequestShowProcessedByMeValidationTests
{

    ShowProcessedByMeQueryValidator validator = new();

	[Fact]
	public void TestIsValid()
	{
		var ValidTestModel = new ShowProcessedByMeQuery(Guid.NewGuid());
		//validator.Validate(ValidTestModel).IsValid.Should().BeTrue();
		validator.TestValidate(ValidTestModel)
			.ShouldNotHaveValidationErrorFor(x => x.Id);
	}

	[Fact]
	public void TestEmpty()
	{
		var EmptyTestModel = new ShowProcessedByMeQuery(Guid.Empty);
		//validator.Validate(EmptyTestModel).IsValid.Should().BeFalse();
		validator.TestValidate(EmptyTestModel)
			.ShouldHaveValidationErrorFor(x => x.Id);
	}
}
