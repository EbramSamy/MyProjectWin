using System.Windows;

namespace StAbraam.View.Dialogs
{
    /// <summary>
    /// Interaction logic for AddPhoneNo.xaml
    /// </summary>
    public partial class AddPhone : Window
    {
        public AddPhone()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }
    }
}
