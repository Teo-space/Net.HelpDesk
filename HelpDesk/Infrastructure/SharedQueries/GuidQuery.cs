using FluentValidation;

namespace Infrastructure.SharedQueries
{
    public record GuidQuery(Guid Guid);

    public class GuidQueryAbstractValidator : AbstractValidator<GuidQuery>
    {
        public GuidQueryAbstractValidator()
        {
            RuleFor(x => x.Guid).NotEmpty();
        }
    }

}
