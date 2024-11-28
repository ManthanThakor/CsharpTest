using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    public class Book
    {
        public string _Isbn; 
        public string _Title; 
        public string _Author;
        public string _Genre;
        public bool _IsAvailable;

        public Book(string Isbn, string Title, string Author, string Genre)
        {
            _Isbn = Isbn;
            _Title = Title;
            _Author = Author;
            _Genre = Genre;
            _IsAvailable = true;
        }

        public void Checkout()
        {
            if (_IsAvailable)
            {
                _IsAvailable = false;
                Console.WriteLine($"The book '{_Title}' was checked out successfully.");
            }
            else
            {
                Console.WriteLine($"The book '{_Title}' is currently unavailable.");
            }
        }

        public void Return()
        {
            if (!_IsAvailable)
            {
                _IsAvailable = true;
                Console.WriteLine($"The book '{_Title}' was returned successfully.");
            }
            else
            {
                Console.WriteLine($"The book '{_Title}' is already available.");
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"ISBN: {_Isbn}, Title: {_Title}, Author: {_Author}, Genre: {_Genre}, Available: {_IsAvailable}");
        }
    }

    public class Patron
    {
        public int _ID; 
        public string _Name; 
        public string _ContactInfo; 
        public List<Book> _BooksCheckedOut;

        public Patron(int id, string name, string contactInfo)
        {
            _ID = id;
            _Name = name;
            _ContactInfo = contactInfo;
            _BooksCheckedOut = new List<Book>();
        }

        public void CheckOutBook(Book book)
        {
            if (book._IsAvailable)
            {
                book.Checkout();
                _BooksCheckedOut.Add(book);
            }
            else
            {
                Console.WriteLine($"The book '{book._Title}' is currently unavailable.");
            }
        }

        public void ReturnBook(Book book)
        {
            if (_BooksCheckedOut.Contains(book))
            {
                book.Return();
                _BooksCheckedOut.Remove(book);
            }
            else
            {
                Console.WriteLine($"The book '{book._Title}' is not checked out by this patron.");
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {_ID}, Name: {_Name}, Contact: {_ContactInfo}, Books Checked Out: {_BooksCheckedOut.Count}");
            foreach (var book in _BooksCheckedOut)
            {
                Console.WriteLine($"  - {book._Title}");
            }
        }
    }

    public class LibraryTransaction
    {
        public string _TransactionID;
        public DateTime _Date;
        public string _BookISBN;
        public int _PatronID;
        public string _TransactionType;

        public LibraryTransaction(string transactionID, DateTime date, string bookISBN, int patronID, string transactionType)
        {
            _TransactionID = transactionID;
            _Date = date;
            _BookISBN = bookISBN;
            _PatronID = patronID;
            _TransactionType = transactionType;
        }

        public void RecordTransaction()
        {
            Console.WriteLine($"Transaction Recorded: {_TransactionType} - Book: {_BookISBN}, Patron: {_PatronID}, Date: {_Date}");
        }

        public void DisplayTransactionDetails()
        {
            Console.WriteLine($"Transaction ID: {_TransactionID}, Date: {_Date}, Book ISBN: {_BookISBN}, Patron ID: {_PatronID}, Type: {_TransactionType}");
        }
    }

    public class Library
    {
        public List<Book> Books;
        public List<Patron> Patrons;
        public List<LibraryTransaction> Transactions;

        public Library()
        {
            Books = new List<Book>();
            Patrons = new List<Patron>();
            Transactions = new List<LibraryTransaction>();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            Console.WriteLine($"Book '{book._Title}' added to the library.");
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
            Console.WriteLine($"Book '{book._Title}' removed from the library.");
        }

        public void AddPatron(Patron patron)
        {
            Patrons.Add(patron);
            Console.WriteLine($"Patron '{patron._Name}' added.");
        }

        public void RemovePatron(Patron patron)
        {
            Patrons.Remove(patron);
            Console.WriteLine($"Patron '{patron._Name}' removed.");
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("\nLibrary Books:");
            foreach (var book in Books)
            {
                book.DisplayDetails();
            }
        }

        public void DisplayAllPatrons()
        {
            Console.WriteLine("\nLibrary Patrons:");
            foreach (var patron in Patrons)
            {
                patron.DisplayDetails();
            }
        }

        public void DisplayTransactionHistory()
        {
            Console.WriteLine("\nTransaction History:");
            foreach (var transaction in Transactions)
            {
                transaction.DisplayTransactionDetails();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Library Management System\n");

            Library library = new Library();

            Book book1 = new Book("1234", "C# Basics", "Xyz", "Programming");
            Book book2 = new Book("4567", "C# oops", "Abc", "Programming");

            library.AddBook(book1);
            library.AddBook(book2);

            var patron1 = new Patron(1, "Alice Johnson", "alice@example.com");
            var patron2 = new Patron(2, "Bob Williams", "bob@example.com");

            Console.ReadLine();
        }
    }
}
