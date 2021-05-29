using CIDET.Application.DTO;
using FluentValidation;

namespace CIDET.Services.WebAPIRest.Validator
{
    public class DepartamentoDTOValidator : AbstractValidator<DepartamentoDTO>
    {
        public DepartamentoDTOValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().Length(5, 120)
                .WithMessage("Por favor especifíque el nombre del departamento.");
        }
    }
}
