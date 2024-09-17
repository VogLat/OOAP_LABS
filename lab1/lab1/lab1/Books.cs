using System;
using System.Collections.Generic;

namespace lab1
{


    // Book class representing a book object
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}";
        }
    }

    // Interface for book collection
    interface IBookCollection
    {
        void AddBook(Book book);
        Book SearchBookByAuthor(string author);
        void RemoveBook(Book book);
        List<Book> GetAllBooks();
    }

    // Concrete collection class implementing IBookCollection
    class BookCollection : IBookCollection
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public Book SearchBookByAuthor(string author)
        {
            foreach (var book in books)
            {
                if (book.Author == author)
                {
                    return book;
                }
            }
            return null;
        }

        public void RemoveBook(Book book)
        {
            if (books.Contains(book))
            {
                books.Remove(book);
                Console.WriteLine($"Book '{book.Title}' by {book.Author} has been removed.");
            }
            else
            {
                Console.WriteLine($"Book '{book.Title}' by {book.Author} is not in the collection.");
            }
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }
    }

    // Proxy class for controlling access to the collection
    class BookCollectionProxy : IBookCollection
    {
        private BookCollection bookCollection = new BookCollection();

        public void AddBook(Book book)
        {
            Console.WriteLine("Adding a book...");
            bookCollection.AddBook(book);
        }

        public Book SearchBookByAuthor(string author)
        {
            Console.WriteLine($"Searching for a book by author: {author}");
            return bookCollection.SearchBookByAuthor(author);
        }

        public void RemoveBook(Book book)
        {
            Console.WriteLine("Removing a book...");
            bookCollection.RemoveBook(book);
        }

        public List<Book> GetAllBooks()
        {
            return bookCollection.GetAllBooks();
        }
    }
}