using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio.Compartilhado;

namespace LocadoraVeiculos.Dominio.ModuloGrupoAutomoveis
{
	public class GrupoAutomoveis : EntidadeBase
	{
		public string Nome { get; set; }

		public GrupoAutomoveis()
		{

		}

		public GrupoAutomoveis(string nome)
		{
			Nome = nome;
		}
	}
}
