using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

Console.WriteLine("This is for EFCore migrations");


public class DesignDbContext : IDesignTimeDbContextFactory<CoolDudeDbContext>
{
    public CoolDudeDbContext CreateDbContext(string[] args)
    {
        return new CoolDudeDbContext(new DbContextOptionsBuilder<CoolDudeDbContext>().UseSqlite("Irrelevant").Options);
    }
}
