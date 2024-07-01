using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;
using System.Threading.Tasks;

namespace Manufacturing_Society_App.Extensions
{
    public static class PopupExtensions
    {
        public static async Task ShowAlert(this Popup popup, string title, string message, string cancel)
        {
            if (popup.Parent is Page page)
            {
                await page.DisplayAlert(title, message, cancel);
            }
        }
    }
}
