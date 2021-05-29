using Dapper;
using CIDET.Domain.Entity;
using CIDET.InfraStructure.Interface;
using CIDET.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using CIDET.InfraStructure.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CIDET.InfraStructure.Repository
{
    public class DepartamentosRepository: IDepartamentosRepository
    {
        private readonly DbContextOptions<CIDETDataContext> options;
        public DepartamentosRepository(DbContextOptions<CIDETDataContext> options = null)
        {
            this.options = options;
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync()
        {

            try
            {
                using (var context = new CIDETDataContext(this.options))
                {
                    return await context.Departamentos.ToListAsync();
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}
