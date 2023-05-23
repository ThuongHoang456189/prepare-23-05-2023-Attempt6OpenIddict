using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Attempt6OpenIddict.Conference
{
    public class Conference : FullAuditedAggregateRoot<Guid>
    {
        public string FullName { get; private set; }
        public string ShortName { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string GeneralSettings { get; private set; }
        public string RegistrationSettings { get; private set; }
        public string Logo { get; private set; }
        public ICollection<ConferenceAccount> ConferenceAccounts { get; private set; }
        public ICollection<PaperStatus> PaperStatuses { get; private set; }
        public ICollection<Track> Tracks { get; private set; }
        public Conference(
            Guid id, 
            string fullName, 
            string shortName, string city, 
            string country, 
            DateTime startDate, 
            DateTime endDate, 
            string generalSettings, 
            string registrationSettings, 
            string logo)
            :base(id)
        {
            FullName = fullName;
            ShortName = shortName;
            City = city;
            Country = country;
            StartDate = startDate;
            EndDate = endDate;
            GeneralSettings = generalSettings;
            RegistrationSettings = registrationSettings;
            Logo = logo;
        }
        public Conference SetFullName(string fullName)
        {
            FullName = Check.NotNullOrWhiteSpace(fullName, nameof(fullName), ConferenceConsts.MaxFullnameLength);
            return this;
        }
        public Conference SetShortName(string shortName)
        {
            ShortName = Check.NotNullOrWhiteSpace(shortName, nameof(shortName), ConferenceConsts.MaxShortNameLength);
            return this;
        }
        public Conference SetCity(string city)
        {
            City = Check.NotNullOrWhiteSpace(city, nameof(city), ConferenceConsts.MaxCityLength);
            return this;
        }
        public Conference SetCountry(string country)
        {
            Country = Check.NotNullOrWhiteSpace(country, nameof(country), ConferenceConsts.MaxCountryLength);
            return this;
        }
        public Conference AddConferenceAccount(
            Guid conferenceAccountId,
            Guid accountId,
            bool hasDomainConflictConfirmed
            )
        {
            if(ConferenceAccounts.Any(x => x.AccountId == accountId))
            {
                throw new BusinessException();
            }
            return this;
        }
    }
}
