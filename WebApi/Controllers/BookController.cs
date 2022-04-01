using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.AddControllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class BookController : ControllerBase
    {
        private static List<Book> BookList = new List<Book>()
        {
            new Book{
                Id=1,
                Title="Korkuyu Beklerken",
                GenreId=1,
                PageCount=196,
                PublishDate = new DateTime(1975,06,01)
            },       
            new Book{
                Id=2,
                Title="Şeker Portakalı",
                GenreId=1,
                PageCount=182,
                PublishDate = new DateTime(1983,04,07)
            },
            new Book{
                Id=3,
                Title="Göğe Bakma Durağı",
                GenreId=2,
                PageCount=105,
                PublishDate = new DateTime(2008,03,20)
            }
        };

        //Tüm bookları geri döndüren bi endpoint yapalım.
        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList = BookList.OrderBy( x => x.Id).ToList<Book>();
            return bookList;
        }

        [HttpGet("{id}")]
        public Book GetById(int id)
        {
            var book = BookList.Where(book => book.Id == id).SingleOrDefault();
            return book;
        }

        /*[HttpGet]       //2 kez get kullanılamaz o yüzden kapattım.
        public Book Get([FromQuery] string id)
        {
            var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }*/
        

    }
}