﻿using Attempt6OpenIddict.ConferenceManagement;
using Attempt6OpenIddict.Dto;
using AutoMapper;

namespace Attempt6OpenIddict;

public class Attempt6OpenIddictApplicationAutoMapperProfile : Profile
{
    public Attempt6OpenIddictApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Conference, ConferenceWithDetails>();
        CreateMap<ConferenceAccount, ConferenceAccountDto>();
        CreateMap<Incumbent, IncumbentDto>();
    }
}
