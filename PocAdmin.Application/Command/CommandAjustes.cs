//// ---------------------------
//// CreateCanalCommand.cs
//using MediatR;
//using System.Runtime.InteropServices;

//namespace Application.Commands.TbCanalAtendimento;

//public class CreateCanalCommand : IRequest<int>
//{
//    public int CodigoCanal { get; set; }
//    public string DescricaoCanal { get; set; } = string.Empty;
//    public bool Ativo { get; set; }
//}

//// ---------------------------
//// UpdateCanalCommand.cs
//using MediatR;

//namespace Application.Commands.TbCanalAtendimento;

//public class UpdateCanalCommand : IRequest
//{
//    public int CodigoCanal { get; set; }
//    public string DescricaoCanal { get; set; } = string.Empty;
//    public bool Ativo { get; set; }
//}

//// ---------------------------
//// CreateCanalHandler.cs
//using Application.Commands.TbCanalAtendimento;
//using Domain.Entities;
//using Infrastructure.Repositories;
//using MediatR;

//namespace Application.Handlers.TbCanalAtendimento;

//public class CreateCanalHandler : IRequestHandler<CreateCanalCommand, int>
//{
//    private readonly TbCanalAtendimentoRepository _repo;

//    public CreateCanalHandler(TbCanalAtendimentoRepository repo)
//    {
//        _repo = repo;
//    }

//    public async Task<int> Handle(CreateCanalCommand request, CancellationToken cancellationToken)
//    {
//        var entity = new TbCanalAtendimento
//        {
//            CodigoCanal = request.CodigoCanal,
//            DescricaoCanal = request.DescricaoCanal,
//            Ativo = request.Ativo
//        };

//        return await _repo.CreateAsync(entity);
//    }
//}

//// ---------------------------
//// UpdateCanalHandler.cs
//using Application.Commands.TbCanalAtendimento;
//using Domain.Entities;
//using Infrastructure.Repositories;
//using MediatR;

//namespace Application.Handlers.TbCanalAtendimento;

//public class UpdateCanalHandler : IRequestHandler<UpdateCanalCommand>
//{
//    private readonly TbCanalAtendimentoRepository _repo;

//    public UpdateCanalHandler(TbCanalAtendimentoRepository repo)
//    {
//        _repo = repo;
//    }

//    public async Task<Unit> Handle(UpdateCanalCommand request, CancellationToken cancellationToken)
//    {
//        var entity = new TbCanalAtendimento
//        {
//            CodigoCanal = request.CodigoCanal,
//            DescricaoCanal = request.DescricaoCanal,
//            Ativo = request.Ativo
//        };

//        await _repo.UpdateAsync(entity);
//        return Unit.Value;
//    }
//}

//// ---------------------------
//// TbCanalAtendimentoController.cs (AJUSTADO)
//using Microsoft.AspNetCore.Mvc;
//using Application.Dtos;
//using MediatR;
//using Application.Commands.TbCanalAtendimento;
//using Infrastructure.Repositories;

//[ApiController]
//[Route("api/[controller]")]
//public class TbCanalAtendimentoController : ControllerBase
//{
//    private readonly IMediator _mediator;
//    private readonly TbCanalAtendimentoRepository _repo;

//    public TbCanalAtendimentoController(IMediator mediator, TbCanalAtendimentoRepository repo)
//    {
//        _mediator = mediator;
//        _repo = repo;
//    }

//    [HttpGet]
//    public async Task<IActionResult> GetAll() => Ok(await _repo.GetAllAsync());

//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetById(int id)
//    {
//        var canal = await _repo.GetByIdAsync(id);
//        return canal is not null ? Ok(canal) : NotFound();
//    }

//    [HttpPost]
//    public async Task<IActionResult> Create([FromBody] CreateCanalCommand command)
//    {
//        var result = await _mediator.Send(command);
//        return CreatedAtAction(nameof(GetById), new { id = command.CodigoCanal }, command);
//    }

//    [HttpPut("{id}")]
//    public async Task<IActionResult> Update(int id, [FromBody] UpdateCanalCommand command)
//    {
//        command.CodigoCanal = id;
//        await _mediator.Send(command);
//        return NoContent();
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> Delete(int id)
//    {
//        await _repo.DeleteAsync(id);
//        return NoContent();
//    }
//}

//// ---------------------------
//// Program.cs (AJUSTE)
//using Infrastructure.Db;
//using Infrastructure.Repositories;
//using FluentValidation;
//using Application.Dtos;
//using Application.Validators;
//using MediatR;
//using Application.Handlers.TbCanalAtendimento;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// Injeções
//builder.Services.AddScoped<IDbConnectionFactory, AwsRdsMySqlConnectionFactory>();
//builder.Services.AddScoped<TbCanalAtendimentoRepository>();
//builder.Services.AddScoped<IValidator<TbCanalAtendimentoDto>, TbCanalAtendimentoValidator>();

//// MediatR
//builder.Services.AddMediatR(typeof(CreateCanalHandler).Assembly);

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
//app.Run();