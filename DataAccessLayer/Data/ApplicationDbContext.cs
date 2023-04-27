using Microsoft.EntityFrameworkCore;
using SmartBiddingCommon.SqlDbModel;

namespace SmartBiddingDLL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<SystemUser> SystemUsers { get; set; }
        public virtual DbSet<BidOrders> BidsOrder { get; set; }
        public virtual DbSet<BidderBidRegistration> BidderBidRegistrations { get; set; }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductId").HasDefaultValueSql("(newid())");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200).IsUnicode(false);
                entity.Property(e => e.Description).HasMaxLength(500).IsUnicode(false);
               // entity.HasOne(a => a.ProductCategory).WithMany(c => c.Products).HasForeignKey(c => c.ProductCategoryId).HasConstraintName("FL_Product_ProductCategories");
               // entity.WithMany(b => b.Products).HasForeignKey(c => c.ProductCategoryId).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FL_Product_ProductCategories");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryId").HasDefaultValueSql("(newid())");
                entity.Property(e => e.Description).IsRequired(true).HasMaxLength(200).IsUnicode(false);
                //entity.HasMany(a => a.Products);//.WithOne(b => b.ProductCategory);//.HasForeignKey(b => b.ProductCategoryId);
            });

            modelBuilder.Entity<SystemUser>(entity =>
            {
                entity.HasIndex(e => e.Email).HasName("CK_SystemUser_EmailAddress").IsUnique();
                entity.Property(e => e.UserId).HasColumnName("UserId").HasDefaultValueSql("(newid())");
                entity.Property(e => e.Mobile).HasMaxLength(25).IsUnicode(false);
                entity.Property(e => e.Phone).HasMaxLength(25).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(25).IsUnicode(false);
                entity.Property(e => e.DOB).HasColumnType("datetime");
                entity.Property(e => e.JoinDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e=>e.IsVerified).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<BidOrders>(entity =>
            {
                entity.Property(e => e.BidOrderId).HasColumnName("BidOrderId").HasDefaultValueSql("(newid())");
                entity.Property(e => e.BidStartTime).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.BidEndTime).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.Property(e => e.BasePrice).HasMaxLength(10).IsUnicode(false);
                entity.HasOne(a => a.Product);
            });

            modelBuilder.Entity<BidderBidRegistration>(entity =>
            {
                entity.Property(e => e.BidderRegistrationId).HasColumnName("BidderRegistrationId").HasDefaultValueSql("(newid())");
                entity.Property(e => e.RegistrationDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
                entity.HasOne(a => a.SystemUser);
                entity.HasOne(a => a.BidOrder);
            });

            //OnModelCreatingPartial(modelBuilder);
        }
        //private void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
