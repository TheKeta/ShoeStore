﻿using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Business.Interfaces
{
    public interface IAveableSizeRepository
    {
        AveableSize Add(AveableSize item);
        bool Remove(Guid itemID);
        void Update(AveableSize item);
        ICollection<AveableSize> FindBySIId(Guid siId);
        AveableSize FindBySIIdAndSize(Guid siId, double size);
        bool RemoveBySIIdAndSize(Guid siId, double size);

    }
}
