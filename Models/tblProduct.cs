namespace ATZClient.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProduct")]
    public partial class tblProduct
    {
        [Key]
        public int ProductID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string ProductCode { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? ProductType { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Manufacture { get; set; }

        [StringLength(50)]
        public string MadeIn { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public int? Status { get; set; }
    }
}
