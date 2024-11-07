using Library.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Library.Interfaces
{
    public interface IBookService
    {
        Task<IActionResult> GetAllBooks();
        Task<IActionResult> GetInfoByID(int ID_Book);
        Task<IActionResult> CreateNewBook(Book newBook);
        Task<IActionResult> UpdateBook(int ID_Book, Book book);
        Task<IActionResult> DeleteBook(int ID_Book);
        Task<IActionResult> GetBooksByZhanr(string Namezhanr);
        Task<IActionResult> GetBookNameAuthor(string? Authorbook, string? Namebook);
        Task<IActionResult> BooksPagination(int page, int pageSize);
        Task<IActionResult> SearchOrFilter(string author, int? genreId, int? year);
    }
}
