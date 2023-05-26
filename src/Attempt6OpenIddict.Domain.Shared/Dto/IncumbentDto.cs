using System;

namespace Attempt6OpenIddict.Dto
{
    public class IncumbentDto
    {
        public Guid ConferenceAccountId { get; set; }
        public Guid ConferenceRoleId { get; set; }
        public Guid? TrackId { get; set; }
        public bool IsPrimaryContact { get; set; }
    }
}
