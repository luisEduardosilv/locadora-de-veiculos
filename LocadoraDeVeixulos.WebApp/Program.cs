using LocadoraVeiculos.Aplicacao.Servicos;
using LocadoraVeiculos.Dominio.ModuloGrupoAutomoveis;
using LocadoraVeiculos.Dominio.ModuloUsuario;
using LocadoraVeiculos.Infra.Orm.ModuloGrupoAutomoveis;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using LocadoraVeiculos.Infra.Orm.Compartilhado;

namespace LocadoraDeVeiculos.WebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();

			#region Inje��o de Depend�ncia de Servi�os

			builder.Services.AddDbContext<LocadoraVeiculosDbContext>();

			builder.Services.AddScoped<IRepositorioGrupoAutomoveis, RepositorioGrupoAutomoveisEmOrm>();

			builder.Services.AddScoped<GrupoAutomoveisService>();


			builder.Services.AddIdentity<Usuario, Perfil>()
				.AddEntityFrameworkStores<LocadoraVeiculosDbContext>()
				.AddDefaultTokenProviders();

			builder.Services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequiredLength = 3;
				options.Password.RequiredUniqueChars = 1;
			});

			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.Cookie.Name = "AspNetCore.Cookies";
					options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
					options.SlidingExpiration = true;
				});

			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Usuario/Login";
				options.AccessDeniedPath = "/Usuario/AcessoNegado";
			});

			builder.Services.AddAutoMapper(cfg =>
			{
				cfg.AddMaps(Assembly.GetExecutingAssembly());
			});

			#endregion

			var app = builder.Build();

			app.UseStaticFiles();

			app.MapControllerRoute("default", "{controller=Inicio}/{action=Index}/{id:int?}");

			app.Run();
		}
	}
}
