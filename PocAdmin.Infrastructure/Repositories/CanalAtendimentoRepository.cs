using Dapper;
using Domain.Entities;
using PocAdmin.Infrastructure.Db;
using System.Data;

public class CanalAtendimentoRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public CanalAtendimentoRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<TbCanalAtendimento>> GetAllAsync()
    {
        using var conn = _connectionFactory.CreateConnection();
        return await conn.QueryAsync<TbCanalAtendimento>("SELECT * FROM TbCanalAtendimento");
    }

    public async Task<TbCanalAtendimento?> GetByIdAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();
        return await conn.QueryFirstOrDefaultAsync<TbCanalAtendimento>(
            "SELECT * FROM TbCanalAtendimento WHERE CodigoCanal = @id", new { id });
    }

    public async Task<int> CreateAsync(TbCanalAtendimento canal)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"
            INSERT INTO TbCanalAtendimento (CodigoCanal, DescricaoCanal, Ativo)
            VALUES (@CodigoCanal, @DescricaoCanal, @Ativo)";
        return await conn.ExecuteAsync(sql, canal);
    }

    public async Task<int> UpdateAsync(TbCanalAtendimento canal)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = @"
            UPDATE TbCanalAtendimento 
            SET DescricaoCanal = @DescricaoCanal, Ativo = @Ativo
            WHERE CodigoCanal = @CodigoCanal";
        return await conn.ExecuteAsync(sql, canal);
    }

    public async Task<int> DeleteAsync(int id)
    {
        using var conn = _connectionFactory.CreateConnection();
        return await conn.ExecuteAsync(
            "DELETE FROM TbCanalAtendimento WHERE CodigoCanal = @id", new { id });
    }
}