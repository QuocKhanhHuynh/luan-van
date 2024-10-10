using FreelancerPlatform.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancerPlatform.Domain.Entity
{
    [Table("ma_giao_dich")]
    public class Transaction : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ma_giao_dich")]
        public int Id { get; set; }

        [Required]
        [Column("so_tien")]
        public int Amount { get; set; }

        [Column("noi_dung")]
        public string? Content { get; set; }
    }
}
