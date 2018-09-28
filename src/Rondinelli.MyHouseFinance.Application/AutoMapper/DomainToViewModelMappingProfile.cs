using System;
using AutoMapper;
using Rondinelli.MyHouseFinance.Application.ViewModels;
using Rondinelli.MyHouseFinance.Domain.Entities;

namespace Rondinelli.MyHouseFinance.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "DomainToViewModelMappings";

        public DomainToViewModelMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<DespesaViewModel, Despesa>();
            CreateMap<CategoriaViewModel, Categoria>();
        }
    }
}