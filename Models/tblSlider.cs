namespace ATZClient.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSlider")]
    public partial class tblSlider
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public string ImgUrl { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int? Status { get; set; }
    }
}
