using CommunityToolkit.Mvvm.ComponentModel;
using Fem.Shared.Data;
using Feminhilo.Services;
using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Feminhilo.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly IItemsApi _itemsApi;
        private bool _isInitialized;
        private CartViewModel _cartViewModel;
        public ICommand AddItemCommand { get; }

        [ObservableProperty]
        private ObservableCollection<ItemD> cartItems;

        public HomeViewModel(IItemsApi itemsApi)
        {
            _itemsApi = itemsApi;
            _items = Array.Empty<ItemD>();
            CartItems = new ObservableCollection<ItemD>();
            AddItemCommand = new Command<ItemD>(AddItemToCart);

            

        }

        [ObservableProperty]
        private ItemD[] _items;

        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            IsBusy = true;

            try
            {
                // API call
                Items = await _itemsApi.GetItemsAsync();
                _isInitialized = true;
            }
            catch (Exception ex)
            {
                // Handle the exception as needed
                Console.WriteLine($"Error in InitializeAsync: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void AddItemToCart(ItemD item)
        {
            if (!CartItems.Contains(item))
            {
                CartItems.Add(item);
            }
        }

       
    }
}
