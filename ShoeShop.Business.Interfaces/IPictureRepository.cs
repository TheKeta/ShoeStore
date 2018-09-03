using ShoeStore.Models;

namespace ShoeShop.Business.Interfaces
{
    public interface IPictureRepository
    {
        Picture Add(Picture item);
        bool Remove(Picture itemID);
        void Update(Picture item);
    }
}
