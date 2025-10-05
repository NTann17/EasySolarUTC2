using Microsoft.EntityFrameworkCore;
using SolarK64.Models.Entities;

namespace SolarK64.Models.EF
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<KieuPhanHoi> KieuPhanHoi { get; set; }
        public DbSet<PhanHoi> PhanHoi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình cho KieuPhanHoi
            modelBuilder.Entity<KieuPhanHoi>(entity =>
            {
                // Đặt MaKieu làm khóa chính
                entity.HasKey(e => e.MaKieu);

                // Cấu hình các thuộc tính khác (tùy chọn)
                entity.Property(e => e.MaKieu)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.TenKieu)
                    .HasMaxLength(200)
                    .IsRequired();
            });

            // Cấu hình cho PhanHoi
            modelBuilder.Entity<PhanHoi>(entity =>
            {
                // Uid đã được đánh dấu [Key] nên tự động là khóa chính
                entity.HasKey(e => e.Uid);

                // Cấu hình khóa ngoại
                entity.HasOne<KieuPhanHoi>()
                    .WithMany()
                    .HasForeignKey(e => e.MaKieuPhanHoi)
                    .OnDelete(DeleteBehavior.Restrict); // Hoặc Cascade tùy yêu cầu

                // Cấu hình các thuộc tính khác (tùy chọn)
                entity.Property(e => e.MaKieuPhanHoi)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.HoVaTen)
                    .HasMaxLength(200);

                entity.Property(e => e.AnhDaiDien)
                    .HasMaxLength(500);

                entity.Property(e => e.NhanXet)
                    .HasMaxLength(1000);
            });
        }
    }
}
