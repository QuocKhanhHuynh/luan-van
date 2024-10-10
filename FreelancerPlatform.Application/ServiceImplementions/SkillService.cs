using AutoMapper;
using FreelancerPlatform.Application.Abstraction.Repository;
using FreelancerPlatform.Application.Abstraction.Service;
using FreelancerPlatform.Application.Abstraction.UnitOfWork;
using FreelancerPlatform.Application.Dtos.Category;
using FreelancerPlatform.Application.Dtos.Skill;
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
    public class SkillService : BaseService<SKill>, ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public SkillService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SKill> logger, ISkillRepository skillRepository) : base(unitOfWork, mapper, logger)
        {
            _skillRepository = skillRepository;
        }
        public async Task<List<SkillQuickViewModel>> GetSkillAsync()
        {
            var query = (await _skillRepository.GetAllAsync());
            var items = query.Select(x => new SkillQuickViewModel() { Id = x.Id, Name = x.Name }).ToList();

            return items;
        }
    }
}
