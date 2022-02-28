using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetBooksDetail
{
    public class GetBooksDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public GetBooksDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public BooksDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id ==BookId).SingleOrDefault();
            if (book is null)
                throw new InvalidCastException("Kitap Bulunamadı");
            BooksDetailViewModel vm = new BooksDetailViewModel();
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
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