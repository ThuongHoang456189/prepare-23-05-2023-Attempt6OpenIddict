using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Attempt6OpenIddict.Conference
{
    public class ConferenceAccount : FullAuditedAggregateRoot<Guid>
    {
        public Guid ConferenceId { get; private set; }
        public Conference Conference { get; private set; }
        public Guid AccountId { get; private set; }
        public IdentityUser Account { get; private set; }
        public bool HasDomainConflictConfirmed { get; private set; }
        public ConferenceAccount(
            Guid id, 
            Guid conferenceId, 
            Guid accountId, 
            bool hasDomainConflictConfirmed)
            :base(id)
        {
            ConferenceId = conferenceId;
            AccountId = accountId;
            HasDomainConflictConfirmed = hasDomainConflictConfirmed;
        }
    }
}
