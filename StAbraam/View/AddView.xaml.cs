using StAbraam.ViewModel;
using System.Windows.Controls;

namespace StAbraam.View
{
    /// <summary>
    /// Interaction logic for AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {
        public AddView()
        {
            InitializeComponent();
            this.DataContext = new AddViewModel();
        }
    }
}
