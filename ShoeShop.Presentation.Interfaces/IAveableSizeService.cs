using ShoeStore.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IAveableSizeService
    {
        AveableSize Add(AveableSize item);
        bool Remove(AveableSize itemID);
        void Update(AveableSize item);
        ICollection<AveableSize> FindBySIId(Guid siId);
    }
}
