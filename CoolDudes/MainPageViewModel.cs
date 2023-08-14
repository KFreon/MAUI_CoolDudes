namespace MAUI_CoolDudes
{
    public class MainPageViewModel
    {
        public AppState State { get; set; }

        public MainPageViewModel(AppState state)
        {
            State = state;
        }

        public Task Initialise()
        {
            return State.RefreshCoolDudes();
        }
    }
}