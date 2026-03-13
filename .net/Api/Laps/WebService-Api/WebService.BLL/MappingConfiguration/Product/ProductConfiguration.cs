using Mapster;
using WebService.BLL.Dtos.Product;
using WebService.DAL;

namespace WebService.BLL.MappingConfiguration.Product
{
    internal class ProductConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<WebService.DAL.Product, ProductsResponseDto>()
                .Map(dest => dest.CaterogyId, src => src.Category.Id);

            config.NewConfig<WebService.DAL.Product, ProductsResponseDto>()
                .Map(dest => dest.CaterogyId, src => src.Category.Id);

            //ProductsResponseDto
        }
    }
}
