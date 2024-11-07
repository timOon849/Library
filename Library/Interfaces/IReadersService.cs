using Library.Tables;
using Microsoft.AspNetCore.Mvc;
namespace Library.Interfaces
{
    public interface IReadersService
    {
        Task<IActionResult> AddReader(Readers newReader);
        Task<IActionResult> GetAllReaders();
        Task<IActionResult> GetReaderInfo(int Id_Reader);
        Task<IActionResult> UpdateReader(int Id, Readers updateReader);
        Task<IActionResult> DeleteReader(int Id_Reader);
        Task<IActionResult> BooksRentedByReader(int ID_Reader);

    }
}
