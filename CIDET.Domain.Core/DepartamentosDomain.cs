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
    public class DepartamentosDomain : IDepartamentosDomain
    {
        private readonly IDepartamentosRepository _Repository;
        public IConfiguration Configuration { get; }

        public DepartamentosDomain(IDepartamentosRepository repository, IConfiguration _configuration)
        {
            _Repository = repository;
            Configuration = _configuration;
        }

        public async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }
    }
}
