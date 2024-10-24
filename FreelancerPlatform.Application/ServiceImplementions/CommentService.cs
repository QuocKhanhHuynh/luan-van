using AutoMapper;
using FreelancerPlatform.Application.Abstraction.Repository;
using FreelancerPlatform.Application.Abstraction.Service;
using FreelancerPlatform.Application.Abstraction.UnitOfWork;
using FreelancerPlatform.Application.Dtos.Comment;
using FreelancerPlatform.Application.Dtos.Common;
using FreelancerPlatform.Application.ServiceImplementions.Base;
using FreelancerPlatform.Domain.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerPlatform.Application.ServiceImplementions
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IFreelancerRepository _freelancerRepository;

       
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Comment> logger, ICommentRepository commentRepository, IFreelancerRepository freelancerRepository) :base(unitOfWork, mapper, logger)
        {
            _commentRepository = commentRepository;
            _freelancerRepository = freelancerRepository;
        }

        public async Task<ServiceResult> CreatePost(CommentCreateRequest request)
        {
            try
            {
                var newComment = new Comment()
                {
                    FreelancerId = request.FreelancerId,
                    Content = request.Content,
                    PostId = request.PostId,
                };
                if (request.Parent != null)
                {
                    newComment.Parent = request.Parent;
                }
                if (request.Reply != null)
                {
                    newComment.Reply = request.Reply;
                }
                await _commentRepository.CreateAsync(newComment);
                await _unitOfWork.SaveChangeAsync();

                return new ServiceResult()
                {
                    Message = "Tạo thông tin thành công",
                    Status = StatusResult.Success
                };
            }
            catch (Exception ex)
            {
                _unitOfWork.Cancel();
                _logger.LogError(ex.InnerException.Message);

                return new ServiceResultInt()
                {
                    Message = $"Lỗi hệ thống, ({ex.InnerException.Message})",
                    Status = StatusResult.SystemError
                };
            }
        }

        public async Task<List<CommentViewModel>> GetCommentParent(int postId)
        {
            var commentRaw = (await _commentRepository.GetAllAsync());
            var comments = commentRaw.Where(x => x.PostId == postId && x.Parent == null);
            var freelancer = await _freelancerRepository.GetAllAsync();

            var query = from c in comments
                        join f in freelancer on c.FreelancerId equals f.Id
                        select new { c, f };

            return query.Select(x => new CommentViewModel()
            {
                Id = x.c.Id,
                Content = x.c.Content,
                FirstName = x.f.FirstName,
                LastName = x.f.LastName,
                FreelancerId = x.f.Id,
                ImageUrl = x.f.ImageUrl,
                LikeNumber = x.c.LikeNumber,
                Parent = x.c.Parent,
                PostId = postId,
                Reply = x.c.Reply,
                ReplyNumber = commentRaw.Where(y => y.Parent == x.c.Id).Count() 
            }).ToList();
        }

        public async Task<List<CommentViewModel>> GetCommentReply(int parent)
        {
            var commentRaw = (await _commentRepository.GetAllAsync());
            var commentParent = await _commentRepository.GetByIdAsync(parent);
            var comments = commentRaw.Where(x => x.Parent == parent);
            var freelancer = await _freelancerRepository.GetAllAsync();

            var query = from c in comments
                        join f in freelancer on c.FreelancerId equals f.Id
                        select new { c, f };

            return query.Select(x => new CommentViewModel()
            {
                Id = x.c.Id,
                Content = x.c.Content,
                FirstName = x.f.FirstName,
                LastName = x.f.LastName,
                FreelancerId = x.f.Id,
                ImageUrl = x.f.ImageUrl,
                LikeNumber = x.c.LikeNumber,
                Parent = x.c.Parent,
                PostId = commentParent.PostId,
                Reply = x.c.Reply
            }).ToList();
        }
    }
}