using Manufacturing_Society_App.Extensions;
using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace Manufacturing_Society_App.Views
{
    public partial class ChatView : ContentPage
    {
        public ChatView()
        {
            InitializeComponent();
            BindingContext = new ChatViewModel();
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ChatViewModel.Messages))
            {
                MessagesCollectionView.ScrollTo(MessagesCollectionView.ItemsSource.Cast<object>().Last(), animate: true);
            }
        }
    }
}
