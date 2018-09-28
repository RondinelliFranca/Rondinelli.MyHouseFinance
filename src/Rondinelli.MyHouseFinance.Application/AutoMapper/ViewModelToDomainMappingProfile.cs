using AutoMapper;
using Rondinelli.MyHouseFinance.Application.ViewModels;
using Rondinelli.MyHouseFinance.Domain.Entities;

namespace Rondinelli.MyHouseFinance.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToDomainMappings";

        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Despesa, DespesaViewModel>();
        }
    }
}