using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeStore.Models
{
    public class AvailableSize
    {
        public Guid Id { get; set; }
        public Guid SIId { get; set; } //store_item ID
        public double Size { get; set; }
    }
}
