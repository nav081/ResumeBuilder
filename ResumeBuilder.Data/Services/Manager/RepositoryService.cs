using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeBuilder.Data.Services.Manager
{
    public class RepositoryService<T> : IRepositoryService<T> where T : BaseEntitites
    {
        #region Fields
        private readonly DatabaseContext _context;
        private DbSet<T> entities;
        #endregion

        #region Constructor
        public RepositoryService(DatabaseContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        

        #endregion

        #region Methods

        public async Task<T>  GetAsync<Entity>(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }

        public async Task  InsertAsync(T model)
        {
            entities.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T model)
        {
            entities.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data=entities.Find(id);
            entities.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMultipleAsync(int[] ids)
        {
            var record =await GetAllAsync(ids);
            entities.RemoveRange(record);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMultipleAsync(List<T> model)
        {
            entities.RemoveRange(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync(int[] ids)
        {
            return await entities.Where(a=>ids.Contains(a.Id)).ToListAsync();
        }

        public IQueryable<T> Table => entities;
        #endregion
    }
}
