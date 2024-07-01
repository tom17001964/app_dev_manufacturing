using System;
using System.Data.SQLite;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using CommunityToolkit.Maui.Views;


namespace Manufacturing_Society_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Hook up event handler for the login button
            LoginButton.Clicked += LoginButton_Click;

            // Hook up event handler for Enter key press on text entry fields
            txtUserName.Completed += (s, e) => txtPassword.Focus(); // Move focus to password field
            txtPassword.Completed += (s, e) => LoginButton_Click(s, EventArgs.Empty); // Call login button click event
        }

        private async void LoginButton_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=C:\\Users\\JackG\\Desktop\\Manufacturing_Society_App\\Model.db;Version=3;"; // Connection string for SQLite database file

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string username = txtUserName.Text;
                string password = txtPassword.Text;

                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        await DisplayAlert("Success", "Login successful!", "OK");
                        // Navigate to the dashboard page
                        await Navigation.PushAsync(new DashboardPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Invalid username or password.", "OK");
                    }
                }
            }
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            entry.Text = ""; // Clear the text when the entry gets focused
        }

        private void Entry_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            if (string.IsNullOrEmpty(entry.Text))
            {
                // Restore the placeholder text if the entry is left empty
                if (entry == txtUserName)
                    entry.Placeholder = "Enter email address";
                else if (entry == txtPassword)
                    entry.Placeholder = "Enter password";
            }
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            // Show the SignUp popup
            this.ShowPopup(new SignUpPopup());
        }
    }
}
