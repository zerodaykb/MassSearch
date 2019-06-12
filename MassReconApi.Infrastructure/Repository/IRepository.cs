using System.Collections.Generic;
using System.Threading.Tasks;

namespace MassReconApi.Infrastucture.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(long id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(long id);
    }
}