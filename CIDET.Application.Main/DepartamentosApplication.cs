using AutoMapper;
using CIDET.Application.DTO;
using CIDET.Application.Interface;
using CIDET.Domain.Entity;
using CIDET.Domain.Interface;
using CIDET.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CIDET.Application.Main
{
    public class DepartamentosApplication : IDepartamentosApplication
    {
        private readonly IDepartamentosDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<DepartamentosApplication> _logger;

        public DepartamentosApplication(IDepartamentosDomain Domain, IMapper mapper, IAppLogger<DepartamentosApplication> logger)
        {
            _Domain = Domain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<DepartamentoDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<DepartamentoDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<DepartamentoDTO>>(resp);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = string.Empty;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error consultando los registros.";
                    _logger.LogWarning("Ha ocurrido un error consultando los registros.");
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }



    }
}
