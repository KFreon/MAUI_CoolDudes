using System.Collections.ObjectModel;
using MAUI_CoolDudes.Database;

public class AppState
{
    private readonly DataService dataService;

    public ObservableCollection<CoolDude> CoolDudes { get; private set; } = new();
    public ObservableCollection<CoolDude> UncoolDudes { get; private set; } = new();

    public AppState(DataService dataService)
    {
        this.dataService = dataService;
    }
    public async Task RefreshCoolDudes()
    {
        await dataService.Initialise();

        var dudes = await dataService.GetCoolDudes();
        CoolDudes.Clear();
        UncoolDudes.Clear();
        foreach (var dude in dudes)
        {
            if (dude.AreTheyACoolDude)
                CoolDudes.Add(dude);
            else
                UncoolDudes.Add(dude);
        }
    }

    public async Task AddADude(CoolDude dude)
    {
        await dataService.AddADude(dude);
        await RefreshCoolDudes();
    }

    public async Task RemoveADude(CoolDude dude)
    {
        await dataService.RemoveADude(dude);
        await RefreshCoolDudes();
    }
}

