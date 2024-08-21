using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Infra.Orm.ModuloGrupoAutomoveis;

public class RepositorioGrupoAutomoveisEmOrm : RepositorioBaseEmOrm<GrupoAutomoveis>, IRepositorioGrupoAutomoveis
{
	public RepositorioGrupoAutomoveisEmOrm(
		LocadoraVeiculosDbContext dbContext) : base(dbContext)
	{
	}

	protected override DbSet<GrupoAutomoveis> ObterRegistros()
	{
		return _dbContext.GruposAutomoveis;
	}

	public List<GrupoAutomoveis> Filtrar(Func<GrupoAutomoveis, bool> predicate)
	{
		return _dbContext.GruposAutomoveis
			.Where(predicate)
			.ToList();
	}
}