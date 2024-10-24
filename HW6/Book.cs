using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6
{
    public class Book
    {
        public GenreEnum Genre { get; set; }
        public string  Title { get; set; }
        public string Author { get; set; }
        public string publisher { get; set; }
        public int Bookid { get; set; }
        public DateTime Barrowdate { get; set; }
        public Book(GenreEnum genre,string title,string author)
        {
           Genre = genre;
            Title = title;
            Author = author;
        }
        public void BookInfo()
        {
           
            Console.WriteLine("**===============**");
            Console.WriteLine($"Genre: {Genre}");
            Console.WriteLine($"Title: {Title}");   
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Id: {Bookid}");
           
        }
    }
}
