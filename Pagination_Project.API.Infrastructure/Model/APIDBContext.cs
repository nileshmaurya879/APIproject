using Microsoft.EntityFrameworkCore;

namespace Pagination_Project.API.Infrastructure.Model
{
    public partial class APIDBContext : DbContext
    {
        public APIDBContext() { }
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options){ 
        }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<TblInstance> TblInstances { get; set; }
        public virtual DbSet<TblLineNumberFormat> TblLineNumberFormats { get; set; }
        public virtual DbSet<TblLineNumberFormatSection> TblLineNumberFormatSections { get; set; }
        public virtual DbSet<TblLineNumberFormatSectionType> TblLineNumberFormatSectionTypes { get; set; }
        public virtual DbSet<TestSecurityRole> TestSecurityRoles { get; set; }
        public virtual DbSet<TestSecurityRolePermission> TestSecurityRolePermissions { get; set; }
        public virtual DbSet<TestAddress> TestAddresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            
            modelBuilder.Entity<TblInstance>(entity => {
                entity.HasKey(e=>e.InstanceId);
                entity.ToTable("TblInstance");
            });
           

            modelBuilder.Entity<TblLineNumberFormat>(entity =>
            {
                entity.HasKey(e => e.LineNumberFormatId);
                entity.ToTable("TblLineNumberFormat");
            });
            modelBuilder.Entity<TblLineNumberFormatSection>(entity =>
            {
                entity.HasKey(e => e.LineNumberFormatSectionId);
                entity.ToTable("TblLineNumberFormatSection");
            });

            modelBuilder.Entity<TblLineNumberFormatSectionType>(entity =>
            {
                entity.HasKey(e => e.LineNumberFormatSectionTypeId);
                entity.ToTable("TblLineNumberFormatSectionType");
            });

            modelBuilder.Entity<TestAddress>(entity =>
            {
                entity.HasKey(e => e.AddressID);
                entity.ToTable("TestAddress");
            });

            modelBuilder.Entity<TestSecurityRole>().ToTable("testSecurityRole");
            modelBuilder.Entity<TestSecurityRolePermission>().ToTable("TestSecurityRolePermission");
            
        }
    }
}
