using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIDET.Domain.Interface
{
    public interface IDomain<T>
    {
        Task<string> InsertAsync(T model);
        Task<string> UpdateAsync(T model);
        Task<string> DeleteAsync(int? Id);
        Task<T> GetAsync(int? Id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
