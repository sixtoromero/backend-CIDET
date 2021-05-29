using AutoMapper;
using CIDET.Application.DTO;
using CIDET.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIDET.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            
            CreateMap<Municipio, MunicipioDTO>().ReverseMap();
            CreateMap<Departamento, DepartamentoDTO>().ReverseMap();
        }
    }
}
