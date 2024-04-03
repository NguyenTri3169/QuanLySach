using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLySach.Interface
{
    public class QuanLySach : IQuanLySach
    {
        private List<Sach> books = new List<Sach>();

        public List<Sach> GetAllBooks()
        {
            return books;
        }

        public Sach GetBookById(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }

        public void AddBook(Sach book)
        {
            book.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
            books.Add(book);
        }

        public void UpdateBook(Sach book)
        {
            Sach existingBook = GetBookById(book.Id);
            if (existingBook != null)
            {
                existingBook.TieuDe = book.TieuDe;
                existingBook.TacGia = book.TacGia;
                existingBook.NamXuatBan = book.NamXuatBan;
            }
        }

        public void DeleteBook(int id)
        {
            Sach bookToDelete = GetBookById(id);
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
            }
        }
    }
}