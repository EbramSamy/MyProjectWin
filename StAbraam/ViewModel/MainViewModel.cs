using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Reflection;
using System.Windows.Input;

namespace StAbraam.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        #region constructor
        public MainViewModel()
        {

            #region Command Implementation 
            MenuItemSelected = new RelayCommand(() =>
             {
                 switch (HamburgerMenuSelectedIndex)
                 {
                     case (0):
                         {
                             //AddView addView = new AddView();
                             //TransitioningContent=addView;
                             //addView.DataContext = new AddViewModel();
                             break;
                         }
                     case (1):
                         {
                             break;
                         }
                 }
             });

            #endregion
        }
        #endregion

        #region Properties
        private int _hamburgerMenuSelectedIndex = 0;
        public int HamburgerMenuSelectedIndex
        {
            get
            {
                return _hamburgerMenuSelectedIndex;
            }
            set
            {
                _hamburgerMenuSelectedIndex = value;
                RaisePropertyChanged("HamburgerMenuSelectedIndex");
            }

        }

        private string _versionStr = "V " + Assembly.GetEntryAssembly().GetName().Version.ToString();
        public string VersionStr
        {
            get
            {
                return _versionStr;
            }
        }


        //private UserControl _transitioningContent;
        //public UserControl TransitioningContent
        //{

        //    get
        //    {
        //        return _transitioningContent;
        //    }
        //    set
        //    {
        //        _transitioningContent = value;
        //        RaisePropertyChanged("TransitioningContent");
        //    }
        //}


        #endregion


        #region Commands
        public ICommand MenuItemSelected { get; set; }
        #endregion
    }
}
