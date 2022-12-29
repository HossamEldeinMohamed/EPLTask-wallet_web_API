
using AutoMapper;
using Common_Utility.DTO;
using DataAccessLayer.Entities;

namespace Common_Utility.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {

            CreateMap<WalletDTO, Wallet>().ReverseMap(); ;
           

        }
    }
}
