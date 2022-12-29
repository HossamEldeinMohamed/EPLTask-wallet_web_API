using Common_Utility.DTO;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IService
{
    public interface ITransformationService
    {
        Task<Response> CreateTransformation (TranformationDTO tranformation);
    }
}
