using Library.DBContext;
using Library.Interfaces;
using Library.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Service
{
    public class ZhanrService : IZhanrService
    {
        private readonly DBCon _context;
        public ZhanrService(DBCon context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateNewZhanr(Zhanr newZhanr)
        {
            var zhanr = new Zhanr()
            {
                Name_Zhanr = newZhanr.Name_Zhanr
            };

            await _context.Zhanrs.AddAsync(zhanr);
            await _context.SaveChangesAsync();
            return new OkObjectResult(zhanr);
        }

        public async Task<IActionResult> DeleteZhanr(int ID_Zhanr)
        {
            var tecZhanr = await _context.Book.FindAsync(ID_Zhanr);
            if (tecZhanr != null)
            {
                _context.Remove(tecZhanr);
                await _context.SaveChangesAsync();
                return new OkResult();
            }
            else
            {
                return new BadRequestObjectResult("Книга с данным ID не найдена или уже удалена");
            }
        }

        public async Task<IActionResult> GetallZhanrs()
        {
            var zhanrs = await _context.Zhanrs.ToListAsync();
            if (zhanrs != null)
            {
                return new OkObjectResult(zhanrs);
            }
            else
            {
                return new NotFoundObjectResult("Жанров не обнаружено");
            }

        }

        public async Task<IActionResult> UpdateBook(int ID_Zhanr, Zhanr zhanr)
        {
            var tecZhanr = await _context.Zhanrs.FindAsync(ID_Zhanr);

            if (tecZhanr != null)
            {
                tecZhanr.Name_Zhanr = zhanr.Name_Zhanr;
                await _context.SaveChangesAsync();
                return new OkObjectResult(tecZhanr);
            }
            else
            {
                return new BadRequestObjectResult("Жанр с данным ID не найден");
            }
        }
    }
}
