using Psicologia.Web.App;
using Psicologia.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<TokenCookie>();
builder.Services.AddScoped(typeof(HttpService<>)); // Certifique-se de que o HttpService seja registrado corretamente
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar o pipeline de solicitações HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();