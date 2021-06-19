using ResumeBuilder.Data.Models.Common;
using System.Collections.Generic;

namespace ResumeBuilder.Data.Services.Manager
{
    public interface IRepositoryService<T> where T : BaseEntitites
    {
        List<T> GetAll();

        T Get<Entity>(int id);

        void Update(T model);

        void Insert(T model);

        void Delete<Entity>(int id);

        void DeleteMultiple(List<T> model);
    }
}
