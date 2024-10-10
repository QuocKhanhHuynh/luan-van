using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreelancerPlatform.Application.Dtos.Category;
using FreelancerPlatform.Domain.Entity;
using FreelancerPlatform.Application.Dtos.Skill;

namespace FreelancerPlatform.Application.Dtos.Freelancer
{
    public class FreelancerViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public string FirstName { get; set; }
        public string BankNumber { get; set; }
        public string BankName { get; set; }
        public string About { get; set; }
        public int? RateHour { get; set; }
        public bool PaymentVerification { get; set; }
        public List<CategoryQuickViewModel> Categories { get; set; }
        public List<SkillQuickViewModel> Skills { get; set; }
    }
}
