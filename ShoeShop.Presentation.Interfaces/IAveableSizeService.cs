using ShoeStore.Models;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IAveableSizeService
    {
        AveableSize Add(AveableSize item);
        bool Remove(AveableSize itemID);
        void Update(AveableSize item);
    }
}
