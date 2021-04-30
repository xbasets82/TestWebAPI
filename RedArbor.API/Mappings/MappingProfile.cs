using AutoMapper;


namespace RedArbor.API.Mappings
{
    public class MappingProfile : Profile
    {
      public MappingProfile()
        {
            CreateMap<Models.Employee, RedArbor.Process.Models.Employee>();
            CreateMap<RedArbor.Process.Models.Employee, Models.Employee>();

            CreateMap<RedArbor.Process.Models.Employee, RedArbor.DAL.Models.Employee>();
            CreateMap<RedArbor.DAL.Models.Employee, RedArbor.Process.Models.Employee>();
        }
    }
}
