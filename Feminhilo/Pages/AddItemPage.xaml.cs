using Microsoft.Maui.Controls;
using System;
using System.Threading.Tasks;
using Feminhilo.ViewModels;
using Fem.Shared.Data;
using Feminhilo.Services;

namespace Feminhilo.Pages
{
    public partial class AddItemPage : ContentPage
    {
        private readonly IItemsApi _itemService;

        public AddItemPage(IItemsApi itemService)
        {
            InitializeComponent();
            _itemService = itemService;
        }

        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            var name = NameEntry.Text;
            if (double.TryParse(PriceEntry.Text, out double price) && !string.IsNullOrWhiteSpace(name))
            {
                var imageUrl = ImageEntry.Text;

                var newItem = new ItemD(0, name, price, imageUrl);

                try
                {
                    await _itemService.PostItemAsync(newItem);
                    await DisplayAlert("Success", "Item added successfully", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Failed to add item: {ex.Message}", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Please enter valid details", "OK");
            }
        }

        private async void OnGoBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
