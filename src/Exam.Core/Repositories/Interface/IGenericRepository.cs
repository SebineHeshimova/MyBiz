using Exam.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Core.Repositories.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity , new()
    {
        
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<List<TEntity>> GetAllAsaync();
        Task<TEntity> GetByIdAsync(int id);
        Task<int> CommitAsync();
    }
}
