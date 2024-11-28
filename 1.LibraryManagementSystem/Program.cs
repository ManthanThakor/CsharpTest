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

        public Book(string Isbn, string Title,string Author, string Genre)
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
                Console.WriteLine($"The book '{_Title}': checked out successfully.");
            }
            else
            {
                Console.WriteLine($"The Book '{_Title}' is currently unavailable ");
            }
        }

        public void Return()
        {
            IsAvailable = true;
            Console.WriteLine($"Book '{Title}' returned successfully.");
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"ISBN: {ISBN}, Title: {Title}, Author: {Author}, Genre: {Genre}, Available: {IsAvailable}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Library Management System");

            //Book book = new Book("123", "C# Basics", "John Doe", "Programming");
            //book.Checkout();

            Console.ReadLine();
        }
    }
}