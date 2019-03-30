namespace ZeusSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayInfo")]
    public partial class PayInfo
    {
        [Key]
        public int PayStubId { get; set; }

        public int EmployeeID { get; set; }

        public decimal Pay { get; set; }

        [Required]
        [StringLength(50)]
        public string Month { get; set; }

        public virtual EmplyeeInfo EmplyeeInfo { get; set; }
    }
}
