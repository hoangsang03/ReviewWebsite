using Mapster;
using ReviewWebsite.Application.Authentication.Commands.Register;
using ReviewWebsite.Application.Authentication.Common;
using ReviewWebsite.Application.Authentication.Queries.Login;
using ReviewWebsite.Contracts.Authentication;

namespace ReviewWebsite.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Id, src => src.User.Id.Value)
                .Map(dest => dest, src => src.User);
        }
    }
}
