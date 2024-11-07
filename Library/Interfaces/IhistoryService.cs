using Microsoft.AspNetCore.Mvc;

namespace Library.Interfaces
{
    public interface IhistoryService
    {
        Task<IActionResult> AddNewRent(int srok, int Id_Book, int IdReader);
        Task<IActionResult> ReturnBook(int ID_History);
        Task<IActionResult> RentHistoryForReader(int Id_Reader);
        Task<IActionResult> GetCurrentRentals();
        Task<IActionResult> GetRentHistoryForBook(int bookId);

    }
}
