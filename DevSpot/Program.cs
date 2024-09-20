using DevSpot.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do serviço de banco de dados usando Entity Framework Core
// O ApplicationDbContext será usado para acessar o banco de dados, e a string de conexão 
// está definida nas configurações (appsettings.json ou outros arquivos de configuração).
builder.Services.AddDbContext<ApplicationDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração do Identity para autenticação e autorização
// Aqui estamos adicionando o serviço de Identity, permitindo autenticação de usuários.
// O método AddDefaultIdentity adiciona as funcionalidades padrão de login e registro.
// Adiciona também o suporte a Roles (papéis) e usa o ApplicationDbContext para armazenar os dados.
builder.Services.AddDefaultIdentity<IdentityUser>(
	options => options.SignIn.RequireConfirmedAccount = false) // Não requer confirmação de conta para logar
	.AddRoles<IdentityRole>() // Suporte a roles (papéis)
	.AddEntityFrameworkStores<ApplicationDbContext>(); // Usa o banco de dados para armazenar usuários e roles

// Adiciona o serviço de controle MVC com views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurações para o pipeline de requisições HTTP

if (!app.Environment.IsDevelopment())
{
	// Configura um handler de exceção para ambientes de produção
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts(); // Ativa HSTS (HTTP Strict Transport Security) para melhorar a segurança
}


app.UseHttpsRedirection(); // Redireciona requisições HTTP para HTTPS


app.UseStaticFiles(); // Habilita o uso de arquivos estáticos (como CSS, JavaScript, imagens)


app.UseRouting(); // Habilita o roteamento de requisições


app.UseAuthorization(); // Habilita a autorização (Identity será usado para verificar permissões)


app.MapRazorPages(); // Mapeia as páginas Razor para o pipeline de requisições


// Define a rota padrão da aplicação, apontando para o controller "Home" e a action "Index"
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


// Inicia a aplicação
app.Run();