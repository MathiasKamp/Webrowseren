using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Books : ControllerBase
    {
        private  List<Book> books = new();
        
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            for (int i = 0; i < 10; i++)
            {
                var bookYear = 2000 + i;
                var bookName = "book " + i;
                var book = new Book(i, bookName, bookYear);

                books.Add(book);
            }

            return books.ToArray();
        }
    }
}