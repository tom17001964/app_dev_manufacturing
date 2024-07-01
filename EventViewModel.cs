using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;

namespace Manufacturing_Society_App.Extensions
{
    public class EventViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<EventModel> _events;
        public ObservableCollection<EventModel> Events
        {
            get => _events;
            set
            {
                if (_events != value)
                {
                    _events = value;
                    OnPropertyChanged(nameof(Events));
                }
            }
        }

        public EventViewModel()
        {
            LoadImagesFromFolder("C:\\Users\\JackG\\Desktop\\Manufacturing_Society_App\\Resources\\Images\\Events");
        }

        private void LoadImagesFromFolder(string folderPath)
        {
            var eventList = new ObservableCollection<EventModel>();

            if (Directory.Exists(folderPath))
            {
                var imageFiles = Directory.GetFiles(folderPath, "*.png"); // You can add more file types if needed
                foreach (var imagePath in imageFiles)
                {
                    eventList.Add(new EventModel { ImagePath = imagePath, Title =null });
                }
            }

            Events = eventList;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class EventModel
    {
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public ICommand RegisterCommand { get; set; }

        public EventModel()
        {
            RegisterCommand = new Command(OnRegister);
        }

        private void OnRegister()
        {
            // Implement registration logic here
            App.Current.MainPage.DisplayAlert("Registration", $"You have registered for {Title}", "OK");
        }
    }
}
