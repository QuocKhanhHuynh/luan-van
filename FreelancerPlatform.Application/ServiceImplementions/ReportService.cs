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
    public class ReportService : BaseService<Report>, IReportService
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
               var reportExist = (await _reportRepository.GetAllAsync()).Where(x => x.FreelancerId == request.FreelancerId && x.UserReport == request.UserReport);
                if (reportExist.Count() > 0)
                {
                    return new ServiceResult()
                    {
                        Message = "Bạn đã thực hiện báo cáo người dùng này",
                        Status = StatusResult.ClientError
                    };
                }
                var report = new Report()
                {
                    Content = request.Content,
                    FreelancerId = request.FreelancerId,
                    UserReport = request.UserReport
                };
                await _reportRepository.CreateAsync(report);
                await _unitOfWork.SaveChangeAsync();

                return new ServiceResult()
                {
                    Message = "Tạo báo cáo thành công",
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
    }
}
