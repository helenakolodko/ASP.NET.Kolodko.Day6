using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Library
{
    public interface IRepository<T>
    {
        List<T> LoadItems();
        void StoreItems(List<T> items);
        void AddItem(T item);
    }
}
