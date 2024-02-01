using AutoMapper;
using Modsen.Dto;
using Modsen.Entities;

namespace Modsen.Mapper
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {
            CreateMap<Book, BookInformationDto>();
            CreateMap<AddBookDto, Book>();
        }
    }
}
