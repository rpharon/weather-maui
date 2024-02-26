using WeatherApp.Adapters.ViewModels;

namespace WeatherApp.UI.Views
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _vm;
        int count = 0;

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

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
