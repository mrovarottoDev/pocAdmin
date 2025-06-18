
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); builder.Services.AddEndpointsApiExplorer(); builder.Services.AddSwaggerGen();

// Inje��o de depend�ncias builder.Services.AddScoped<IDbConnectionFactory, AwsRdsMySqlConnectionFactory>(); builder.Services.AddScoped<TbCanalAtendimentoRepository>(); builder.Services.AddScoped<IValidator<TbCanalAtendimentoDto>, TbCanalAtendimentoValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }

app.UseHttpsRedirection(); app.UseAuthorization(); app.MapControllers(); app.Run();