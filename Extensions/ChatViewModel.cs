using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System;
using System.Threading.Tasks;

namespace Manufacturing_Society_App.Extensions
{
    public class ChatMessage
    {
        public string Content { get; set; }
        public string Timestamp { get; set; }
        public bool IsIncoming { get; set; } // To distinguish between incoming and outgoing messages
    }

    public partial class ChatViewModel : ObservableObject
    {
        private ObservableCollection<ChatMessage> _messages;
        public ObservableCollection<ChatMessage> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        private string _newMessage;
        public string NewMessage
        {
            get => _newMessage;
            set => SetProperty(ref _newMessage, value);
        }

        private readonly WeatherService _weatherService;

        public ChatViewModel()
        {
            _weatherService = new WeatherService();
            Messages = new ObservableCollection<ChatMessage>
            {
                new ChatMessage { Content = "Hello", Timestamp = DateTime.Now.ToString("h:mm tt"), IsIncoming = true },
                new ChatMessage { Content = "Welcome to the Manufacturing Society Social App. You can find upcoming events right here on the main dashboard. More updates and features coming soon!", Timestamp = DateTime.Now.ToString("h:mm tt"), IsIncoming = true }
            };
        }

        [RelayCommand]
        private void SendMessage()
        {
            if (!string.IsNullOrWhiteSpace(NewMessage))
            {
                Messages.Add(new ChatMessage { Content = NewMessage, Timestamp = DateTime.Now.ToString("h:mm tt"), IsIncoming = false });
                NewMessage = string.Empty;
            }
        }

        [RelayCommand]
        private async Task SendWeatherAsync()
        {
            var weatherMessage = await _weatherService.GetWeatherAsync("Manchester"); // Replace "YourCityName" with the desired city name
            Messages.Add(new ChatMessage { Content = weatherMessage, Timestamp = DateTime.Now.ToString("h:mm tt"), IsIncoming = true });
        }
    }
}
