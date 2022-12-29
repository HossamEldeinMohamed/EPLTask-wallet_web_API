using BusinessLayer.IService;
using Common_Utility.DTO;
using DataAccessLayer.Entities;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkLayer.Interface;

namespace BusinessLayer.Services
{
    public class TransformationService : ITransformationService
    {
        private readonly IUnitOfWork unitOfWork;

        public TransformationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response> CreateTransformation(TranformationDTO tranformation)
        {
            try
            {
                var UserWallet = await unitOfWork.Wallet.GetByUserIdAsync(tranformation.UserId);
                if (UserWallet.Balance < tranformation.Amount)
                    return new Response { Code = 400, Message = "you don't have Enough mony" };
                var wallet = await unitOfWork.Wallet.GetByPhoneAsync(tranformation.Phone);
                if (wallet == null)
                    return new Response { Code = 400, Message = "this number is incorrect" };
                 wallet.Balance += tranformation.Amount;
                 UserWallet.Balance -= tranformation.Amount;
                await unitOfWork.Wallet.UpdateAsync(wallet);
                await unitOfWork.Wallet.UpdateAsync(UserWallet);
                Log log = new Log { TransformerUser = tranformation.UserId, TransferredTo = wallet.UserId, Balance = tranformation.Amount, Date = DateTime.Now };
                await unitOfWork.Log.InsertAsync(log);
                unitOfWork.Save();
                return new Response { Code = 200, Data = wallet, Message="Sucess" };
            }
            catch(Exception e)
            {
                return new Response { Code = 500, Message = e.Message };
            }


        }
    }
}
