namespace Manufacturing_Society_App
{
    public partial class ProfileMenuPopup : ContentView
    {
        public ProfileMenuPopup()
        {
            InitializeComponent();
        }

        void OnProfileClicked(object sender, EventArgs e)
        {
            // Navigate to profile page
            // Navigation.PushAsync(new ProfilePage());
        }

        void OnSettingsClicked(object sender, EventArgs e)
        {
            // Navigate to settings page
            // Navigation.PushAsync(new SettingsPage());
        }
    }
}
