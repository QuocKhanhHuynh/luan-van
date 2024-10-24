using FreelancerPlatform.Application.Abstraction.Service;
using FreelancerPlatform.Application.Dtos.Comment;
using FreelancerPlatform.Application.Dtos.Common;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerPlatform.Client.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IFreelancerService _freelancerService;
        public CommentController(ICommentService commentService, IFreelancerService freelancerService)
        {
            _commentService = commentService;
            _freelancerService = freelancerService;
        }
        public async Task<IActionResult> CreateComment(CommentCreateRequest request)
        {
            var response = await _commentService.CreatePost(request);
            if (response.Status != StatusResult.Success)
            {
                return BadRequest();
            }
            var freelancer = await _freelancerService.GetFreelancerAsync(request.FreelancerId);
            return Ok(freelancer.ImageUrl);
        }
        [HttpPost]
        public async Task<IActionResult> GetCommentOfPost(int postId)
        {
            var response = await _commentService.GetCommentParent(postId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetCommentOfParent(int parent)
        {
            var response = await _commentService.GetCommentReply(parent);
            return Ok(response);
        }
    }
}
