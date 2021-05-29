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
    public class MunicipiosRepository : IMunicipiosRepository
    {
        private readonly DbContextOptions<CIDETDataContext> options;

        public MunicipiosRepository(DbContextOptions<CIDETDataContext> options = null)
        {
            this.options = options;
        }

        public async Task<string> InsertAsync(Municipio model)
        {
            using (var context = new CIDETDataContext(this.options))
            {
                try
                {                    
                    context.Municipios.Add(model);

                    await context.SaveChangesAsync();

                    return "Success";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public async Task<string> UpdateAsync(Municipio model)
        {

            try
            {
                using (var context = new CIDETDataContext(this.options))
                {
                    context.Entry(model).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    return "Success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        public async Task<string> DeleteAsync(int? Id)
        {
            try
            {
                using (var context = new CIDETDataContext(this.options))
                {
                    var Municipio = await context.Municipios.FirstOrDefaultAsync(x => x.Id == Id);
                    if (Municipio == null)
                    {
                        return "No se encontró el registro";
                    }
                    else
                    {
                        context.Remove(Municipio);
                        await context.SaveChangesAsync();
                    }

                    return "Success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IEnumerable<Municipio>> GetAllAsync()
        {

            try
            {
                using (var context = new CIDETDataContext(this.options))
                {
                    return await context.Municipios.ToListAsync();
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Municipio> GetAsync(int? Id)
        {
            try
            {
                using (var context = new CIDETDataContext(this.options))
                {
                    return await context.Municipios.FirstOrDefaultAsync(x => x.Id == Id);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
