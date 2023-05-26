using Attempt6OpenIddict.ConferenceManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Attempt6OpenIddict.Data
{
    public class ConferenceManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<PaperStatus, Guid> _paperStatusRepository;
        private readonly IRepository<ConferenceRole, Guid> _conferenceRoleRepository;
        private readonly IRepository<ConferenceAccount, Guid> _conferenceAccountRepository;
        private readonly IRepository<Incumbent, Guid> _incumbentRepository;

        private readonly IGuidGenerator _guidGenerator;

        public ConferenceManagementDataSeedContributor(
            IRepository<PaperStatus, Guid> paperStatusRepository,
            IRepository<ConferenceRole, Guid> conferenceRoleRepository,
            IRepository<ConferenceAccount, Guid> conferenceAccountRepository,
            IRepository<Incumbent, Guid> incumbentRepository,
            IGuidGenerator guidGenerator)
        {
            _paperStatusRepository = paperStatusRepository;
            _conferenceRoleRepository = conferenceRoleRepository;
            _conferenceAccountRepository = conferenceAccountRepository;
            _incumbentRepository = incumbentRepository;

            _guidGenerator = guidGenerator;
        }
        
        private async Task CreatePaperStatusesAsync()
        {
            if(await _paperStatusRepository.GetCountAsync() > 0)
            {
                return;
            }

            var paperStatuses = new List<PaperStatus>
            {
                new PaperStatus(_guidGenerator.Create(),"Awaiting Decision", null, false, true),
                new PaperStatus(_guidGenerator.Create(),"Withdrawn", null, false, true),
                new PaperStatus(_guidGenerator.Create(),"Desk Reject", null, false, true),
                new PaperStatus(_guidGenerator.Create(),"Accept", null, false, true),
                new PaperStatus(_guidGenerator.Create(),"Revision", null, false, true),
                new PaperStatus(_guidGenerator.Create(),"Reject", null, false, true)
            };

            await _paperStatusRepository.InsertManyAsync(paperStatuses, autoSave: true);
        }

        private async Task CreateConferenceRolesAsync()
        {
            if(await _conferenceRoleRepository.GetCountAsync() > 0)
            {
                return;
            }

            var conferenceRoles = new List<ConferenceRole>
            {
                new ConferenceRole(_guidGenerator.Create(), "Chair", true),
                new ConferenceRole(_guidGenerator.Create(), "Track Chair", true),
                new ConferenceRole(_guidGenerator.Create(), "Reviewer", true),
                new ConferenceRole(_guidGenerator.Create(), "Author", false),
            };

            await _conferenceRoleRepository.InsertManyAsync(conferenceRoles, autoSave: true);
        }

        private async Task CreateConferenceAccountsAsync()
        {
            if (await _conferenceAccountRepository.GetCountAsync() > 0)
            {
                return;
            }

            var conferenceAccountId = _guidGenerator.Create();

            var conferenceAccounts = new List<ConferenceAccount>
            {
                new ConferenceAccount(conferenceAccountId, Guid.Parse("06ADB810-7DCF-8A01-D435-3A0B5EC2F487"), Guid.Parse("44151D4E-BC1E-BAFC-E5AD-3A0B5E84D32A"), false)
            };

            var incumbents = new List<Incumbent>
            {
                new Incumbent(_guidGenerator.Create(), conferenceAccountId, Guid.Parse("BE39A1D3-4ACE-86FB-835D-3A0B60018B1C"), null, true),
                new Incumbent(_guidGenerator.Create(), conferenceAccountId, Guid.Parse("6D2A8095-DAD6-5657-136B-3A0B60018B1E"), null, false),
            };

            await _conferenceAccountRepository.InsertManyAsync(conferenceAccounts, autoSave: true);
            await _incumbentRepository.InsertManyAsync(incumbents, autoSave: true);
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await CreatePaperStatusesAsync();
            await CreateConferenceRolesAsync();
            await CreateConferenceAccountsAsync();
        }
    }
}
