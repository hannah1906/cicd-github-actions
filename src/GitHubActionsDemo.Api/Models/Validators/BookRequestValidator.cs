using FluentValidation;

namespace GitHubActionsDemo.Api.Models.Validators;

public class BookRequestValidator : AbstractValidator<BookRequest>
{
    public BookRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.AuthorId).NotEmpty();

        RuleFor(x => x.Isbn)
            .NotEmpty()
            .MinimumLength(10)
            .MaximumLength(17)
            .Matches(@"^(?:ISBN(?:-1[03])?:? )?(?=[0-9X]{10}$|(?=(?:[0-9]+[- ]){3})[- 0 - 9X]{ 13}$| 97[89][0 - 9]{ 10}$| (?= (?:[0 - 9] +[- ]){ 4})[- 0 - 9]{ 17}$)(?: 97[89][- ] ?)?[0 - 9]{ 1,5}[- ]?[0 - 9]+[- ]?[0 - 9] +[- ]?[0 - 9X]$");

        RuleFor(x => x.DatePublished)
            .NotEmpty();
    }
}