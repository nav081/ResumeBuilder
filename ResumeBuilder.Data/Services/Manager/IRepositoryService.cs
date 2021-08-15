using ResumeBuilder.Data.Models.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilder.Data.Services.Manager
{
    public interface IRepositoryService<T> where T : BaseEntitites
    {
        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAllAsync(int[] ids);

        Task<T> GetAsync<Entity>(int id);

        Task UpdateAsync(T model);

        Task InsertAsync(T model);

        Task DeleteAsync(int id);

        Task DeleteMultipleAsync(List<T> model);

        Task DeleteMultipleAsync(int[] ids);

        IQueryable<T> Table { get; }

    }
}
