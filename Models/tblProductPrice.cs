namespace ATZClient.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProductPrice")]
    public partial class tblProductPrice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? ProductID { get; set; }

        public decimal? Price { get; set; }

        public decimal? PriceSale { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateIssued { get; set; }

        public int? IsDate { get; set; }
    }
}
