using System;
using System.Collections.Generic;

namespace Attempt6OpenIddict.Dto
{
    public class ConferenceAccountDto
    {
        public Guid ConferenceId { get; set; }
        public Guid AccountId { get; set; }
        public bool HasDomainConflictConfirmed { get; set; }

        public List<IncumbentDto> Incumbents { get; set; }
    }
}
