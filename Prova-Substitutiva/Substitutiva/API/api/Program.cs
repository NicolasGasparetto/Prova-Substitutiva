using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

builder.Services.AddCors(options =>
    options.AddPolicy("Acesso Total",
        configs => configs
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod())
);

var app = builder.Build();


app.MapGet("/", () => "Prova Substitutiva");

//GET: http://localhost:pages/imc/listar{id}
app.MapGet("pages/imc/listar{id}", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.IMCs.Any())
    {
        return Results.Ok(ctx.IMCs.ToList());
    }
    return Results.NotFound("Nenhum Imc encontrado");
});

//GET: http://localhost:pages/IMCs/{imc}}/alunos/{aluno}
app.MapPost("/api/IMCs/{imcs}/Alunos/{aluno}", ([FromRoute] string imc, [FromRoute] string aluno, [FromServices] AppDataContext ctx) =>
{
    var imc = ctx.IMCs.Find(imc);
    var aluno = ctx.Alunos.Find(aluno);

    if (imc == null || aluno == null)
    {
        return Results.NotFound("Imc ou Aluno não encontrado");
    }

    imc.Alunos.Add(aluno);
    ctx.SaveChanges();

    return Results.Created("", imc);
});

//POST: http://localhost:/pages/aluno/cadastrar
app.MapPost("pages/aluno/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] Aluno aluno) =>
{
    ctx.Alunos.Add(aluno);
    ctx.SaveChanges();
    return Results.Created("", aluno);
});

//POST: http://localhost:pages/imc/cadastrar
app.MapPost("pages/imc/cadastrar", ([FromServices] AppDataContext ctx, [FromBody] IMC imc) =>
{
    ctx.IMCs.Add(imc);
    ctx.SaveChanges();
    return Results.Created("", imc);
});

//PUT: http://localhost:pages/imc/alterar/{id}
app.MapPut("pages/imc/alterar/{id}", ([FromServices] AppDataContext ctx, [FromRoute] string id) =>
{
    IMC? imc = ctx.Agendas.Find(id);
    if (imc is null)
    {
        return Results.NotFound("imc não encontrado");
    }
    ctx.IMCs.Update(imc);
    ctx.SaveChanges();
    return Results.Ok(ctx.IMCs.ToList());
});
   

   Private decimais CalcularImc(decimais peso, decimais altura)
   {
     return peso / (altura * altura)
   }
