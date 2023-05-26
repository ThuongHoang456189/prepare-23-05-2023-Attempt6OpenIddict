﻿using System;

namespace Attempt6OpenIddict.ConferenceManagement
{
    public class ConferenceWithBriefInfo
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? WebsiteLink { get; set; }
        public string Logo { get; set; }
        public bool IsAccepted { get; set; }
    }
}
