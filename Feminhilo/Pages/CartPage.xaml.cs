using Feminhilo.ViewModels;

namespace Feminhilo.Pages
{
    public partial class CartPage : ContentPage
    {
        private readonly CartViewModel _cartViewModel;

        public CartPage(CartViewModel cartViewModel)
        {
            InitializeComponent();
            _cartViewModel = cartViewModel;
            BindingContext = _cartViewModel;

        }

        private async void OnCheckoutClicked(object sender, EventArgs e)
        {
            // Implement your checkout logic here
            await DisplayAlert("Checkout", "Proceeding to checkout...", "OK");

            
        }
    }
}
