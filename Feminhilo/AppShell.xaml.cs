using Feminhilo.Pages;
using Microsoft.Maui.Controls;

namespace Feminhilo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

#if WINDOWS || MACCATALYST
            Routing.RegisterRoute(nameof(AddItemPage), typeof(Pages.AddItemPage));
#endif
        }
    }
}
