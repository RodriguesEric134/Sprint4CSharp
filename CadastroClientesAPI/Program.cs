using CadastroClientesAPI.Data;
using CadastroClientesAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto Oracle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona o serviço ViaCep
builder.Services.AddHttpClient<ViaCepService>();

// Adiciona os controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ativa o Swagger em ambiente de dev
if (app.Environment.IsDevelopment() ||
    string.Equals(builder.Configuration["EnableSwagger"], "true", StringComparison.OrdinalIgnoreCase))
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/health", () => Results.Ok("healthy"));

}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
