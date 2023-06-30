using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using GitHubActionsDemo.Persistance.Infrastructure;
using Microsoft.Extensions.Options;

namespace GitHubActionsDemo.Persistance;

public class DbContext : IDbContext
{
    private readonly DbSettings _dbSettings;

    public DbContext(IOptions<DbSettings> dbSettings)
    {
        _dbSettings = dbSettings?.Value ?? throw new ArgumentNullException(nameof(dbSettings));
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_dbSettings.ConnectionString);
    }

    public async Task Init()
    {
        await InitDatabase();
        await InitTables();
    }

    private async Task InitDatabase()
    {
        // create database if it doesn't exist
        using var connection = new MySqlConnection(_dbSettings.ConnectionString);
        var sql = $"CREATE DATABASE IF NOT EXISTS `{_dbSettings.Database}`;";
        await connection.ExecuteAsync(sql);
    }

    private async Task InitTables()
    {
        // create tables if they don't exist
        using var connection = CreateConnection();
        await _initAuthors();
        await _initBooks();

        async Task _initAuthors()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS Authors (
                    AuthorId INT NOT NULL AUTO_INCREMENT,
                    FirstName VARCHAR(255) NOT NULL,
                    LastName VARCHAR(255) NOT NULL,
                    DateCreated DATETIME NOT NULL,
                    DateModified DATETIME NOT NULL,
                    PRIMARY KEY (AuthorId)
                );
            """;
            await connection.ExecuteAsync(sql);
        }

        async Task _initBooks()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS Books(
                    BookId INT NOT NULL AUTO_INCREMENT,
                    Title VARCHAR(255),
                    AuthorId INT NOT NULL,
                    Isbn VARCHAR(13) NOT NULL,
                    DatePublished DATETIME NOT NULL,
                    DateCreated DATETIME NOT NULL,
                    DateModified DATETIME NOT NULL,
                    PRIMARY KEY(BookId),
                    FOREIGN KEY(AuthorId) REFERENCES Authors(AuthorId)
                );
            """;
            await connection.ExecuteAsync(sql);
        }


    }
}
