using StAbraam.ViewModel;
using System.Windows.Controls;

namespace StAbraam.View
{
    /// <summary>
    /// Interaction logic for DoctorsView.xaml
    /// </summary>
    public partial class DoctorsView : UserControl
    {
        public DoctorsView()
        {
            InitializeComponent();
            DataContext = new DoctorViewModel();
        }

      
    }
}
