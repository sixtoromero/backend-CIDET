using CIDET.Application.DTO;
using FluentValidation;

namespace CIDET.Services.WebAPIRest.Validator
{
    public class MunicipioDTOValidator : AbstractValidator<MunicipioDTO>
    {
        public MunicipioDTOValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().Length(5, 120)
                .WithMessage("Por favor especifíque el nombre del Municipio.");

            RuleFor(x => x.CodigoDANE).NotEmpty().Length(5, 5)
                    .WithMessage("Por favor especifíque correctamente el Código DANE.");            
        }        
    }
}
