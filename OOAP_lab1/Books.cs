using System;
using System.Collections.Generic;

namespace lab1
{

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

        public override bool Equals(object obj)
        {
            if (obj is Book)
            {
                Book otherBook = (Book)obj;
                return this.Title == otherBook.Title && this.Author == otherBook.Author;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Title, Author).GetHashCode();
        }
    }

    interface IBookCollection
    {
        void AddBook(Book book);
        List<Book> SearchBooksByAuthor(string author);
        void RemoveBook(Book book);
        List<Book> GetAllBooks();
    }

    class BookCollection : IBookCollection
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public List<Book> SearchBooksByAuthor(string author)
        {
            List<Book> foundBooks = new List<Book>();

            foreach (var book in books)
            {
                if (book.Author == author)
                {
                    foundBooks.Add(book);
                }
            }
            return foundBooks;
        }

        public void RemoveBook(Book book)
        {
            Book bookToRemove = FindBook(book);

            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine($"Book '{book.Title}' by {book.Author} has been removed.");
            }
            else
            {
                Console.WriteLine($"Book '{book.Title}' by {book.Author} is not in the collection.");
            }
        }

        private Book FindBook(Book book)
        {
            foreach (var b in books)
            {
                if (b.Equals(book))
                {
                    return b;
                }
            }
            return null;
        }

        public List<Book> GetAllBooks()
        {
            return books;
        }
    }

    class BookCollectionProxy : IBookCollection
    {
        private BookCollection bookCollection = new BookCollection();

        public void AddBook(Book book)
        {
            Console.WriteLine("Adding a book...");
            bookCollection.AddBook(book);
        }

        public List<Book> SearchBooksByAuthor(string author)
        {
            Console.WriteLine($"Searching for books by author: {author}");

            List<Book> booksByAuthor = bookCollection.SearchBooksByAuthor(author);

            if (booksByAuthor.Count == 0)
            {
                Console.WriteLine($"No books found by author: {author}");
            }
            else
            {
                Console.WriteLine($"Found {booksByAuthor.Count} book(s) by author: {author}");
            }

            return booksByAuthor;
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
