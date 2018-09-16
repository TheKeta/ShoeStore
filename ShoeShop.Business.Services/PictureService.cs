using ShoeShop.Business.Interfaces;
using ShoeShop.Presentation.Interfaces;
using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoeShop.Business.Services
{
    public class PictureService : IPictureService
    {
        private IPictureRepository _pictureRepository;

        public PictureService(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        public void Add(ICollection<HttpPostedFileBase> images, Guid itemId)
        {
            foreach(HttpPostedFileBase file in images)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();

                    Picture pic = new Picture();
                    pic.Id = Guid.NewGuid();
                    pic.Image = array;
                    pic.ItemId = itemId;
                    _pictureRepository.Add(pic);
                }
            }
        }

        public ICollection<Picture> FindByItemId(Guid itemId)
        {
            return _pictureRepository.FindByItemId(itemId);
        }

        public bool RemoveByItemId(Guid itemID)
        {
            return _pictureRepository.RemoveByItemId(itemID);
        }

        public void Update(Picture item)
        {
            throw new NotImplementedException();
        }
    }
}
