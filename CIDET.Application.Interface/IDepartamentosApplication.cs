using CIDET.Application.DTO;
using CIDET.Domain.Entity;
using CIDET.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIDET.Application.Interface
{
    public interface IDepartamentosApplication
    {
        Task<Response<IEnumerable<DepartamentoDTO>>> GetAllAsync();
    }
}
