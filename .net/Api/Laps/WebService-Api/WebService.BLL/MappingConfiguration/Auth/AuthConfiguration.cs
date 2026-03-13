using Mapster;
using WebService.BLL.Dtos.Auth;
using WebService.DAL.Data.Entities;

namespace WebService.BLL.MappingConfiguration.Auth
{
    public class AuthConfiguration : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequestDto, ApplicationUser>()
                .Map(dest => dest.UserName, src => src.Email);
        }
    }
}
