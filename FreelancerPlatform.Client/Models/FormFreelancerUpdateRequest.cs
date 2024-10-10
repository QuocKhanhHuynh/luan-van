namespace FreelancerPlatform.Client.Models
{
    public class FormFreelancerUpdateRequest
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public string? About { get; set; }
        public int? RateHour { get; set; }
        public List<int>? CategoryIds { get; set; }
        public List<int>? SkillIds { get; set; }
    }
}
