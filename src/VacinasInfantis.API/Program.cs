using VacinasInfantis.Infrastrutura.ExtensaoDependencia;
using VacinasInfantis.Aplicacao.ExtensaoDependencia;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AdicionarRepositorios(builder.Configuration);
builder.Services.AdicionarAplicacao();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
