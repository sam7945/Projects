using Hevadea.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Models
{
    public class InventorySlot
    {
        public int InventorySlotId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public WorldPlayer WorldPlayer { get; set; }
    }
}
