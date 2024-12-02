using BIM.Application.Books.Dtos;
using FluentValidation;

namespace BIM.Application.Books.Queries.GetAllBooks;

public class GetAllBooksQueryValidator : AbstractValidator<GetAllBooksQuery>
{
    private int[] allowPageSizes = [5, 10, 15, 30];
    private string[] allowedSortByColumnNames = [nameof(BookDto.Title),
                nameof(BookDto.Genre),
                nameof(BookDto.Author)];
    public GetAllBooksQueryValidator()
    {

        RuleFor(r => r.PageNumber)
            .GreaterThanOrEqualTo(1);

        RuleFor(r => r.PageSize)
            .Must(value => allowPageSizes.Contains(value))
            .WithMessage($"Page size must be in [{string.Join(",", allowPageSizes)}]");

        RuleFor(r => r.SortBy)
            .Must(value => allowedSortByColumnNames.Contains(value))
            .When(query => query.SortBy != null)
            .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
    }
}
