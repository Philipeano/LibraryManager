﻿using LibraryManager.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Data.Repositories
{
    public interface IBookRepository
    {
        public void CreateBook(Book newBook);

        public void UpdateBook(Guid bookId, Book book);

        public void DeleteBook(Guid bookId);

        public Book GetBook(Guid bookId);

        public IEnumerable<Book> GetAllBooks();
    }
}
