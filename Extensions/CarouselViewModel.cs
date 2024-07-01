using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace Manufacturing_Society_App.Extensions
{
    public class CarouselViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _images;
        public ObservableCollection<string> Images
        {
            get => _images;
            set
            {
                if (_images != value)
                {
                    _images = value;
                    OnPropertyChanged(nameof(Images));
                }
            }
        }

        public CarouselViewModel()
        {
            Images = new ObservableCollection<string>();
            LoadImages();
        }

        private void LoadImages()
        {
            var imagePaths = new[]
            {
                "C:\\Users\\JackG\\Desktop\\Manufacturing_Society_App\\Resources\\Images\\NewFolder\\Apple Logo.png",
                "C:\\Users\\JackG\\Desktop\\Manufacturing_Society_App\\Resources\\Images\\NewFolder\\Apple Logo.png",
                "C:\\Users\\JackG\\Desktop\\Manufacturing_Society_App\\Resources\\Images\\NewFolder\\Apple Logo.png"
            };

            foreach (var path in imagePaths)
            {
                if (File.Exists(path))
                {
                    Images.Add(path);
                }
                else
                {
                    // Log or handle invalid path
                    Console.WriteLine($"Image path not found: {path}");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
