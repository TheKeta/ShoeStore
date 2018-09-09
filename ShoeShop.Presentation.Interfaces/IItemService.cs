using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IItemService : IDisposable
    {
        Item Add(Item item);
        bool Remove(Guid id);
        void Update(Item id);
        ICollection<Item> GetAll();
        Item FindById(Guid id);
        ICollection<Item> Search(string model, string brand, string sex);
    }
}
