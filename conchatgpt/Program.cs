using conchatgpt.repositorio;
using conchatgpt.Service;


//using OpenAISQLWeb.Service;
//using OpenAISQLWeb.repositorio;                       //lo comente pues porque no agarraba xd que raro
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//de por si ya existe un metodo                         implementados:
builder.Services.AddScoped<IDB, DB>();
builder.Services.AddScoped<Iservice, PromptService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
