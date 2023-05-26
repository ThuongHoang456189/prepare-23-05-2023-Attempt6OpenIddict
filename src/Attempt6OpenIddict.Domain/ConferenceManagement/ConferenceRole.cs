using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Attempt6OpenIddict.ConferenceManagement
{
    public class ConferenceRole : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public bool IsPC { get; private set; }

        public ICollection<Incumbent> Incumbents { get; private set; }

        public ConferenceRole(Guid id, string name, bool isPC) : base(id)
        { 
            SetName(name);
            IsPC = isPC;

            Incumbents = new Collection<Incumbent>();
        }

        public ConferenceRole SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(string.IsNullOrEmpty(name) ? name : name.Trim(), nameof(name), ConferenceRoleConsts.MaxNameLength);
            return this;
        }
    }
}
