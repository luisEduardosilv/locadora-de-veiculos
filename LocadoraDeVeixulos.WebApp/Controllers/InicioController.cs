using AutoMapper;
using LocadoraDeVeiculos.WebApp.Extensions;
using LocadoraVeiculos.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeVeiculos.WebApp.Controllers;
public class InicioController : WebControllerBase
{
	private readonly GrupoAutomoveisService servicoGrupoAutomoveis;
	private readonly IMapper mapeador;

	public InicioController(
		GrupoAutomoveisService servicoGrupoAutomoveis,
		IMapper mapeador
	)
	{
		this.servicoGrupoAutomoveis = servicoGrupoAutomoveis;
		this.mapeador = mapeador;
	}

	public ViewResult Index()
	{
		if (UsuarioId.HasValue)
		{
			ViewBag.QuantidadeGrupoAutomoveiss = servicoGrupoAutomoveis.SelecionarTodos(UsuarioId.Value).Value.Count;
		}

		ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

		return View();
	}
}