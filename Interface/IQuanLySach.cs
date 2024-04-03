using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySach.Interface
{
    public interface IQuanLySach
    {
        List<Sach> GetAllBooks();
        Sach GetBookById(int id);
        void AddBook(Sach book);
        void UpdateBook(Sach book);
        void DeleteBook(int id);
    }
}
