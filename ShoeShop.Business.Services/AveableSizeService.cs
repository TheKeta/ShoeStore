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
    public class AveableSizeService : IAveableSizeService
    {
        private IAveableSizeRepository _aveableSizeRepository;

        public AveableSizeService(IAveableSizeRepository aveableSizeRepository)
        {
            _aveableSizeRepository = aveableSizeRepository;
        }

        public AveableSize Add(AveableSize item)
        {
            //proveriti da li ima taj ssid sa tom velicinom
            AveableSize ass = _aveableSizeRepository.FindBySIIdAndSize(item.SIId, item.Size);
            if (ass == null)
            {
                item.Id = Guid.NewGuid();
                return _aveableSizeRepository.Add(item);
            }
            return ass;
            
        }

        public ICollection<AveableSize> FindBySIId(Guid siId)
        {
            return _aveableSizeRepository.FindBySIId(siId);
        }

        public bool Remove(AveableSize itemID)
        {
            throw new NotImplementedException();
        }

        public void Update(AveableSize item)
        {
            throw new NotImplementedException();
        }
    }
}
