using StAbraam.ViewModel;
using System.Windows.Controls;

namespace StAbraam.View
{
    /// <summary>
    /// Interaction logic for EditRemoveCollectionView.xaml
    /// </summary>
    public partial class EditRemoveCollectionView : UserControl
    {
        public EditRemoveCollectionView()
        {
            InitializeComponent();
            this.DataContext = new EditRemoveCollectionViewModel();
        }
    }
}
