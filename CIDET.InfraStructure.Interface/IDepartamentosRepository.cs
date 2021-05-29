using CIDET.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIDET.InfraStructure.Interface
{
    public interface IDepartamentosRepository
    {
        Task<IEnumerable<Departamento>> GetAllAsync();
    }
}
