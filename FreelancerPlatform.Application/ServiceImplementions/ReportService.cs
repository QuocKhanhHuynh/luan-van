using AutoMapper;
using FreelancerPlatform.Application.Abstraction.Repository;
using FreelancerPlatform.Application.Abstraction.Service;
using FreelancerPlatform.Application.Abstraction.UnitOfWork;
using FreelancerPlatform.Application.Dtos.Apply;
using FreelancerPlatform.Application.Dtos.Common;
using FreelancerPlatform.Application.Dtos.Report;
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
    public class ReportService : BaseService<Report>//, IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Report> logge, IReportRepository reportRepository) : base(unitOfWork, mapper, logge)
        {
            _reportRepository = reportRepository;
        }
        public async Task<ServiceResult> CreateReportAsync(ReportCreateRequest request)
        {
            try
            {
                var entity = _mapper.Map<Report>(request);
                await _reportRepository.CreateAsync(entity);
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

                return new ServiceResult()
                {
                    Message = $"Lỗi hệ thống, ({ex.InnerException.Message})",
                    Status = StatusResult.SystemError
                };
            }
        }

        public async Task<Pagination<ReportQuickViewModel>> GetAllReportAsync(int pageIndex, int pageTake, int? keyword)
        {
            var query = (await _reportRepository.GetAllAsync());
            if (keyword != null)
            {
                query = query.Where(x => x.ReportType.Equals(keyword.Value));
            }
            var pagination = new Pagination<ReportQuickViewModel>();
            pagination.PageIndex = pageIndex;
            pagination.PageSize = pageTake;
            pagination.TotalRecords = query.Count();

            var items = query.Skip((pageIndex - 1) * pageTake).Take(pageTake).Select(x => _mapper.Map<ReportQuickViewModel>(x)).ToList();
            pagination.Items = items;

            return pagination;
        }

        /*public async Task<ReportViewModel> GetReportAsync(int id)
        {
            Report entity = await _reportRepository.GetByIdAsync(id);
            return entity.IsDeleted == false ? _mapper.Map<ReportViewModel>(entity) : new ReportViewModel();
        }*/
    }
}
