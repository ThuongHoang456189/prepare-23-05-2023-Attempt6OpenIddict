using System;

namespace Attempt6OpenIddict.ConferenceManagement
{
    public class IncumbentInput
    {
        public Guid ConferenceRoleId { get; set; }
        public Guid? TrackId { get; set; }
        public bool IsPrimaryContact { get; set; }
    }
}
