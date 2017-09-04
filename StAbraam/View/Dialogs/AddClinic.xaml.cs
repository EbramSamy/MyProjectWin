using System.Windows;

namespace StAbraam.View.Dialogs
{
    /// <summary>
    /// Interaction logic for AddClinic.xaml
    /// </summary>
    public partial class AddClinic : Window
    {
        public AddClinic()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }
    }
}
