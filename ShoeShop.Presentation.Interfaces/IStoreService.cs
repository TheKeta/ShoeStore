﻿using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShop.Presentation.Interfaces
{
    public interface IStoreService
    {
        Store Add(Store item);
        bool Remove(Store itemID);
        void Update(Store item);
        ICollection<Store> GetAll();
        Store FindById(Guid id);
    }
}
