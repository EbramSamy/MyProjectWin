using System.Windows;

namespace StAbraam.View.Dialogs
{
    /// <summary>
    /// Interaction logic for AddSuggestion.xaml
    /// </summary>
    public partial class AddSuggestion : Window
    {
        public AddSuggestion()
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
        }
    }
}
