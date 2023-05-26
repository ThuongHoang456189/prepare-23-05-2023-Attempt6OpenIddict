﻿using Attempt6OpenIddict.Extension;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Attempt6OpenIddict.ConferenceManagement
{
    public class Conference : FullAuditedAggregateRoot<Guid>
    {
        public string FullName { get; private set; }
        public string ShortName { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? WebsiteLink { get; set; }
        public string? GeneralSettings { get; private set; }
        public string? RegistrationSettings { get; private set; }
        public string Logo { get; set; }
        public bool IsAccepted { get; set; }

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
            string? websiteLink,
            string? generalSettings, 
            string? registrationSettings, 
            string logo,
            bool isAccepted)
            :base(id)
        {
            SetFullName(fullName);
            SetShortName(shortName);
            SetCity(city);
            SetCountry(country);
            StartDate = startDate;
            EndDate = endDate;
            WebsiteLink = websiteLink;
            GeneralSettings = generalSettings;
            RegistrationSettings = registrationSettings;
            Logo = logo;
            IsAccepted = isAccepted;

            ConferenceAccounts = new Collection<ConferenceAccount>();
            PaperStatuses = new Collection<PaperStatus>();
            Tracks = new Collection<Track>();
        }

        public Conference SetFullName(string fullName)
        {
            FullName = Check.NotNullOrWhiteSpace(string.IsNullOrEmpty(fullName) ? fullName : fullName.Trim(), nameof(fullName), ConferenceConsts.MaxFullnameLength);
            return this;
        }

        public Conference SetShortName(string shortName)
        {
            ShortName = Check.NotNullOrWhiteSpace(string.IsNullOrEmpty(shortName) ? shortName : shortName.Trim(), nameof(shortName), ConferenceConsts.MaxShortNameLength);
            return this;
        }
        public Conference SetCity(string city)
        {
            City = Check.NotNullOrWhiteSpace(string.IsNullOrEmpty(city) ? city : city.Trim(), nameof(city), ConferenceConsts.MaxCityLength);
            return this;
        }
        public Conference SetCountry(string country)
        {
            Country = Check.NotNullOrWhiteSpace(string.IsNullOrEmpty(country) ? country : country.Trim(), nameof(country), ConferenceConsts.MaxCountryLength);
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
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.AccountAlreadyAddedToConference);
            }

            ConferenceAccounts.Add(new ConferenceAccount(conferenceAccountId, Id, accountId, hasDomainConflictConfirmed));

            return this;
        }

        public Conference AddConferenceAccount(ConferenceAccount conferenceAccount)
        {
            if(ConferenceAccounts.Any(x => x.AccountId == conferenceAccount.AccountId))
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.AccountAlreadyAddedToConference);
            }

            ConferenceAccounts.Add(conferenceAccount);

            return this;
        }

        public Conference UpdateConferenceAccount(
            Guid conferenceAccountId,
            bool hasDomainConflictConfirmed)
        {
            var found = ConferenceAccounts.SingleOrDefault(x => x.Id == conferenceAccountId);
            if(found == null)
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.ConferenceAccountNotFound);
            }

            found.HasDomainConflictConfirmed = hasDomainConflictConfirmed;

            return this;
        }

        public Conference UpdateConferenceAccount(ConferenceAccount conferenceAccount)
        {
            var found = ConferenceAccounts.SingleOrDefault(x => x.Id == conferenceAccount.Id);
            if (found == null)
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.ConferenceAccountNotFound);
            }
            else
            {
                ConferenceAccounts.Remove(found);
                ConferenceAccounts.Add(conferenceAccount);
            }

            return this;
        }

        public Conference DeleteConferenceAccount(Guid conferenceAccountId)
        {
            var conferenceAccount = ConferenceAccounts.SingleOrDefault(x => x.Id == conferenceAccountId);
            if (conferenceAccount == null)
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.ConferenceAccountNotFound);
            }

            ConferenceAccounts.Remove(conferenceAccount);

            return this;
        }

        public Conference AddPaperStatus(
            Guid paperStatusId,
            string name,
            bool reviewsVisibleToAuthor)
        {
            if(PaperStatuses.Any(x => x.Name.EqualsIgnoreCase(string.IsNullOrEmpty(name) ? name : name.Trim())))
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.PaperStatusAlreadyExistToConference);
            }

            PaperStatuses.Add(new PaperStatus(paperStatusId, name, Id, reviewsVisibleToAuthor, false));

            return this;
        }

        public Conference UpdatePaperStatus(
            Guid paperStatusId,
            string name,
            bool reviewsVisibleToAuthor)
        {
            var paperStatus = PaperStatuses.SingleOrDefault(x => x.Id == paperStatusId);
            if(paperStatus == null)
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.PaperStatusNotFound);
            }
            else if (PaperStatuses.Any(x => x.Name.EqualsIgnoreCase(string.IsNullOrEmpty(name) ? name : name.Trim()) && x.Id != paperStatusId))
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.PaperStatusAlreadyExistToConference);
            }

            paperStatus.SetName(name);
            paperStatus.ReviewsVisibleToAuthor = reviewsVisibleToAuthor;

            return this;
        }

        public Conference DeletePaperStatus(Guid paperStatusId)
        {
            var paperStatus = PaperStatuses.SingleOrDefault(x => x.Id == paperStatusId);
            if (paperStatus == null)
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.PaperStatusNotFound);
            }

            PaperStatuses.Remove(paperStatus);

            return this;
        }

        public Conference AddTrack(
            Guid trackId,
            string name,
            string? submissionInstruction,
            string? submissionSettings,
            string? conflictSettings,
            string? reviewSettings,
            string? cameraReadySubmissionSettings,
            string? subjectAreaRelevanceCoefficients)
        {

            if(Tracks.Any(x => x.Name.EqualsIgnoreCase(string.IsNullOrEmpty(name) ? name : name.Trim())))
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.TrackAlreadyExistToConference);
            }

            Tracks.Add(new Track(trackId, name, Id, submissionInstruction, submissionSettings, conflictSettings, reviewSettings, cameraReadySubmissionSettings, subjectAreaRelevanceCoefficients));
            
            return this;
        }

        public Conference UpdateTrack(
            Guid trackId,
            string name,
            string? submissionInstruction,
            string? submissionSettings,
            string? conflictSettings,
            string? reviewSettings,
            string? cameraReadySubmissionSettings,
            string? subjectAreaRelevanceCoefficients)
        {
            var track = Tracks.SingleOrDefault(x => x.Id == trackId);
            if(track == null)
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.TrackNotFound);
            } 
            else if (Tracks.Any(x => x.Name.EqualsIgnoreCase(string.IsNullOrEmpty(name) ? name : name.Trim()) && x.Id != trackId))
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.TrackAlreadyExistToConference);
            }

            track.SetName(name);
            track.SubmissionInstruction = submissionInstruction;
            track.SubmissionSettings = submissionSettings;
            track.ConflictSettings = conflictSettings;
            track.ReviewSettings = reviewSettings;
            track.CameraReadySubmissionSettings = cameraReadySubmissionSettings;
            track.SubjectAreaRelevanceCoefficients = subjectAreaRelevanceCoefficients;

            return this;
        }

        public Conference DeleteTrack(Guid trackId)
        {
            var track = Tracks.SingleOrDefault(x => x.Id == trackId);
            if (track == null)
            {
                throw new BusinessException(Attempt6OpenIddictDomainErrorCodes.TrackNotFound);
            }

            Tracks.Remove(track);

            return this;
        }
    }
}