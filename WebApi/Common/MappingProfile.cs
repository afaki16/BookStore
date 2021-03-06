using AutoMapper;
using WebApi;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetBooksDetail;
using WebApi.Common;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace Webapi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<CreateBookModel, Book>(); 
           CreateMap<Book,BooksDetailViewModel>().ForMember(dest => dest.Genre, opt=> opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
           CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt=> opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
           
        }
    }

}