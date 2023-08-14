using MAUI_CoolDudes.Database;
using Microsoft.EntityFrameworkCore;

public class DataService
{
    private readonly CoolDudeDbContext dbContext;
    private bool isInitialised = false;

    public DataService(CoolDudeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<CoolDude[]> GetCoolDudes() => await dbContext.CoolDudes.ToArrayAsync();
    

    public async Task AddADude(CoolDude dude)
    {
        dbContext.CoolDudes.Add(dude);
        await dbContext.SaveChangesAsync();
    }

    public async Task RemoveADude(CoolDude dude)
    {
        dbContext.CoolDudes.Remove(dude);
        await dbContext.SaveChangesAsync();
    }

    public async Task Initialise()
    {
        if (isInitialised) return;

        await dbContext.Database.MigrateAsync();
        isInitialised = true;
    }
}

