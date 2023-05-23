using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Attempt6OpenIddict.Conference
{
    public class PaperStatus : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public Guid? ConferenceId { get; private set; }
        public Conference? Conference { get; private set; }
        public bool ReviewsVisibleToAuthor { get; private set; }
        public bool IsDefault { get; private set; }
        public PaperStatus(
            Guid id,
            string name, 
            Guid? conferenceId, 
            bool reviewsVisibleToAuthor, 
            bool isDefault)
            : base(id)
        {
            SetName(name);
            ConferenceId = conferenceId;
            ReviewsVisibleToAuthor = reviewsVisibleToAuthor;
            IsDefault = isDefault;
        }

        public PaperStatus SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), PaperStatusConsts.MaxNameLength);
            return this;
        }
    }
}
