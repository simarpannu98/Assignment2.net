namespace ASP_assignment.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class golfModel : DbContext
    {
        public golfModel()
            : base("name=defaultConnection")
        {
        }

        public virtual DbSet<golf1> golf1 { get; set; }
        public virtual DbSet<golf2> golf2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<golf1>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<golf1>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<golf2>()
                .Property(e => e.sponsor)
                .IsUnicode(false);

            modelBuilder.Entity<golf2>()
                .Property(e => e.driver)
                .IsUnicode(false);

            modelBuilder.Entity<golf2>()
                .Property(e => e.putter)
                .IsUnicode(false);
        }
    }
}
