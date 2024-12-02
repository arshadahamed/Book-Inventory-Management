namespace BIM.Application.Books.Dtos;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public string Genre { get; set; } = default!;
    public string ISBN { get; set; } = default!;
    public DateTime PublishedDate { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

}
