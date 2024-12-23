using System.Data.Common;
using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext:IContext
{
    readonly string connectionString=  "Server=localhost; Port = 5432; Database = Examination; User Id = postgres; Password = 1234;";
    

    public DbConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}

public interface IContext
{
    public DbConnection Connection();
}