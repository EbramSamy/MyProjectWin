using System.Windows;

namespace StAbraam.View.Dialogs
{
    /// <summary>
    /// Interaction logic for AddLanguage.xaml
    /// </summary>
    public partial class AddLanguage : Window
    {
        public AddLanguage()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }
    }
}
