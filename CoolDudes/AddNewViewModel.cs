using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUI_CoolDudes;

public partial class AddNewViewModel : ObservableObject
{
	[ObservableProperty]
	private string name;

	[ObservableProperty]
	private bool isCool;
}