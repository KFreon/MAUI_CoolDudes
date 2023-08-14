using CommunityToolkit.Maui.Views;
using MAUI_CoolDudes.Database;

namespace MAUI_CoolDudes
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;
        private readonly IServiceProvider services;

        public MainPage(IServiceProvider services)
        {
            InitializeComponent();
            viewModel = services.GetRequiredService<MainPageViewModel>();
            this.services = services;
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.Initialise();
        }

        public void AddACoolDude(object sender, EventArgs e)
        {
            var appState = services.GetRequiredService<AppState>();
            App.Current.MainPage.ShowPopup(new AddNewModal(appState));
        }

        private async void DeleteADude(object sender, EventArgs e)
        {
            var appState = services.GetRequiredService<AppState>();
            var dude = (sender as Button).BindingContext as CoolDude;
            await appState.RemoveADude(dude);
        }
    }
}