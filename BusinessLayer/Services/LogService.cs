using BusinessLayer.IService;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkLayer.Interface;
using UnitOfWorkLayer.Service;

namespace BusinessLayer.Services
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork unitOfWork;

        public LogService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Response GetAll()
        {
            try
            {
                var result = unitOfWork.Log.GetAll();
                return new Response { Code =200 , Data = result };
            }
            catch(Exception e)
            { return new Response { Code = 500 , Data = e.Message }; }
        }
    }
}
