using Manufacturing_Society_App.Extensions;
using Microsoft.Maui.Controls;

namespace Manufacturing_Society_App
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            BindingContext = new EventViewModel();
        }
    }
}
