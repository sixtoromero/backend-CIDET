using System;
using System.Collections.Generic;
using System.Text;

namespace CIDET.Application.DTO
{
    public class MunicipioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DepartamentoId { get; set; }        
        public string CodigoDANE { get; set; }        
        public bool EsDistrito { get; set; }
    }
}
