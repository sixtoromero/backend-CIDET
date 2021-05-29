using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIDET.Application.DTO;
using CIDET.Application.Interface;
using CIDET.Transversal.Common;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CIDET.Services.WebAPIRest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MunicipiosController : Controller
    {
        private readonly IMunicipiosApplication _Application;
        private readonly AppSettings _appSettings;
        private readonly IValidator<MunicipioDTO> _messageValidator;

        public MunicipiosController(IMunicipiosApplication Application,
                                IValidator<MunicipioDTO> messageValidator,
                                IOptions<AppSettings> appSettings)
        {
            _Application = Application;
            _appSettings = appSettings.Value;
            _messageValidator = messageValidator;
        }

        [HttpPost]
        public async Task<IActionResult> InsertAsync(MunicipioDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {
                #region Validaciones
                var validResult = _messageValidator.Validate(model);
                if (!validResult.IsValid)
                {
                    response.Data = string.Empty;

                    foreach (var error in validResult.Errors)
                    {
                        response.Data = error.ToString() + "|" + response.Data;
                    }

                    response.Data = response.Data.Substring(0, response.Data.Length - 1);
                    response.IsSuccess = false;
                    return BadRequest(response);
                }
                #endregion

                if (model == null)
                    return BadRequest();

                response = await _Application.InsertAsync(model);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(MunicipioDTO model)
        {
            Response<string> response = new Response<string>();

            try
            {

                #region Validaciones
                var validResult = _messageValidator.Validate(model);
                if (!validResult.IsValid)
                {
                    response.Data = string.Empty;

                    foreach (var error in validResult.Errors)
                    {
                        response.Data = error.ToString() + "|" + response.Data;
                    }

                    response.Data = response.Data.Substring(0, response.Data.Length - 1);
                    response.IsSuccess = false;
                    return BadRequest(response);
                }
                #endregion

                if (model == null)
                    return BadRequest();

                response = await _Application.UpdateAsync(model);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }

        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            Response<string> response = new Response<string>();

            try
            {
                response = await _Application.DeleteAsync(Id);

                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<MunicipioDTO>> response = new Response<IEnumerable<MunicipioDTO>>();

            try
            {
                response = await _Application.GetAllAsync();
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAsync(int Id)
        {
            Response<MunicipioDTO> response = new Response<MunicipioDTO>();

            try
            {
                response = await _Application.GetAsync(Id);
                if (response.IsSuccess)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.IsSuccess = false;
                response.Message = ex.Message;

                return BadRequest(response);
            }
        }

    }
}
