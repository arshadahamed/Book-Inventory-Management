using AutoMapper;
using BIM.Application.Books.Commands.CreateBook;
using BIM.Application.Books.Commands.UpdateBook;
using BIM.Domain.Entities;

namespace BIM.Application.Books.Dtos;

public class BooksProfile : Profile
{
   public BooksProfile()
    {
        CreateMap<UpdateBookCommand, Book>();
        CreateMap<CreateBookCommand, Book>();
        CreateMap<Book, BookDto>();

    }
}
