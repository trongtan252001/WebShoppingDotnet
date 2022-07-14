using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebShoppingDotnet.Models
{
    public partial class ShopthoitrangContext : DbContext
    {
        public ShopthoitrangContext()
        {
        }

        public ShopthoitrangContext(DbContextOptions<ShopthoitrangContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bosutap> Bosutaps { get; set; } = null!;
        public virtual DbSet<Cthoadon> Cthoadons { get; set; } = null!;
        public virtual DbSet<Giohang> Giohangs { get; set; } = null!;
        public virtual DbSet<Hinhanh> Hinhanhs { get; set; } = null!;
        public virtual DbSet<Hoadon> Hoadons { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Loaisp> Loaisps { get; set; } = null!;
        public virtual DbSet<Nhanxet> Nhanxets { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Quangcao> Quangcaos { get; set; } = null!;
        public virtual DbSet<Term> Terms { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;port=3306;database=shopnet", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_unicode_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Bosutap>(entity =>
            {
                entity.HasKey(e => e.IdBst)
                    .HasName("PRIMARY");

                entity.ToTable("bosutap");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.IdBst).HasColumnName("IdBST");

                entity.Property(e => e.Check)
                    .HasColumnType("int(11)")
                    .HasColumnName("check");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .HasColumnName("img");

                entity.Property(e => e.MotaBst)
                    .HasColumnType("text")
                    .HasColumnName("motaBST");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .HasColumnName("name");

                entity.Property(e => e.Tieude)
                    .HasMaxLength(500)
                    .HasColumnName("tieude");
            });

            modelBuilder.Entity<Cthoadon>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.MaHd,
                    e.Size,e.MaSp
                }).HasName("PRIMARY");


                entity.ToTable("cthoadon");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.MaHd, "ma_hd_pk");

                entity.HasIndex(e => e.MaSp, "ma_sp_pk_ct");

                entity.Property(e => e.MaHd).HasColumnName("MaHD");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.Price).HasColumnName("PRICE");

                entity.Property(e => e.Size)
                    .HasMaxLength(255)
                    .HasColumnName("SIZE");

                entity.Property(e => e.SoLuong).HasColumnType("int(11)");

                entity.HasOne(d => d.MaHdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaHd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ma_hd_pk");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ma_sp_pk_ct");
            });

            modelBuilder.Entity<Giohang>(entity =>
            {
                entity.ToTable("giohang");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Idsp, "prokey_idSP");

                entity.HasIndex(e => e.Iduser, "prokey_idUser");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Idsp).HasColumnName("IDSP");

                entity.Property(e => e.Iduser).HasColumnName("IDUSER");

                entity.Property(e => e.Size)
                    .HasMaxLength(255)
                    .HasColumnName("SIZE");

                entity.Property(e => e.Soluong)
                    .HasColumnType("int(11)")
                    .HasColumnName("SOLUONG")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.IdspNavigation)
                    .WithMany(p => p.Giohangs)
                    .HasForeignKey(d => d.Idsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prokey_idSP");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Giohangs)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prokey_idUser");
            });

            modelBuilder.Entity<Hinhanh>(entity =>
            {
                entity.HasKey(e => e.Idhinhanh)
                    .HasName("PRIMARY");

                entity.ToTable("hinhanh");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Idsp, "IDSP");
                entity.Property(e => e.Idhinhanh).HasColumnName("IDHINHANH");


                entity.Property(e => e.Idsp).HasColumnName("IDSP");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .HasColumnName("URL");

                entity.HasOne(d => d.IdspNavigation)
                    .WithMany(p=>p.Hinhanhs)
                    .HasForeignKey(d => d.Idsp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hinhanh_ibfk_1");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahoadon)
                    .HasName("PRIMARY");

                entity.ToTable("hoadon");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Iduser, "iduset_pk_hd");

                entity.Property(e => e.Mahoadon).HasColumnName("MAHOADON");

                entity.Property(e => e.Iduser).HasColumnName("IDUSER");

                entity.Property(e => e.NgayDatHang).HasColumnType("datetime");

                entity.Property(e => e.NgayNhanHang).HasColumnType("datetime");

                entity.Property(e => e.SoNgayDuKien).HasColumnType("int(11)");

                entity.Property(e => e.TongTien).HasColumnName("tongTien");

                entity.Property(e => e.TrangThai).HasColumnType("int(11)");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("iduset_pk_hd");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PRIMARY");

                entity.ToTable("khachhang");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Iduser).HasColumnName("IDUSER");

                entity.Property(e => e.DiaChi).HasMaxLength(255);

                entity.Property(e => e.DienThoai).HasMaxLength(11);

                entity.Property(e => e.HoTen).HasMaxLength(255);

                entity.Property(e => e.PhuongXa).HasMaxLength(255);

                entity.Property(e => e.QuanHuyen).HasMaxLength(255);

                entity.Property(e => e.TinhTp)
                    .HasMaxLength(255)
                    .HasColumnName("TinhTP");

                entity.HasOne(d => d.IduserNavigation)
                    .WithOne(p => p.Khachhang)
                    .HasForeignKey<Khachhang>(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("iduser_pk");
            });

            modelBuilder.Entity<Loaisp>(entity =>
            {
                entity.HasKey(e => e.Idloai)
                    .HasName("PRIMARY");

                entity.ToTable("loaisp");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Idloai).HasColumnName("IDLOAI");

                entity.Property(e => e.Motatheloai)
                    .HasColumnType("text")
                    .HasColumnName("MOTATHELOAI");

                entity.Property(e => e.NameLoai).HasMaxLength(255);
            });

            modelBuilder.Entity<Nhanxet>(entity =>
            {
                entity.HasKey(e => e.IdnhanXet)
                    .HasName("PRIMARY");

                entity.ToTable("nhanxet");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Iduser, "fk_nhan_xet");

                entity.Property(e => e.IdnhanXet).HasColumnName("IDNhanXet");

                entity.Property(e => e.Iduser).HasColumnName("IDUSER");

                entity.Property(e => e.Imguser)
                    .HasMaxLength(255)
                    .HasColumnName("IMGUSER");

                entity.Property(e => e.Job)
                    .HasMaxLength(255)
                    .HasColumnName("JOB");

                entity.Property(e => e.Ngay).HasColumnName("NGAY");

                entity.Property(e => e.Nhanxet1)
                    .HasColumnType("text")
                    .HasColumnName("NHANXET");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.Nhanxets)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_nhan_xet");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("PRIMARY");

                entity.ToTable("products");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.IdboSuuTap, "khoangoai1pro");

                entity.HasIndex(e => e.Loaisp, "khoangoai2pro");

                entity.Property(e => e.Masp).HasColumnName("MASP");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.IdboSuuTap).HasColumnName("IDBoSuuTap");

                entity.Property(e => e.L).HasColumnType("int(11)");

                entity.Property(e => e.Loaisp)
                    .HasMaxLength(50)
                    .HasColumnName("LOAISP");

                entity.Property(e => e.M).HasColumnType("int(11)");

                entity.Property(e => e.Mau)
                    .HasMaxLength(50)
                    .HasColumnName("MAU");

                entity.Property(e => e.Mota)
                    .HasColumnType("text")
                    .HasColumnName("MOTA");

                entity.Property(e => e.Ngaybatdausale).HasColumnName("NGAYBATDAUSALE");

                entity.Property(e => e.Ngayketthucsale).HasColumnName("NGAYKETTHUCSALE");

                entity.Property(e => e.Ngaynhap).HasColumnName("NGAYNHAP");

                entity.Property(e => e.S).HasColumnType("int(11)");

                entity.Property(e => e.Sale).HasColumnName("SALE");

                entity.Property(e => e.Tensp)
                    .HasMaxLength(255)
                    .HasColumnName("TENSP");

                entity.Property(e => e.Trangthai)
                    .HasColumnType("int(11)")
                    .HasColumnName("TRANGTHAI");

                entity.Property(e => e.Xl)
                    .HasColumnType("int(11)")
                    .HasColumnName("XL");

                entity.HasOne(d => d.IdboSuuTapNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdboSuuTap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("khoangoai1pro");

                entity.HasOne(d => d.LoaispNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Loaisp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("khoangoai2pro");
            });

            modelBuilder.Entity<Quangcao>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("quangcao");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.Id)
                    .HasMaxLength(255)
                    .HasColumnName("id");

                entity.Property(e => e.Mota)
                    .HasColumnType("text")
                    .HasColumnName("mota");

                entity.Property(e => e.Tieude)
                    .HasMaxLength(500)
                    .HasColumnName("tieude");

                entity.Property(e => e.Url)
                    .HasMaxLength(255)
                    .HasColumnName("url");

                entity.Property(e => e.UrlImg)
                    .HasMaxLength(500)
                    .HasColumnName("urlImg");
            });

            modelBuilder.Entity<Term>(entity =>
            {
                entity.ToTable("term");

                entity.UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content).HasColumnName("content");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.Usermail, "USERMAIL")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "USERNAME")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dateregister)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("DATEREGISTER");

                entity.Property(e => e.Isvirification)
                    .HasColumnType("int(11)")
                    .HasColumnName("ISVIRIFICATION");

                entity.Property(e => e.Role)
                    .HasColumnType("int(11)")
                    .HasColumnName("ROLE");

                entity.Property(e => e.Usermail)
                    .HasMaxLength(50)
                    .HasColumnName("USERMAIL");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Userpassword)
                    .HasMaxLength(500)
                    .HasColumnName("USERPASSWORD");

                entity.Property(e => e.Vericaioncode)
                    .HasMaxLength(255)
                    .HasColumnName("VERICAIONCODE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
