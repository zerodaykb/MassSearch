using System.Collections.Generic;
using System.Threading.Tasks;
using MassReconApi.Contract.Dto;
using MassReconApi.Infrastucture.Model;

namespace MassReconApi.Core.Services
{
    public interface IResponseService : IExternalService<ResponseDto>
    {
    }
}