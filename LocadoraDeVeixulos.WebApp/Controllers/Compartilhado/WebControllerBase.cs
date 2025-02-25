﻿using LocadoraDeVeiculos.WebApp.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LocadoraDeVeiculos.WebApp.Controllers;

public abstract class WebControllerBase : Controller
{
	protected int? UsuarioId
	{
		get
		{
			var usuarioAutenticado = User.FindFirst(ClaimTypes.NameIdentifier);

			if (usuarioAutenticado is null)
				return null;

			return int.Parse(usuarioAutenticado.Value);
		}
	}

	//protected IActionResult MensagemRegistroNaoEncontrado(int idRegistro)
	//{
	//	TempData.SerializarMensagemViewModel(new MensagemViewModel
	//	{
	//		Titulo = "Erro",
	//		Mensagem = $"Não foi possível encontrar o registro ID [{idRegistro}]!"
	//	});

	//	return RedirectToAction("Index", "Inicio");
	//}

	//protected void ApresentarMensagemFalha(Result resultado)
	//{
	//	ViewBag.Mensagem = new MensagemViewModel
	//	{
	//		Titulo = "Falha",
	//		Mensagem = resultado.Errors[0].Message
	//	};
	//}

	//protected void ApresentarMensagemSucesso(string mensagem)
	//{
	//	TempData.SerializarMensagemViewModel(new MensagemViewModel
	//	{
	//		Titulo = "Sucesso",
	//		Mensagem = mensagem
	//	});
	//}
}