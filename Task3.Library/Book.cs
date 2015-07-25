using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Library
{
    [Serializable]
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        private string title;
        private int year;
        private int pages;
        public string Author { get; set; }
        public string Title
        { 
            get { return title; } 
            set
            {
                if (string.IsNullOrEmpty(value)) 
                    throw new ArgumentNullException(); 
                else 
                    title = value;
            } 
        }
        public int Year 
        { 
            get { return year; } 
            set
            {
                if (value < 0) 
                    throw new ArgumentOutOfRangeException(); 
                else year = value;
            }
        }
        public int Pages 
        { 
            get { return pages; }
            set 
            {
                if (value < 1) 
                    throw new ArgumentOutOfRangeException(); 
                else pages = value;
            }
        }
       
        public override int GetHashCode()
        {
            int result = Author.GetHashCode() * 31 + Title.GetHashCode();
            result *= 31;
            result += Year;
            result *= 31;
            result += Pages;
            return result;
        }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(other, this))
                return true;
            if (!String.Equals(Author, other.Author, StringComparison.CurrentCultureIgnoreCase) ||
                !String.Equals(Title, other.Title, StringComparison.CurrentCultureIgnoreCase) || 
                Year != other.Year || Pages != other.Pages)
                return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (ReferenceEquals(obj, this))
                return true;
            Book book = obj as Book;
            if (ReferenceEquals(book, null))
                return false;
            else
                return Equals(book);
        }

        public int CompareTo(Book other)
        {
            if (Equals(other))
                return 0;
            if (ReferenceEquals(other, null))
                return 1;
            return String.Compare(Title, other.Title, true);
        }
    }
}
