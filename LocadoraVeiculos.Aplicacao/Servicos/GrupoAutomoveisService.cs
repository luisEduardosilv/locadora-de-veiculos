using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraVeiculos.Aplicacao.Servicos;

public class GrupoAutomoveisService
{
	private readonly IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis;

	public GrupoAutomoveisService(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
	{
		this.repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
	}

	public Result<GrupoAutomoveis> Inserir(GrupoAutomoveis grupoAutomoveis)
	{
		repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);

		return Result.Ok(grupoAutomoveis);
	}

	public Result<GrupoAutomoveis> Editar(GrupoAutomoveis grupoAutomoveisAtualizado)
	{
		var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisAtualizado.Id);

		if (grupoAutomoveis is null)
			return Result.Fail("O Grupo não foi encontrado!");

		grupoAutomoveis.Nome = grupoAutomoveisAtualizado.Nome;

		repositorioGrupoAutomoveis.Editar(grupoAutomoveis);

		return Result.Ok(grupoAutomoveis);
	}

	public Result Excluir(int grupoAutomoveisId)
	{
		var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisId);

		if (grupoAutomoveis is null)
			return Result.Fail("O grupo não foi encontrado!");

		repositorioGrupoAutomoveis.Excluir(grupoAutomoveis);

		return Result.Ok();
	}

	public Result<GrupoAutomoveis> SelecionarPorId(int grupoAutomoveisId)
	{
		var grupoAutomoveis = repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisId);

		if (grupoAutomoveis is null)
			return Result.Fail("O grupo não foi encontrado!");

		return Result.Ok(grupoAutomoveis);
	}

	public Result<List<GrupoAutomoveis>> SelecionarTodos(int usuarioId)
	{
		var gruposAutomoveis = repositorioGrupoAutomoveis
			.Filtrar(f => f.UsuarioId == usuarioId);

		return Result.Ok(gruposAutomoveis);
	}
}