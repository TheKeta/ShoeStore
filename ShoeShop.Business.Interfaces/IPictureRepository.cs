using ShoeStore.Models;
using System;
using System.Collections.Generic;

namespace ShoeShop.Business.Interfaces
{
    public interface IPictureRepository
    {
        Picture Add(Picture item);
        bool RemoveByItemId(Guid itemID);
        void Update(Picture item);
        ICollection<Picture> FindByItemId(Guid itemId);

    }
}
