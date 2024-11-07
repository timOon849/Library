using Library.DBContext;
using Library.Interfaces;
using Library.Service;
using Library.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZhanrController : Controller
    {
        private readonly IZhanrService _zhanrService;

        public ZhanrController(IZhanrService zhanrService)
        {
            _zhanrService = zhanrService;
        }

        //o Получение списка всех жанров.
        [HttpGet]
        [Route("GetAllZhanrs")]
        public async Task<IActionResult> GetallZhanrs()
        {
            return await _zhanrService.GetallZhanrs();
        }

        //o Добавление нового жанра.
        [HttpPost]
        [Route("CreateNewZhanr")]
        public async Task<IActionResult> CreateNewZhanr(Zhanr newZhanr)
        {
            return await _zhanrService.CreateNewZhanr(newZhanr);
        }

        //o   Редактирование жанра.
        [HttpPut]
        [Route("UpdateZhanr")]
        public async Task<IActionResult> UpdateBook(int ID_Zhanr, Zhanr zhanr)
        {
            return await _zhanrService.UpdateBook(ID_Zhanr, zhanr);
        }
        //o Удаление жанра.
        [HttpDelete]
        [Route("DeleteZhanr")]
        public async Task<IActionResult> DeleteZhanr(int ID_Zhanr)
        {
            return await _zhanrService.DeleteZhanr(ID_Zhanr);
        }
    }
}
