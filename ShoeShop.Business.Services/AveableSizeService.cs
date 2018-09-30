using ShoeShop.Business.Interfaces;
using ShoeShop.Presentation.Interfaces;
using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Business.Services
{
    public class AvailableSizeService : IAvailableSizeService
    {
        private IAvailableSizeRepository _AvailableSizeRepository;

        public AvailableSizeService(IAvailableSizeRepository AvailableSizeRepository)
        {
            _AvailableSizeRepository = AvailableSizeRepository;
        }

        public AvailableSize Add(AvailableSize item)
        {
            //proveriti da li ima taj ssid sa tom velicinom
            AvailableSize ass = _AvailableSizeRepository.FindBySIIdAndSize(item.SIId, item.Size);
            if (ass == null)
            {
                item.Id = Guid.NewGuid();
                return _AvailableSizeRepository.Add(item);
            }
            return ass;
            
        }

        public bool RemoveBySIIdAndSize(Guid siId, double size)
        {
            return _AvailableSizeRepository.RemoveBySIIdAndSize(siId, size);
        }

        public ICollection<AvailableSize> FindBySIId(Guid siId)
        {
            return _AvailableSizeRepository.FindBySIId(siId);
        }

        public bool Remove(AvailableSize itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(AvailableSize item)
        {
            throw new NotImplementedException();
        }

        public AvailableSize FindBySIIdAndSize(Guid siId, double size)
        {
            return _AvailableSizeRepository.FindBySIIdAndSize(siId, size);
        }
    }
}
