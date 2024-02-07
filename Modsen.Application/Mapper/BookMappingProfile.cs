using AutoMapper;
using Modsen.Application.Features.Book.Commands;
using Modsen.Application.Models;
using Modsen.Domain.Entities;

namespace Modsen.Application.Mapper
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile() 
        {
            CreateMap<AddBook, Book>();
            CreateMap<Book, BookInformation>();
        }
    }
}
