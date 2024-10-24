using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entities
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ChamCong> ChamCong { get; set; }
        public virtual DbSet<ChucVu> ChucVu { get; set; }
        public virtual DbSet<HopDong> HopDong { get; set; }
        public virtual DbSet<Luong> Luong { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<PhongBan> PhongBan { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TongLuong> TongLuong { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public DbSet<UngLuong> UngLuong { get; set; }
        public DbSet<ThongBaoSuKien> ThongBaoSuKien { get; set; }
        public DbSet<ThongBaoNhanVien> ThongBaoNhanVien { get; set; }

  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.Luong)
                .WithOptional(e => e.NhanVien)
                .WillCascadeOnDelete();
        }
    }
}
