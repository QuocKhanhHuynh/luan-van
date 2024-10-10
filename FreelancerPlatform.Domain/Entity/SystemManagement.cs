using FreelancerPlatform.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelancerPlatform.Domain.Entity
{
    [Table("quan_tri_vien")]
    public class SystemManagement : EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ma_quan_tri_vien")]
        public int Id { get; set; }

        [Required]
        [Column("ten_tai_khoan")]
        public string UserName { get; set; }

        [Required]
        [Column("mat_khau")]
        public string Password { get; set; }

        [Column("ho_ten")]
        public string? FullName { get; set; }

        [Column("so_dien_thoai")]
        public string? PhoneNumber { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Required]
        [Column("trang_thai_hoat_dong")]
        public bool Status { get; set; } = true;
        public List<Freelancer> Freelancers { get; set; }
        public List<Job> Jobs { get; set; }
        public List<SystemManagementRole> SystemManagementRoles { get; set; }
    }
}
