using CIDET.Domain.Entity;
using CIDET.Domain.Interface;
using CIDET.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIDET.Domain.Core
{
    public class MunicipiosDomain : IMunicipiosDomain
    {
        private readonly IMunicipiosRepository _Repository;
        public IConfiguration Configuration { get; }

        public MunicipiosDomain(IMunicipiosRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }
        
        public async Task<string> InsertAsync(Municipio model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Municipio model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<string> DeleteAsync(int? Id)
        {
            return await _Repository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Municipio>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Municipio> GetAsync(int? Id)
        {
            return await _Repository.GetAsync(Id);
        }

    }
}
