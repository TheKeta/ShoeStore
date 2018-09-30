using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Business.Interfaces
{
    public interface IAvailableSizeRepository
    {
        AvailableSize Add(AvailableSize item);
        bool Remove(Guid itemID);
        void Update(AvailableSize item);
        ICollection<AvailableSize> FindBySIId(Guid siId);
        AvailableSize FindBySIIdAndSize(Guid siId, double size);
        bool RemoveBySIIdAndSize(Guid siId, double size);

    }
}
