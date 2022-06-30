using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Persistence
{
    public partial class eTaxiDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {

        public eTaxiDbContext(DbContextOptions<eTaxiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleType> VehicleTypes { get; set; }
        public virtual DbSet<Hub> Hubs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");



            modelBuilder.Entity<ApplicationUser>(entity =>
            {


                entity.ToTable("ApplicationUser");

                entity.Property(e => e.Email).HasMaxLength(30);

            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.OriginalName).HasMaxLength(100);

            });

            base.OnModelCreating(modelBuilder);

            Seed.OnModelCreating(modelBuilder);

        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
