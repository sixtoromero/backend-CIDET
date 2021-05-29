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

    public class MunicipiosApplication : IMunicipiosApplication
    {
        private readonly IMunicipiosDomain _Domain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<MunicipiosApplication> _logger;

        public MunicipiosApplication(IMunicipiosDomain Domain, IMapper mapper, IAppLogger<MunicipiosApplication> logger)
        {
            _Domain = Domain;
            _mapper = mapper;
            _logger = logger;
        }
        
        public async Task<Response<string>> InsertAsync(MunicipioDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Municipio>(model);
                response.Data = await _Domain.InsertAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha registrado el Municipio exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado registrando el municipio " + model.Nombre + ", (" + response.Data + ")");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<string>> UpdateAsync(MunicipioDTO model)
        {
            var response = new Response<string>();

            try
            {
                var resp = _mapper.Map<Municipio>(model);
                response.Data = await _Domain.UpdateAsync(resp);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha actualizado el MunicipioDTO exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado actualizando el municipio " + model.Nombre + ", (" + response.Data + ")");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<string>> DeleteAsync(int? Id)
        {
            var response = new Response<string>();

            try
            {
                response.Data = await _Domain.DeleteAsync(Id);
                if (response.Data == "Success")
                {
                    response.IsSuccess = true;
                    response.Message = "Se ha borrado el registro exitosamente.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un error inesperado, por favor intente nuevamente";
                    _logger.LogWarning("Ha ocurrido un error inesperado eliminando el municipio " + Id.ToString() + ", (" + response.Data + ")");
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError(ex.Message);
            }

            return response;
        }

        public async Task<Response<IEnumerable<MunicipioDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<MunicipioDTO>>();
            try
            {
                var resp = await _Domain.GetAllAsync();

                response.Data = _mapper.Map<IEnumerable<MunicipioDTO>>(resp);
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

        public async Task<Response<MunicipioDTO>> GetAsync(int? Id)
        {
            var response = new Response<MunicipioDTO>();
            try
            {
                var clase = await _Domain.GetAsync(Id);

                response.Data = _mapper.Map<MunicipioDTO>(clase);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Ha ocurrido un inconveniente al consultar los registros.";
                    _logger.LogWarning("Ha ocurrido un error consultando el registro con Id. " + Id.ToString());
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
