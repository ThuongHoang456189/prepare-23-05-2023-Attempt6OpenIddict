using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Attempt6OpenIddict.ConferenceManagement
{
    public interface IConferenceUserAppService : IApplicationService
    {
        Task AssignConferenceRoleAsync();


    }
}
