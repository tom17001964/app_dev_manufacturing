using System;
using System.Data.SQLite;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using CommunityToolkit.Maui.Views;

namespace Manufacturing_Society_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPopup : Popup
    {
        public SignUpPopup()
        {
            InitializeComponent();
        }

        private async void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            string email = SignUpEmail.Text;
            string password = SignUpPassword.Text;
            string confirmPassword = SignUpConfirmPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "All fields are required.", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }

            // Save user to the database
            SaveUser(email, password);

            await Application.Current.MainPage.DisplayAlert("Success", "Sign up successful!", "OK");
            Close(); // Close the popup
        }

        private void SaveUser(string email, string password)
        {
            string connectionString = "Data Source=C:\\Users\\JackG\\Desktop\\Manufacturing_Society_App\\Model.db;Version=3;"; // Connection string for SQLite database file

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
