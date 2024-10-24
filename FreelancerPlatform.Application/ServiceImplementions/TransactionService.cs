using AutoMapper;
using FreelancerPlatform.Application.Abstraction.Repository;
using FreelancerPlatform.Application.Abstraction.Service;
using FreelancerPlatform.Application.Abstraction.UnitOfWork;
using FreelancerPlatform.Application.Dtos.Common;
using FreelancerPlatform.Application.Dtos.Transaction;
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
    public class TransactionService : BaseService<Transaction>, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IFreelancerRepository _freelancerRepository;
        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<Transaction> logger, 
            ITransactionRepository transactionRepository, IFreelancerRepository freelancerRepository) : base(unitOfWork, mapper, logger)
        {
            _transactionRepository = transactionRepository;
            _freelancerRepository = freelancerRepository;
        }
        public async Task<ServiceResult> CreateTransaction(TransactionCreateRequest request)
        {
            try
            {
                var transaction = new Transaction()
                {
                    Amount = request.Amount,
                    ContractId = request.ContractId,
                    Content = request.Content,
                    FreelancerId = request.FreelancerId
                };
                await _transactionRepository.CreateAsync(transaction);
                await _unitOfWork.SaveChangeAsync();

                return new ServiceResult()
                {
                    Message = "Tạo thông tin thành công",
                    Status = StatusResult.Success,
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

        public async Task<List<TransactionQuickViewModel>> GetTransactionOfContract(int contractId)
        {
            var transactions = await _transactionRepository.GetAllAsync();
            var freelancer = await _freelancerRepository.GetAllAsync();
            var query = from t in transactions
                       join f in freelancer on t.FreelancerId equals f.Id
                       select new {t, f};

            return query.Where(x => x.t.ContractId == contractId).Select(x => new TransactionQuickViewModel()
            {
                Amount = x.t.Amount,
                ContractId=x.t.ContractId,
                Content = x.t.Content,
                Id = x.t.Id,
                Status = x.t.Status,
                CreateDay = x.t.CreateDay,
                LastName = x.f.LastName,
                FirstName = x.f.FirstName,
                FreelancerId = x.f.Id,
                ImageUrl = x.f.ImageUrl
            }).ToList();
        }
    }
}
