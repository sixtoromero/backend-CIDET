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
    public class DepartamentosController : Controller
    {
        private readonly IDepartamentosApplication _Application;
        private readonly AppSettings _appSettings;
        private readonly IValidator<DepartamentoDTO> _messageValidator;

        public DepartamentosController(IDepartamentosApplication Application,
                                IValidator<DepartamentoDTO> messageValidator,
                                IOptions<AppSettings> appSettings)
        {
            _Application = Application;
            _appSettings = appSettings.Value;
            _messageValidator = messageValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response<IEnumerable<DepartamentoDTO>> response = new Response<IEnumerable<DepartamentoDTO>>();

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


    }
}
