using static HelpDesk.Pages.SupportRequest.CreateModel;
using static HelpDesk.Pages.SupportRequest.DetailModel;

namespace Tests.SupportRequestDetail;

public class SupportRequestDetailQueryValidatorTest
{
	DetailQueryValidator validator = new();

	[Fact]
	public void TestIsValid()
	{
		var ValidTestModel = new DetailQuery(Guid.NewGuid());
		//validator.Validate(ValidTestModel).IsValid.Should().BeTrue();
		validator.TestValidate(ValidTestModel)
			.ShouldNotHaveValidationErrorFor(x => x.Id);
	}

	[Fact]
	public void TestEmpty()
	{
		var EmptyTestModel = new DetailQuery(Guid.Empty);
		//validator.Validate(EmptyTestModel).IsValid.Should().BeFalse();
		validator.TestValidate(EmptyTestModel)
			.ShouldHaveValidationErrorFor(x => x.Id);
	}
}
