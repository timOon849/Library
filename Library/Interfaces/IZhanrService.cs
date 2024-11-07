using Library.Tables;
using Microsoft.AspNetCore.Mvc;

namespace Library.Interfaces
{
    public interface IZhanrService
    {
        Task<IActionResult> GetallZhanrs();
        Task<IActionResult> CreateNewZhanr(Zhanr newZhanr);
        Task<IActionResult> UpdateBook(int ID_Zhanr, Zhanr zhanr);
        Task<IActionResult> DeleteZhanr(int ID_Zhanr);
    }
}
