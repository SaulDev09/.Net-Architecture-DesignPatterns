using AutoMapper;
using Saul.Test.Application.DTO;
using Saul.Test.Domain.Entity;

namespace Saul.Test.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Customers, CustomersDto>().ReverseMap();
        }
    }
}
