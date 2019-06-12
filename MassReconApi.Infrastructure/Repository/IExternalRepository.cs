using System.Collections.Generic;
using System.Threading.Tasks;

namespace MassReconApi.Infrastucture.Repository
{
    public interface IExternalRepository<TEntity>
    {
        Task<TEntity> GetByPhrase(string phrase);
    }
}