using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Data.Models.Common;
using System.Collections.Generic;
using System.Linq;

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


        public T Get<Entity>(int id)
        {
            return entities.Find(id);
        }

        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public void Insert(T model)
        {
            entities.Add(model);
            _context.SaveChanges();
        }

        public void Update(T model)
        {
            entities.Update(model);
            _context.SaveChanges();
        }

        public void Delete<Entity>(int id)
        {
            var data=entities.Find(id);
            entities.Remove(data);
            _context.SaveChanges();
        }

        public void DeleteMultiple(List<T> model)
        {
            entities.RemoveRange(model);
            _context.SaveChanges();
        }

        #endregion
    }
}
