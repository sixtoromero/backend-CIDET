using CIDET.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIDET.Domain.Interface
{
    public interface IDepartamentosDomain
    {
        Task<IEnumerable<Departamento>> GetAllAsync();
    }
}
