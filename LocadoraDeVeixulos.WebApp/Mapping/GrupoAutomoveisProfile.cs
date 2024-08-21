using AutoMapper;
using LocadoraDeVeiculos.WebApp.Models;
using LocadoraVeiculos.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeVeiculos.WebApp.Mapping;
public class GrupoAutomoveisProfile : Profile
{
	public GrupoAutomoveisProfile()
	{
		CreateMap<InserirGrupoAutomoveisViewModel, GrupoAutomoveis>();
		CreateMap<EditarGrupoAutomoveisViewModel, GrupoAutomoveis>();
		CreateMap<GrupoAutomoveis, ListarGrupoAutomoveisViewModel>();
		CreateMap<GrupoAutomoveis, DetalhesGrupoAutomoveisViewModel>();
		CreateMap<GrupoAutomoveis, EditarGrupoAutomoveisViewModel>();
	}
}