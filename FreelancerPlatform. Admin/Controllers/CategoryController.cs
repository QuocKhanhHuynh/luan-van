using Azure.Core;
using FreelancerPlatform.Application.Abstraction.Repository;
using FreelancerPlatform.Application.Abstraction.Service;
using FreelancerPlatform.Application.Dtos.Common;
using FreelancerPlatform.Application.Dtos.Skill;
using FreelancerPlatform.Application.ServiceImplementions;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerPlatform._Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISkillService  _skillService;
        public CategoryController(ICategoryService categoryService, ISkillService skillService)
        {
            _categoryService = categoryService;
            _skillService = skillService;
        }
        public async Task<IActionResult> GetCategory()
        {
            var categories = await _categoryService.GetCategoryAsync();
            return View(categories);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        public async Task<IActionResult> GetSkill()
        {
            var skills = await _skillService.GetSkillAsync();
            return View(skills);
        }

        public IActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSkill(SkillCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new
                {
                    Field = x.Key,
                    Errors = x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                })
                .ToList();

                return BadRequest(new { Errors = errors });
            }
            var result = await _skillService.CreateSkillAsync(request);
            if (result.Status != StatusResult.Success)
            {
                var errors = new List<object>
                {
                    new
                    {
                        Field = "ResultStatus",
                        Errors = new[] { result.Message }
                    }
                };

                return BadRequest(new { Errors = errors });
            }

            return Ok(result.Message);
        }

        public async Task<IActionResult> UpdateSkill(int id)
        {
            var skills = await _skillService.GetSkillAsync();
            var skill = skills.FirstOrDefault(x => x.Id == id);
            return View(skill);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSkill(SkillUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new
                {
                    Field = x.Key,
                    Errors = x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                })
                .ToList();

                return BadRequest(new { Errors = errors });
            }
            var result = await _skillService.UpdateSkillAsync(request);
            if (result.Status != StatusResult.Success)
            {
                var errors = new List<object>
                {
                    new
                    {
                        Field = "ResultStatus",
                        Errors = new[] { result.Message }
                    }
                };

                return BadRequest(new { Errors = errors });
            }

            return Ok(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var result = await _skillService.DeleteSkillAsync(id);
            if (result.Status != StatusResult.Success)
            {
                var errors = new List<object>
                {
                    new
                    {
                        Field = "ResultStatus",
                        Errors = new[] { result.Message }
                    }
                };

                return BadRequest(new { Errors = errors });
            }

            return Ok(result.Message);
        }

    }

}
