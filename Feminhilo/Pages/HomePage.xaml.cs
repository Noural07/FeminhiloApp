using Fem.Shared.Data;
using Feminhilo.ViewModels;

namespace Feminhilo.Pages
{
    public partial class HomePage : ContentPage
    {
        private readonly HomeViewModel _homeViewModel;
        private readonly CartViewModel _cartViewModel;

        public HomePage(HomeViewModel homeViewModel, CartViewModel cartViewModel)
        {
            InitializeComponent();
            _homeViewModel = homeViewModel;
            _cartViewModel = cartViewModel;
            BindingContext = _homeViewModel;
        }

        private void OnAddToCartClicked(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button button)
                {
                    var item = button.BindingContext as ItemD;
                    if (item != null)
                    {
                        AddItemToCart(item);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("BindingContext is not an ItemD.");
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Sender is not a Button.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in OnAddToCartClicked: {ex.Message}");
            }
        }

        private void AddItemToCart(ItemD item)
        {
            _cartViewModel.CartItems.Add(item);
            Application.Current.MainPage.DisplayAlert("Cart", item.Name + " added to cart!", "OK");
        }

        private async void OnNavigateToCartPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CartPage(_cartViewModel));
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _homeViewModel.InitializeAsync();
        }
    }
}
