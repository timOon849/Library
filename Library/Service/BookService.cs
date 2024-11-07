using Library.DBContext;
using Library.Interfaces;
using Library.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library.Service
{
    public class BookService : IBookService
    {
        private readonly DBCon _context;
        public BookService (DBCon context)
        {
            _context = context;
        }
        public async Task<IActionResult> CreateNewBook(Book newBook)
        {
            var zhanr = await _context.Zhanrs.FindAsync(newBook.ID_Zhanr);
            if (zhanr == null)
            {
                return new BadRequestObjectResult("Жанр с указанным ID не найден");
            }
            var book = new Book()
            {
                Name = newBook.Name,
                Description = newBook.Description,
                Author = newBook.Author,
                YearOfIzd = newBook.YearOfIzd,
                ID_Zhanr = zhanr.ID_Zhanr,
            };
            await _context.Book.AddAsync(book);
            await _context.SaveChangesAsync();
            return new OkResult();
        }

        public async Task<IActionResult> DeleteBook(int ID_Book)
        {
            var tecBook = await _context.Book.FindAsync(ID_Book);
            if (tecBook != null)
            {
                _context.Remove(tecBook);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            else
            {
                return new BadRequestObjectResult("Книга с данным ID не найдена или уже удалена");
            }
        }

        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _context.Book.ToListAsync();
            if (books != null)
            {
                return new OkObjectResult(books);
            }
            else
            {
                return new BadRequestObjectResult("Книги не найдены");
            }
        }

        public async Task<IActionResult> GetBookNameAuthor(string? Authorbook, string? Namebook)
        {
            var books = await _context.Book.Where(a => a.Name.ToLower().Contains(Namebook) || a.Author.ToLower().Contains(Authorbook)).ToListAsync();

            if (books is null)
            {
                return new BadRequestObjectResult("Такой книги не найдено");
            }
            return new OkObjectResult(books);
        }

        public async Task<IActionResult> GetBooksByZhanr(string Namezhanr)
        {
            var TecZhanr = await _context.Zhanrs.FirstOrDefaultAsync(a => a.Name_Zhanr.ToLower().Contains(Namezhanr));
            var books = await _context.Book.Where(b => b.ID_Zhanr == TecZhanr.ID_Zhanr).ToListAsync();
            if (TecZhanr != null)
            {
                if (books != null)
                {
                    return new OkObjectResult(books);
                }
                else
                {
                    return new BadRequestObjectResult("Книги с таким жанром не обнаружены");
                }
            }
            else
            {
                return new BadRequestObjectResult("Такого жанра не существует");
            }
        }

        public async Task<IActionResult> GetInfoByID(int ID_Book)
        {
            var tecBook = await _context.Book.FindAsync(ID_Book);
            if (tecBook != null)
            {
                return new OkObjectResult(tecBook);
            }
            else
            {
                return new BadRequestObjectResult("Книга с данным ID не найдена");
            }
        }

        public async Task<IActionResult> UpdateBook(int ID_Book, Book book)
        {
            var tecBook = await _context.Book.FindAsync(ID_Book);

            if (tecBook != null)
            {
                var zhanr = await _context.Zhanrs.FindAsync(tecBook.ID_Zhanr);
                if (zhanr != null)
                {
                    tecBook.Name = book.Name;
                    tecBook.Description = book.Description;
                    tecBook.Author = book.Author;
                    tecBook.YearOfIzd = book.YearOfIzd;
                    tecBook.ID_Zhanr = zhanr.ID_Zhanr;
                    await _context.SaveChangesAsync();
                    return new OkObjectResult(tecBook);
                }
                else
                {
                    return new BadRequestObjectResult("Не удается онаружить жанр с данным ID");
                }
            }
            else
            {
                return new BadRequestObjectResult("Книга с данным ID не найдена");
            }
        }
        public async Task<IActionResult> BooksPagination(int page, int pageSize)
        {
            var totalBooks = await _context.Book.CountAsync();
            var totalPages = (int)Math.Ceiling(totalBooks / (double)pageSize);

            // Получаем книги с учетом пагинации
            var books = await _context.Book.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            if (books.Count == 0)
            {
                return new NotFoundObjectResult("Книги не найдены");
            }

            return new OkObjectResult(new
            {
                TotalBooks = totalBooks,
                TotalPages = totalPages,
                CurrentPage = page,
                Books = books
            });
        }
        public async Task<IActionResult> SearchOrFilter(string author, int? genreId, int? year)
        {
            var query = _context.Book.AsQueryable();

            if (!string.IsNullOrEmpty(author) || genreId != null || year != null)
            {
                if (!string.IsNullOrEmpty(author))
                {
                    query = query.Where(b => b.Author.Contains(author));
                }

                if (genreId.HasValue)
                {
                    query = query.Where(b => b.ID_Zhanr == genreId.Value);
                }

                if (year.HasValue)
                {
                    query = query.Where(b => b.YearOfIzd.Year == year.Value);
                }

                var result = await query.ToListAsync();

                if (result.Any())
                {
                    return new OkObjectResult(result); 
                }
                else
                {
                    return new NotFoundObjectResult("Книги не найдены"); 
                }
            }
            else
            {
                return new NotFoundObjectResult("Не указаны параметры для поиска"); 
            }
        }
    }
}
