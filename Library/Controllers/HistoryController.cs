using Microsoft.AspNetCore.Mvc;
using Library.DBContext;
using Library.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController : Controller
    {
        readonly DBCon _context;
        public HistoryController(DBCon context)
        {
            _context = context;
        }
        //o Аренда книги читателем(с указанием срока аренды).
        [HttpPost]
        [Route("AddNewRent")]
        public async Task<IActionResult> AddNewRent(int srok, int Id_Book, int IdReader)
        {
            var Rent = new RentHistory()
            {
                Date_Start = DateTime.Now,
                Date_End = null,
                Srok = srok,
                ID_Book = Id_Book,
                ID_Reader = IdReader,
                
            };
            await _context.AddAsync(Rent);
            await _context.SaveChangesAsync();
            return Ok(Rent);
        }
        //o Возврат арендованной книги.
        [HttpPost]
        [Route("ReturnBook")]
        public async Task<IActionResult> ReturnBook(int ID_History)
        {
            var rentHistory = await _context.RentHistory.FindAsync(ID_History);

            if (rentHistory == null || rentHistory.Date_End != null)
            {
                return BadRequest("Информация об аренде не найдена");
            }

            rentHistory.Date_End = DateTime.Now;
            _context.RentHistory.Update(rentHistory);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //o   Получение истории аренды книг для конкретного читателя.
        [HttpGet]//должно работать
        [Route("RentHistoryForReader")]
        public async Task<IActionResult> RentHistoryForReader(int Id_Reader)
        {
            var readerHistory = await _context.RentHistory.Where(r => r.ID_Reader == Id_Reader).ToListAsync();
            if (readerHistory != null)
            {
                return Ok(readerHistory);
            }
            else
            {
                return BadRequest("Пользователь с таким ID не обнаружен");
            }
        }
        //o Получение информации о текущих арендах (кто арендовал, на какой срок).
        [HttpGet]
        [Route("GetCurrentRentals")]
        public async Task<IActionResult> GetCurrentRentals()
        {
            var currentRentals = await _context.RentHistory.Where(r => r.Date_End == null).ToListAsync();
            return Ok(currentRentals);
        }

        //o Получение истории аренды для конкретной книги.
        [HttpGet]
        [Route("GetRentHistoryForBook")]
        public async Task<IActionResult> GetRentHistoryForBook(int bookId)
        {
            var rentHistory = await _context.RentHistory.Where(r => r.ID_Book == bookId).ToListAsync();
            var book = await _context.Book.FindAsync(bookId);
            if (rentHistory != null && book != null)
            {
                return Ok(rentHistory);
            }
            else if(book == null)
            {
                return BadRequest("Книги с таким ID не существует");
            }
            else
            {
                return BadRequest("История аренды для книги с таким ID не найдена");
            }
        }
    }
}
