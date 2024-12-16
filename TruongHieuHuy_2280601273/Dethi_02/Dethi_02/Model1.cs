using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Dethi_02
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiSP>()
                .Property(e => e.TypeCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.SPCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.TypeCode)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
