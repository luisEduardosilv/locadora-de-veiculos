using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Dominio.ModuloUsuario;

public class Usuario : IdentityUser<int>
{
	public Usuario()
	{
		EmailConfirmed = true;
	}
}