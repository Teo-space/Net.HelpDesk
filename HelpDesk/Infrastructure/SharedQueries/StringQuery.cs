using FluentValidation;

namespace Infrastructure.SharedQueries
{
    public record StringQuery(string @string);
    public class StringQueryAbstractValidator : AbstractValidator<StringQuery>
    {
        public StringQueryAbstractValidator()
        {
            RuleFor(x => x.@string).NotEmpty();
        }
    }
}
