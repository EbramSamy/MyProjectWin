using System.Windows;

namespace StAbraam.View.Dialogs
{
    /// <summary>
    /// Interaction logic for AddCity.xaml
    /// </summary>
    public partial class AddCity : Window
    {
        public AddCity()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }
    }
}
