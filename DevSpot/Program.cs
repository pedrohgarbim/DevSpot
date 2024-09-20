using DevSpot.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do servi�o de banco de dados usando Entity Framework Core
// O ApplicationDbContext ser� usado para acessar o banco de dados, e a string de conex�o 
// est� definida nas configura��es (appsettings.json ou outros arquivos de configura��o).
builder.Services.AddDbContext<ApplicationDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura��o do Identity para autentica��o e autoriza��o
// Aqui estamos adicionando o servi�o de Identity, permitindo autentica��o de usu�rios.
// O m�todo AddDefaultIdentity adiciona as funcionalidades padr�o de login e registro.
// Adiciona tamb�m o suporte a Roles (pap�is) e usa o ApplicationDbContext para armazenar os dados.
builder.Services.AddDefaultIdentity<IdentityUser>(
	options => options.SignIn.RequireConfirmedAccount = false) // N�o requer confirma��o de conta para logar
	.AddRoles<IdentityRole>() // Suporte a roles (pap�is)
	.AddEntityFrameworkStores<ApplicationDbContext>(); // Usa o banco de dados para armazenar usu�rios e roles

// Adiciona o servi�o de controle MVC com views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura��es para o pipeline de requisi��es HTTP

if (!app.Environment.IsDevelopment())
{
	// Configura um handler de exce��o para ambientes de produ��o
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts(); // Ativa HSTS (HTTP Strict Transport Security) para melhorar a seguran�a
}

// Redireciona requisi��es HTTP para HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles(); // Habilita o uso de arquivos est�ticos (como CSS, JavaScript, imagens)

app.UseRouting(); // Habilita o roteamento de requisi��es

app.UseAuthorization(); // Habilita a autoriza��o (Identity ser� usado para verificar permiss�es)

// Define a rota padr�o da aplica��o, apontando para o controller "Home" e a action "Index"
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

// Inicia a aplica��o
app.Run();
