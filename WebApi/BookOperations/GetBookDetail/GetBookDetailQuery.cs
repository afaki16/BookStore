using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooksDetail
{
    public class GetBooksDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }
        public GetBooksDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BooksDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id ==BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidCastException("Kitap Bulunamadı");
            BooksDetailViewModel vm = _mapper.Map<BooksDetailViewModel>(book);  
             
            return vm;
        }
    }

    public class BooksDetailViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}