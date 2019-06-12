using System.Collections.Generic;
using System.Threading.Tasks;
using MassReconApi.Contract.Dto;

namespace MassReconApi.Core.Services
{
    public interface IExternalService<TEntity>
    {    
        Task<TEntity> GetByPhrase(string phrase);
    }
}