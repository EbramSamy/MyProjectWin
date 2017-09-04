using System.Windows;

namespace StAbraam.View.Dialogs
{
    /// <summary>
    /// Interaction logic for AddPeriod.xaml
    /// </summary>
    public partial class AddPeriod : Window
    {
        public AddPeriod()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }
    }
}
