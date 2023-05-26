using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Attempt6OpenIddict.ConferenceManagement
{
    public interface IConferenceAppService : IApplicationService
    {
        Task<PagedResultDto<ConferenceWithBriefInfo>> GetListAsync(ConferenceListFilterDto filter);

        Task<ConferenceWithDetails> GetAsync(Guid id);
        
        // Can them chuc nang add Chair List
        Task<ConferenceWithDetails> CreateAsync(ConferenceWithDetailsInput input);

        Task<ConferenceWithDetails> UpdateAsync(Guid id, ConferenceWithDetailsInput input);

        Task<bool> DeleteAsync(Guid id);
    }
}