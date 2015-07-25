using System;
using System.Collections.Generic;

namespace Task3.Library
{
    public class BookListService
    {
        private ILogger logger;
        private IRepository<Book> repository;
        private List<Book> list = new List<Book>();

        public BookListService(IRepository<Book> repository)
            : this(repository, new NloggerAdapter())
        {
        }

        public BookListService(IRepository<Book> repository, ILogger logger)
        {
            if (ReferenceEquals(logger, null) || ReferenceEquals(repository, null))
            {
                Exception e = new ArgumentNullException();
                logger.Error("Trying to create object with null argument.", e);
                throw e;
            }
            this.logger = logger;
            this.repository = repository;
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                Exception e =  new ArgumentNullException();
                logger.Error("Adding null to storage.", e);
                throw e;
            }
            if (!Contains(book))
            {
                list.Add(book);
                repository.AddItem(book);
                logger.Debug("Book added.");
            }
            else
                logger.Debug("Trying to add a book that is already in the storage.");
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                Exception e = new ArgumentNullException();
                logger.Error("Removing null from storage.", e);
                throw e;
            }
            if (!Contains(book))
            {
                Exception e = new ArgumentException();
                logger.Error("trying to remove book from storage that is not there.", e);
                throw e;
            }
            else{
                list.Remove(book);
                repository.StoreItems(list);
                logger.Debug("Book removed.");

            }
        }

        public bool Contains(Book book)
        {
            list = repository.LoadItems();
            return list.Contains(book);
        }

        public List<Book> FindByTitle(string title)
        {
            return FindAll((Book b) => String.Equals(b.Title, title, StringComparison.CurrentCultureIgnoreCase));
        }

        public void SortBookByTitle()
        {
            Sort((Book b1, Book b2) => string.Compare(b1.Title, b2.Title, true));
        }

        public List<Book> FindByAuthor(string author)
        {
            return FindAll((Book b) => String.Equals(b.Author, author, StringComparison.CurrentCultureIgnoreCase));
        }

        public void SortBookByAuthor()
        {
            Sort((Book b1, Book b2) => string.Compare(b1.Author, b2.Author, true));
        }
        
        public List<Book> FindByYear(int year)
        {
            return FindAll((Book b) => b.Year == year);
        }

        public void SortBookByYear()
        {
            Sort((Book b1, Book b2) => b1.Year.CompareTo(b2.Year));
        }

        public List<Book> FindByPages(int pages)
        {
            return FindAll((Book b) => b.Pages == pages);
        }

        public void SortBookByPages()
        {
            Sort((Book b1, Book b2) => b1.Pages.CompareTo(b2.Pages));
        }

        public List<Book> FindAll(Predicate<Book> criteria)
        {
            list = repository.LoadItems();
            return list.FindAll(criteria);
        }

        public void Sort(Comparison<Book> comparison)
        {
            list = repository.LoadItems();
            list.Sort(comparison);
            repository.StoreItems(list);
        }
    }
}
