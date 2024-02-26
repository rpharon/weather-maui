using WeatherApp.Adapters.ViewModels;

namespace WeatherApp.UI.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _vm;

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            _vm = vm;

            BindingContext = _vm;
        }

        protected override async void OnAppearing()
        {
            await _vm.GetCurrentWeather();

            base.OnAppearing();
        }
    }
}
