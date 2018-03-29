namespace ASP_assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class golf2
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string sponsor { get; set; }

        [Required]
        [StringLength(50)]
        public string driver { get; set; }

        [Required]
        [StringLength(50)]
        public string putter { get; set; }

        public int? golferID { get; set; }

        public virtual golf1 golf1 { get; set; }
    }
}
