using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.ModuloGrupoAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloGrupoAutomoveis
{
	public class MapeadorGrupoAutomoveisEmOrm : IEntityTypeConfiguration<GrupoAutomoveis>
	{
		public void Configure(EntityTypeBuilder<GrupoAutomoveis> eBuilder)
		{
			eBuilder.ToTable("TBGrupoAutomoveis");

			eBuilder.Property(e => e.Id)
				.IsRequired()
				.ValueGeneratedOnAdd();

			eBuilder.Property(e => e.Nome)
				.IsRequired()
				.HasColumnType("varchar(100)");

			eBuilder.Property(s => s.UsuarioId)
				.IsRequired()
				.HasColumnType("int")
				.HasColumnName("Usuario_Id");

			eBuilder.HasOne(g => g.Usuario)
				.WithMany()
				.HasForeignKey(s => s.UsuarioId)
				.OnDelete(DeleteBehavior.NoAction);
		}
	}
}