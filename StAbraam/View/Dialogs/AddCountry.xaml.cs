using System.Windows;

namespace StAbraam.View.Dialogs
{
    /// <summary>
    /// Interaction logic for AddCountry.xaml
    /// </summary>
    public partial class AddCountry : Window
    {
        public AddCountry()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }
    }
}
