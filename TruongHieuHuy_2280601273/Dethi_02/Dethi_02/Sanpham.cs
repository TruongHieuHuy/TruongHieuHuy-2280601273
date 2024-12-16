namespace Dethi_02
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sanpham")]
    public partial class Sanpham
    {
        [Key]
        [StringLength(6)]
        public string SPCode { get; set; }

        [Required]
        [StringLength(30)]
        public string SPName { get; set; }

        public DateTime DateTime { get; set; }

        [StringLength(2)]
        public string TypeCode { get; set; }

        public virtual LoaiSP LoaiSP { get; set; }
    }
}
