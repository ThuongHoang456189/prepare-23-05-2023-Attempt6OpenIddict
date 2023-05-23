using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Attempt6OpenIddict.Conference
{
    public class Track : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public Guid ConferenceId { get; private set; }
        public Conference Conference { get; private set; }
        public string? SubmissionInstruction { get; private set; }
        public string? SubmissionSettings { get; private set; }
        public string? ConflictSettings { get; private set; }
        public string? ReviewSettings { get; private set; }
        public string? CameraReadySubmissionSettings { get; private set; }
        public string? SubjectAreaRelevanceCoefficients { get; private set; }

        public Track(
        Guid id,
        string name,
        Guid conferenceId,
        string? submissionInstruction,
        string submissionSettings,
        string conflictSettings,
        string reviewSettings,
        string cameraReadySubmissionSettings,
        string subjectAreaRelevanceCoefficients)
            : base(id)  
        {
            SetName(name);
            ConferenceId = conferenceId;
            SetSubmissionInstruction(submissionInstruction);
            SubmissionSettings = submissionSettings;
            ConflictSettings = conflictSettings;
            ReviewSettings = reviewSettings;
            CameraReadySubmissionSettings = cameraReadySubmissionSettings;
            SubjectAreaRelevanceCoefficients = subjectAreaRelevanceCoefficients;
        }

        public Track SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), TrackConsts.MaxNameLength);
            return this;
        }

        public Track SetSubmissionInstruction(string? submissionInstruction)
        {
            if (string.IsNullOrWhiteSpace(submissionInstruction))
            {
                SubmissionInstruction = null;
            }
            else
            {
                SubmissionInstruction = Check.NotNullOrWhiteSpace(submissionInstruction, nameof(submissionInstruction), TrackConsts.MaxSubmissionInstructionLength);
            }
            return this;
        }
    }
}
