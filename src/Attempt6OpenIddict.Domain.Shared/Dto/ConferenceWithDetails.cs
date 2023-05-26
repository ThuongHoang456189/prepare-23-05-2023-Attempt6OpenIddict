using Attempt6OpenIddict.Dto;
using System.Collections.Generic;

namespace Attempt6OpenIddict.ConferenceManagement
{
    public class ConferenceWithDetails : ConferenceWithBriefInfo
    {
        // Add list of chair
        public List<ConferenceAccountDto> ConferenceAccounts { get; set; }
    }
}
