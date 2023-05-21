using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_Statement_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Chapters = new List<string>();
            Chapters.Add("The Beginning");
            Chapters.Add("The Middle");
            Chapters.Add("The End");
            Book SampleBook = new Book("John", 250, Chapters, 25, 1000);
            string chapter = SampleBook.getChapter(1);
            Console.WriteLine("The chapter is " + chapter);
            int bookmark = SampleBook.getBookMark();
            Console.WriteLine("The bookmark is " + bookmark);
            SampleBook.setBookMark(60);
            bookmark = SampleBook.getBookMark();
            Console.WriteLine("The bookmark is " + bookmark);
            int price = SampleBook.getBookPrice();
            Console.WriteLine("The price is " + price);
            SampleBook.setBookPrice(800);
            price = SampleBook.getBookPrice();
            Console.WriteLine("The price is " + price);
            Console.ReadKey();
        }
    }
    class Book
    {
        public string author;
        public int pages;
        public List<string> Chapters;
        public int bookMark;
        public int price;
        public Book(string a, int p, List<string> c, int bm, int Price)
        {
            author = a;
            pages = p;
            Chapters = c;
            bookMark = bm;
            price = Price;
        }
        public string getChapter(int chapterNumber)
        {
            string chapter;
            chapter = Chapters[chapterNumber - 1];
            return chapter;
        }
        public int getBookMark()
        {
            return bookMark;
        }
        public void setBookMark(int pageNumber)
        {
            bookMark = pageNumber;
        }
        public int getBookPrice()
        {
            return price;
        }
        public void setBookPrice(int newPrice)
        {
            price = newPrice;
        }
    }
}