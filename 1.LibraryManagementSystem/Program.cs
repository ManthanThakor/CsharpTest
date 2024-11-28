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
                Console.WriteLine($"    The book '{_Title}' was checked out successfully.\n");
            }
            else
            {
                Console.WriteLine($"    The book '{_Title}' is currently unavailable.\n");
            }
        }

        public void Return()
        {
            if (!_IsAvailable)
            {
                _IsAvailable = true;
                Console.WriteLine($"    The book '{_Title}' was returned successfully.\n");
            }
            else
            {
                Console.WriteLine($"    The book '{_Title}' is already available.\n");
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"    ISBN: {_Isbn}, Title: {_Title}, Author: {_Author}, Genre: {_Genre}, Available: {_IsAvailable}");
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
                Console.WriteLine($"    The book '{book._Title}' is currently unavailable.\n");
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
                Console.WriteLine($"    The book '{book._Title}' is not checked out by this patron.\n");
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"    ID: {_ID}, Name: {_Name}, Contact: {_ContactInfo}, Books Checked Out: {_BooksCheckedOut.Count}");
            foreach (var book in _BooksCheckedOut)
            {
                Console.WriteLine($"    - {book._Title} (ISBN: {book._Isbn}, Author: {book._Author}, Genre: {book._Genre})");
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
            Console.WriteLine($"    Transaction Recorded: {_TransactionType} , Book: {_BookISBN}, Patron: {_PatronID}, Date: {_Date}\n");
        }

        public void DisplayTransactionDetails()
        {
            Console.WriteLine($"    Transaction ID: {_TransactionID}, Date: {_Date}, Book ISBN: {_BookISBN}, Patron ID: {_PatronID}, Type: {_TransactionType}");
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
            Console.WriteLine($"    Book '{book._Title}' added to the library.\n");
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
            Console.WriteLine($"    Book '{book._Title}' removed from the library.\n");
        }

        public void AddPatron(Patron patron)
        {
            Patrons.Add(patron);
            Console.WriteLine($"    Patron '{patron._Name}' added.\n");
        }

        public void RemovePatron(Patron patron)
        {
            Patrons.Remove(patron);
            Console.WriteLine($"    Patron '{patron._Name}' removed.\n");
        }

        public void DisplayAllBooks()
        {
            Console.WriteLine("\n--- Library Books ---");
            foreach (var book in Books)
            {
                book.DisplayDetails();
            }
        }

        public void DisplayAllPatrons()
        {
            Console.WriteLine("\n--- Library Patrons ---");
            foreach (var patron in Patrons)
            {
                patron.DisplayDetails();
            }
        }

        public void DisplayTransactionHistory()
        {
            Console.WriteLine("\n--- Transaction History ---");
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
            Console.WriteLine("********** Library Management System **********\n");

            Library library = new Library();

            Book book1 = new Book("1234", "C# Basics", "Xyz", "Programming");
            Book book2 = new Book("4567", "C# Oops", "Abc", "Programming");
            Book book3 = new Book("7891", "C# Oops 2", "Def", "Programming");

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);

            var patron1 = new Patron(1, "XYZ123", "XYZ123@gmail.com");
            var patron2 = new Patron(2, "ABC123", "ABC123@gmail.com");

            library.AddPatron(patron1);
            library.AddPatron(patron2);

            library.DisplayAllBooks();
            library.DisplayAllPatrons();

            Console.WriteLine("\n*** Patron 1 Checks Out Book ***");
            patron1.CheckOutBook(book1);
            patron1.DisplayDetails();

            Console.WriteLine("\n*** Patron 1 Returns Book ***");
            patron1.ReturnBook(book1);
            patron1.DisplayDetails();

            var transaction1 = new LibraryTransaction("T001", DateTime.Now, book1._Isbn, patron1._ID, "Return");
            transaction1.RecordTransaction();
            library.Transactions.Add(transaction1);

            patron1.DisplayDetails();
            book1.DisplayDetails();

            library.DisplayTransactionHistory();

            Console.WriteLine("\n********** End **********");

            Console.ReadLine();
        }
    }
}
