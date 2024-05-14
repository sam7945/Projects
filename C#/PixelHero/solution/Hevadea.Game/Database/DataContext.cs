namespace Hevadea.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Hevadea.Entities;
    using Hevadea.Models;
    using Hevadea.Worlds;
    using Hevadea.Items;
    using Hevadea.Registry;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<WorldPlayer> WorldPlayers { get; set; }
        public DbSet<World> Worlds { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<InventorySlot> InventorySlots { get; set; }
        public DbSet<LevelMinimap> LevelMinimaps { get; set; }
        public DbSet<Minimap> Minimaps { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
        public override int SaveChanges()
        {
            REGISTRY.Mutex.WaitOne();
            int i = base.SaveChanges();
            REGISTRY.Mutex.ReleaseMutex();
            return i;
        }
    }
}
