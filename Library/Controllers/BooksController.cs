using Library.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Tables;
using Library.Interfaces;
using System;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("getAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            return await _bookService.GetAllBooks();
        }


        [HttpGet]
        [Route("GetInfoByID")]
        public async Task<IActionResult> GetInfoByID(int ID_Book)
        {
            return await _bookService.GetInfoByID(ID_Book);
        }

        [HttpPost]
        [Route("CreateNewBook")]
        public async Task<IActionResult> CreateNewBook(Book newBook)
        {
            return await _bookService.CreateNewBook(newBook);
        }

        [HttpPut]
        [Route("UpdateBook")]
        public async Task<IActionResult> UpdateBook(int ID_Book, Book book)
        {
            return await _bookService.UpdateBook(ID_Book, book);
        }

        [HttpDelete]
        [Route("DeleteBook")]
        public async Task<IActionResult> DeleteBook(int ID_Book)
        {
            return await _bookService.DeleteBook(ID_Book);
        }

        [HttpGet]
        [Route("GetBooksByZhanr")]
        public async Task<IActionResult> GetBooksByZhanr(string Namezhanr)
        {
            return await _bookService.GetBooksByZhanr(Namezhanr);
        }

        [HttpGet]
        [Route("GetBookNameAuthor")]
        public async Task<IActionResult> GetBookNameAuthor(string? Authorbook, string? Namebook)
        {
            return await _bookService.GetBookNameAuthor(Authorbook, Namebook);
        }

        [HttpGet]
        [Route("BooksPagination")]
        public async Task<IActionResult> BooksPagination(int page, int pageSize)
        {
            return await _bookService.BooksPagination(page, pageSize);
        }

        [HttpGet]
        [Route("SearchOrFilter")]
        public async Task<IActionResult> SearchOrFilter(string author, int? genreId, int? year)
        {
            return await _bookService.SearchOrFilter(author, genreId, year);
        }
    }
}