using AutoMapper;


namespace EmailSystem.Domain.Entities;

public class MailDefinitionProfile : Profile
{
    public MailDefinitionProfile()
    {
        CreateMap<MailDefinitionDTO, MailDefinition>()
            .ForMember(dest => dest.MailDefinitionCore,
                       opt => opt.MapFrom(src => src.MailDefinitionCore))
            .ForMember(dest => dest.Attachments,
                       opt => opt.MapFrom(src => src.Attachments));

        CreateMap<MailDefinitionCoreDTO, MailDefinitionCore>();

        CreateMap<AttachmentDTO, Attachment>();
    }
}
