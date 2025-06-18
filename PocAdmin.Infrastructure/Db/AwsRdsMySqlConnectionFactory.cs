using Amazon.RDS.Util;
using MySqlConnector;
using PocAdmin.Infrastructure.Db;
using System.Data;

public class AwsRdsMySqlConnectionFactory : IDbConnectionFactory
{
    private readonly IConfiguration _config;

    public AwsRdsMySqlConnectionFactory(IConfiguration config)
    {
        _config = config;
    }

    public IDbConnection CreateConnection()
    {
        var host = _config["RDS:Host"];
        var port = int.Parse(_config["RDS:Port"]);
        var user = _config["RDS:User"];
        var region = _config["RDS:Region"];
        var database = _config["RDS:Database"];

        var generator = new RDSAuthTokenGenerator(region);
        var token = generator.GenerateAuthToken(host, port, user);

        var connStr = new MySqlConnectionStringBuilder
        {
            Server = host,
            Port = (uint)port,
            UserID = user,
            Password = token,
            SslMode = MySqlSslMode.Required,
            Database = database
        }.ToString();

        return new MySqlConnection(connStr);
    }
}