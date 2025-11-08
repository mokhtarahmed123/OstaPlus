using AutoMapper;

namespace OSTA.BLL.Mapping.AuthMapping
{
    public partial class AuthProfile : Profile
    {
        public AuthProfile()
        {
            SignUp();
            GetAll();
            GetUserMapping();
            UpdateMapping();
        }
    }
}
