﻿using FreelancerPlatform.Application.Dtos.Apply;
using FreelancerPlatform.Application.Dtos.Common;
using FreelancerPlatform.Application.Dtos.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerPlatform.Application.Abstraction.Service
{
    public interface IReportService
    {
        Task<ServiceResult> CreateReportAsync(ReportCreateRequest request);
        Task<Pagination<ReportQuickViewModel>> GetAllReportAsync(int pageIndex, int pageTake, int? keyword = null);
        Task<ReportViewModel> GetReportAsync(int id);
    }
}