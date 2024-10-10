using FreelancerPlatform.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerPlatform.Application.Dtos.Freelancer
{
    public class FreelancerUpdateRequest
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
        public int? RateHour { get; set; }
        public List<int> CategoryIds { get; set; }
        public List<int> SkillIds { get; set; }
    }
}
