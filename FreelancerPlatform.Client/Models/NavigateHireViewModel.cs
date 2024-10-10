using FreelancerPlatform.Application.Dtos.Job;
using FreelancerPlatform.Application.Dtos.Potient;

namespace FreelancerPlatform.Client.Models
{
    public class NavigateHireViewModel
    {
        public List<PotientQuickViewModel> Potients { get; set; }
        public List<JobQuickViewModel> JobPosts { get; set; }
    }
}
