using System;
using System.Collections.Generic;
using System.IO;

namespace Task3.Library
{
    public class FileBookRepository: IRepository<Book>
    {
        private readonly string path;
        public FileBookRepository(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException();
            }
            this.path = path;
        }

        public List<Book> LoadItems()
        {
            return ReadListFromFile();
        }

        public void StoreItems(List<Book> items)
        {
            if (ReferenceEquals(items, null))
                throw new ArgumentNullException();
            WriteListToFile(items);
        }

        public void AddItem(Book item)
        {
            if (ReferenceEquals(item, null))
                throw new ArgumentNullException();
            AppendBookToFile(item);
        }

        private void AppendBookToFile(Book book)
        {
            Stream fileStream = File.Open(path, FileMode.Append, FileAccess.Write);
            using (BinaryWriter output = new BinaryWriter(fileStream))
            {
                output.Write(book.Author);
                output.Write(book.Title);
                output.Write(book.Year);
                output.Write(book.Pages);
            }
        }


        private void WriteListToFile(List<Book> list)
        {
            Stream fileStream = File.Open(path, FileMode.Truncate, FileAccess.Write);
            using (BinaryWriter output = new BinaryWriter(fileStream))
            {
                foreach (var book in list)
                {
                    output.Write(book.Author);
                    output.Write(book.Title);
                    output.Write(book.Year);
                    output.Write(book.Pages);
                }
            }
        }

        private List<Book> ReadListFromFile()
        {
            List<Book> list = new List<Book>();
            Stream fileStream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
            using (BinaryReader input = new BinaryReader(fileStream))
            {
                while (input.BaseStream.Position < input.BaseStream.Length)
                {
                    Book book = new Book();
                    book.Author = input.ReadString();
                    book.Title = input.ReadString();
                    book.Year = input.ReadInt32();
                    book.Pages = input.ReadInt32();
                    list.Add(book);
                }
            }
            return list;
        }
    }
}
