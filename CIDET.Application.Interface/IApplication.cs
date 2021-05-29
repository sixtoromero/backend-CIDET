using CIDET.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIDET.Application.Interface
{
    public interface IApplication<T>
    {        
        Task<Response<string>> InsertAsync(T model);
        Task<Response<string>> UpdateAsync(T model);
        Task<Response<string>> DeleteAsync(int? Id);
        Task<Response<T>> GetAsync(int? Id);
        Task<Response<IEnumerable<T>>> GetAllAsync();

    }
}
