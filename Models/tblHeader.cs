namespace ATZClient.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblHeader")]
    public partial class tblHeader
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TITLE { get; set; }

        [StringLength(50)]
        public string EMAIL { get; set; }

        [StringLength(50)]
        public string CONTACT { get; set; }

        [Required]
        [StringLength(50)]
        public string STATUS { get; set; }
    }
}
