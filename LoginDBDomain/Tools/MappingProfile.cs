using AutoMapper;
using LoginDB.Models;
using LoginDBServices.Models.DTOs;

namespace LoginDBServices.Tools
{
    public class MappingProfile : Profile
    {
        // Crear mapeos DE (MODELO RECIBIDO) A (MODELO GENERADO)
        public MappingProfile()
        {
            CreateMap<Module, ModuleResponse>();
        }
    }
}
