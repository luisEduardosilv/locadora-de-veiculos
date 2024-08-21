using LocadoraVeiculos.Dominio.ModuloUsuario;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoAutomoveis;

namespace LocadoraVeiculos.Infra.Orm.Compartilhado;

public class LocadoraVeiculosDbContext : IdentityDbContext<Usuario, Perfil, int>
{
	public DbSet<GrupoAutomoveis> GruposAutomoveis { get; set; }
	
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var connectionString = config
			.GetConnectionString("SqlServer");

		optionsBuilder.UseSqlServer(connectionString);

		optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();

		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new MapeadorGrupoAutomoveisEmOrm());
		
		base.OnModelCreating(modelBuilder);
	}
}