using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore.Models
{
    public class StoreItem
    {
        public Guid Id { get; set; }
        public Guid StoreId { get; set; }
        public Guid ItemId { get; set; }
        public double Price { get; set; }
        public ICollection<AveableSize> AveableSizes { get; set; }
    }
}
