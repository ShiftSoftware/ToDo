using Microsoft.EntityFrameworkCore;
using ShiftSoftware.ShiftEntity.CosmosDbSync;
using ToDo.API.Data;

namespace ToDo.API;

public class DbContextProvider : IDbContextProvider
{
    private readonly DbContextOptions dbOptions;

    public DbContextProvider(DbContextOptions dbOptions)
    {
        this.dbOptions = dbOptions;
    }

    public DbContextProvider(Action<DbContextOptionsBuilder> dbOptionsBuilder)
    {
        DbContextOptionsBuilder optionsBuilder = new();
        dbOptionsBuilder.Invoke(optionsBuilder);

        this.dbOptions = optionsBuilder.Options;
    }

    public DbContext ProvideDbContext()
    {
        return new DB(dbOptions);
    }
}
