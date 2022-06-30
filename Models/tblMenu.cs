namespace ATZClient.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblMenu
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Parent_id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Level { get; set; }

        [StringLength(10)]
        public string Status { get; set; }
    }
}
