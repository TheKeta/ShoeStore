using ShoeStore.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IAvailableSizeService
    {
        AvailableSize Add(AvailableSize item);
        bool Remove(AvailableSize itemID);
        void Update(AvailableSize item);
        ICollection<AvailableSize> FindBySIId(Guid siId);
        bool RemoveBySIIdAndSize(Guid siId, double size);
        AvailableSize FindBySIIdAndSize(Guid siId, double size);


    }
}
