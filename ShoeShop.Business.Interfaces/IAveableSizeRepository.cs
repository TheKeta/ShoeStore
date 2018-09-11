using ShoeStore.Models;
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
        bool Remove(AveableSize itemID);
        void Update(AveableSize item);
        ICollection<AveableSize> FindBySIId(Guid siId);
    }
}
