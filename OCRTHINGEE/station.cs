using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace OCRTHINGEE
{
    public class elite_testingEntities : DbContext
    {
        public DbSet<station> Stations { get; set; }
        public DbSet<tradeitem> Tradeitems { get; set; }
        public DbSet<system> Systems { get; set; }
        public DbSet<item> Items { get; set; }
    }

    public class station
    {
        [Key]
        public int stationId { get; set; }

        public int sysid { get; set; }
        public string name { get; set; }
        public virtual ICollection<tradeitem> tradeitems { get; set; }
        public virtual system system { get; set; }
    }

    public class item
    {
        [Key]
        public int itemId { get; set; }

        public string name { get; set; }
        public virtual ICollection<tradeitem> tradeitems { get; set; }
    }

    public class tradeitem
    {
        [Key]
        public long ProductsId { get; set; }

        public int stationid { get; set; }
        public int itemid { get; set; }
        public int? buyprice { get; set; }
        public int? sellprice { get; set; }
        public int? supply { get; set; }
        public DateTime? lastupdate { get; set; }
        public virtual item item { get; set; }
        public virtual station station { get; set; }
    }

    public class system
    {
        [Key]
        public int sysId { get; set; }

        public string name { get; set; }
        public virtual ICollection<station> stations { get; set; }
    }
}