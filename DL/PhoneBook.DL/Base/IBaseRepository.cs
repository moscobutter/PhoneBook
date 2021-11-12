using PhoneBook.ML.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.DL.Base
{
    public interface IBaseRepository<T> where T: BaseClass
    {
        Task<T> AddAsync(T obj);
        void Update(T obj);

        Task DeleteAsync(int Id);

        Task<T> GetByIdAsync(int Id);

        Task<T> GetByNameAsync(string name); 

        Task<List<T>> GetAsync(Expression<Func<T, bool>> filter, int pageNum = 1, int pageSize = 100);

        Task<bool> SaveChangesAsync();
    }
}
