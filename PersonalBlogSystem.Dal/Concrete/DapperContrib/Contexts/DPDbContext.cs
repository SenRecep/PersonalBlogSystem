using Dapper.Contrib.Extensions;


using Microsoft.EntityFrameworkCore;

using PersonalBlogSystem.Dal.Concrete.EntityFrameworkCore.Contexts;

using System.Data;
using System.Data.SqlClient;

namespace PersonalBlogSystem.Dal.Concrete.DapperContrib.Contexts;

public class DPDbContext
{
    static DPDbContext()
    {

        SqlMapperExtensions.TableNameMapper = (type) =>
        {
            string? tableName = typeof(EFDbContext)
            .GetProperties()
            .FirstOrDefault(o =>
                o.PropertyType.IsGenericType &&
                o.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                o.PropertyType.GenericTypeArguments.Contains(type))
            ?.Name;
            return tableName ?? type.Name;
        };
    }

    public string _connectionString { get; set; }

    public DPDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection GetConnection() => new SqlConnection(_connectionString);

}
