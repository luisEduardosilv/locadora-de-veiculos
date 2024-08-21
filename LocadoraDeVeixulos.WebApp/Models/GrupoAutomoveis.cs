using System.ComponentModel.DataAnnotations;

namespace LocadoraDeVeiculos.WebApp.Models;

public class InserirGrupoAutomoveisViewModel
{
	[Required(ErrorMessage = "A descrição é obrigatória")]
	[MinLength(6, ErrorMessage = "A descrição deve conter ao menos 6 caracteres")]
	public string Nome { get; set; }
}

public class EditarGrupoAutomoveisViewModel
{
	public int Id { get; set; }

	[Required(ErrorMessage = "A descrição é obrigatória")]
	[MinLength(6, ErrorMessage = "A descrição deve conter ao menos 6 caracteres")]
	public string Nome { get; set; }
}

public class ListarGrupoAutomoveisViewModel
{
	public int Id { get; set; }
	public string Nome { get; set; }
}

public class DetalhesGrupoAutomoveisViewModel
{
	public int Id { get; set; }
	public string Nome { get; set; }
}