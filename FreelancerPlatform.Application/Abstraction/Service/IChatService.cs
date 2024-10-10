using FreelancerPlatform.Application.Dtos.Chat;
using FreelancerPlatform.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerPlatform.Application.Abstraction.Service
{
    public interface IChatService
    {
        Task<ServiceResult> CreateChat(ChatCreateRequest request);
        Task<ServiceResult> CheckAndCreateHubChat(HubChatCreateViewModel request);
        Task<ServiceResult> RecallInbox(int id);
        Task<Dictionary<KeyChatViewModel, List<ChatViewModel>>> GetAllChat(int freelancerId);
    }
}
