using CommunityToolkit.Maui.Views;
using MAUI_CoolDudes.Database;

namespace MAUI_CoolDudes;

public partial class AddNewModal : Popup
{
    private readonly AppState appState;

    public AddNewModal(AppState appState)
	{
		InitializeComponent();
        this.appState = appState;

        BindingContext = new AddNewViewModel();
    }

    private async void Add(object sender, EventArgs e)
    {
        var vm = BindingContext as AddNewViewModel;
        var coolDude = new CoolDude { Name = vm.Name, AreTheyACoolDude = vm.IsCool };
        await appState.AddADude(coolDude);
		this.Close();
    }
}
