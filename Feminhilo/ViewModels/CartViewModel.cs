using CommunityToolkit.Mvvm.ComponentModel;
using Fem.Shared.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace Feminhilo.ViewModels
{
    public class CartViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ItemD> CartItems { get; set; }

        public CartViewModel()
        {
            CartItems = new ObservableCollection<ItemD>();
            // Optionally, populate your cart items here
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
