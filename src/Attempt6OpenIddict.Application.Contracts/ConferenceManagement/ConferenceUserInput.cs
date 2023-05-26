using System;
using System.Collections.Generic;

namespace Attempt6OpenIddict.ConferenceManagement
{
    public class ConferenceUserInput
    {
        public Guid accountId {  get; set; }
        public List<IncumbentInput> incumbents { get; set; } = new List<IncumbentInput>();
    }
}
