using QuanLySach.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLySach.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuanLySach _quanLySach;

        public HomeController(IQuanLySach quanLySach)
        {
            _quanLySach = quanLySach;
        }

        public HomeController()
        {
            _quanLySach = new QuanLySach.Interface.QuanLySach(); // Cần dependency injection trong thực tế
        }

        public ActionResult Index()
        {
            List<QuanLySach.Models.Sach> books = _quanLySach.GetAllBooks().Select(b => new QuanLySach.Models.Sach
            {
                Id = b.Id,
                TieuDe = (string)b.TieuDe,
                TacGia = (string)b.TacGia,
                NamXuatBan = (int)b.NamXuatBan
            }).ToList();
            return View(books);
        }

        [HttpGet]
        public JsonResult GetAllBooks()
        {
            List<Sach> books = _quanLySach.GetAllBooks();
            return Json(books, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddBook(Sach book)
        {
            _quanLySach.AddBook(book);
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult UpdateBook(Sach book)
        {
            _quanLySach.UpdateBook(book);
            return Json(new { success = true });
        }

        [HttpPost]
        public JsonResult DeleteBook(int id)
        {
            _quanLySach.DeleteBook(id);
            return Json(new { success = true });
        }
    }
}