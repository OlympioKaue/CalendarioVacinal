using VacinasInfantis.Infrastrutura.ExtensaoDependencia;
using VacinasInfantis.Aplicacao.ExtensaoDependencia;
using Hangfire;
using VacinasInfantis.API.FiltroExcecao;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AdicionarRepositorios(builder.Configuration);
builder.Services.AdicionarAplicacao();
builder.Services.AddMvc(adicione => adicione.Filters.Add(typeof(FiltroDeExcecao))); // adicione o filtro de exceção




var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
