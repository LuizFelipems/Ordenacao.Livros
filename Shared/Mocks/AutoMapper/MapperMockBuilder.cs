using AutoMapper;
using Ordenacao.Application;

namespace Shared.Mocks.AutoMapper
{
    public class MapperMockBuilder
    {
        public static IMapper Build()
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddMaps(typeof(Pin));
            });

            return mapper.CreateMapper();
        }
    }
}
