using ShoeStore.Models;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IPictureService
    {
        Picture Add(Picture item);
        bool Remove(Picture itemID);
        void Update(Picture item);
    }
}
