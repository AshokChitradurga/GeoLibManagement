namespace GeoLib.Data
{
    using Business.Entities;
    using Common.Contracts;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class GeoLibDbContext : DbContext
    {
        public GeoLibDbContext() : base("Name=ZipCodeData")
        {
            Database.SetInitializer<GeoLibDbContext>(null);
        }

        public DbSet<ZipCode> ZipCodeSet { get; set; }
        public DbSet<State> ZipStateSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Ignore<IIdentityKey>();

            modelBuilder.Entity<ZipCode>()
                        .HasKey<int>(zipcode => zipcode.ZipCodeId)
                        .Ignore(entity => entity.EntityId)
                        .HasRequired(e => e.State)
                        .WithMany()
                        .HasForeignKey(e => e.StateId);
            modelBuilder.Entity<State>().HasKey<int>(state => state.StateId).Ignore(entity => entity.EntityId);
        }
    }
}
