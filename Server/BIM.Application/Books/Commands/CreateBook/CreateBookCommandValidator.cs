using FluentValidation;

namespace BIM.Application.Books.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    private readonly List<string> AllowedGenres = new List<string> { "Fiction", "Non-Fiction", "Science", "Biography", "Fantasy" };

    public CreateBookCommandValidator()
    {
        RuleFor(dto => dto.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        RuleFor(dto => dto.Author)
            .NotEmpty().WithMessage("Author is required.")
            .MaximumLength(50).WithMessage("Author name must not exceed 50 characters.");

        RuleFor(dto => dto.Genre)
            .NotEmpty().WithMessage("Genre is required.")
            .Must(genre => AllowedGenres.Contains(genre))
            .WithMessage("Invalid genre. Allowed genres are: Fiction, Non-Fiction, Science, Biography, Fantasy.");

        RuleFor(dto => dto.ISBN)
            .NotEmpty().WithMessage("ISBN is required.")
            .Matches(@"^\d{13}$").WithMessage("ISBN must be exactly 13 digits.");

        RuleFor(dto => dto.PublishedDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Published date cannot be in the future.");

        RuleFor(dto => dto.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");
    }
}
