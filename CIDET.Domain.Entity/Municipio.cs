using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIDET.Domain.Entity
{
    public class Municipio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Nombre { get; set; }
        [Required]        
        public int DepartamentoId { get; set; }
        [Required]
        [MaxLength(8)]
        public string CodigoDANE { get; set; }
        [Required]
        public bool EsDistrito { get; set; }
    }
}
