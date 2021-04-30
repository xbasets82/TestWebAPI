using AutoMapper;


namespace RedArbor.Test.Mappings
{
    public class MappingProfile : Profile
    {
      public MappingProfile()
        {

            CreateMap<RedArbor.Process.Models.Employee, RedArbor.DAL.Models.Employee>();
            CreateMap<RedArbor.DAL.Models.Employee, RedArbor.Process.Models.Employee>();
        }
    }
}
