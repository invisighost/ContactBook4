using ContactBook4.Model;
using System.Windows;

namespace ContactBook4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel vm = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void addContactButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AddContact();
        }

        private void deleteContactButton_Click(object sender, RoutedEventArgs e)
        {
            vm.DeleteContact(vm.SelectedContact);
        }

        private void saveContact_Click(object sender, RoutedEventArgs e)
        {
            vm.SaveContact(vm.SelectedContact);
        }
    }
}
