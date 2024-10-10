using FreelancerPlatform.Application.Dtos.Job;
using FreelancerPlatform.Application.Dtos.Potient;

namespace FreelancerPlatform.Client.Models
{
    public class NavigateFreelancerViewModel
    {
        public List<JobQuickViewModel> FavoriteJobs { get; set; }
        public List<JobQuickViewModel> JobApplies { get; set; }
    }
}
