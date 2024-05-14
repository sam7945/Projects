using Hevadea.Entities;
using Hevadea.Items;
using Hevadea.Utils;
using Hevadea.Worlds;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hevadea.Models
{
    public class WorldPlayer
    {
        public int WorldPlayerId { get; set; }
        public World World { get; set; }
        public Player Player { get; set; }
        public Account Account { get; set; }

      

        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public int CurrentLevelLevelId { get; set; }
        public Direction Facing { get; set; }
        public int HoldedItemId { get; set; }
        public Level CurrentLevel { get; set; }
        public string RideIdentifier { get; set; }
        public string PickedUpEntityIdentifier { get; set; }
        public ICollection<InventorySlot> Inventory { get; set; }
        public ICollection<LevelMinimap> Minimaps { get; set; }
    }
}
