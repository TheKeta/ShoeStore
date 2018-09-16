using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IPictureService
    {
        void Add(ICollection<HttpPostedFileBase> images, Guid itemId);
        bool RemoveByItemId(Guid itemID);
        void Update(Picture item);
        ICollection<Picture> FindByItemId(Guid itemId);
    }
}
