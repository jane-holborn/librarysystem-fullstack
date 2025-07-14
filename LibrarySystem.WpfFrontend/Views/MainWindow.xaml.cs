using LibrarySystem.WpfFrontend.Models;
using LibrarySystem.WpfFrontend.Services;
using System.Windows;

namespace LibrarySystem.WpfFrontend
{
    public partial class MainWindow : Window
    {
        private ApiClient _apiClient;
        public MainWindow()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
        }

        private async void BtnLoadUsers_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = await _apiClient.GetAllUsersAsync();
            ListBoxUsers.ItemsSource = users;
        }
    }
}