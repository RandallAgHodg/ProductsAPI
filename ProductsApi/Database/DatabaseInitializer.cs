using Dapper;

namespace ProductsApi.Database;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS Products (
	                                        Id CHAR(36) PRIMARY KEY,
                                            Name TEXT NOT NULL,
                                            Description TEXT NOT NULL,
                                            Stock INT NOT NULL,
                                            Price DECIMAL(8,4) NOT NULL,
                                            PictureUrl TEXT NOT NULL,
                                            InsertTimeStamp DATETIME DEFAULT NOW()
                                            )");
    }
}