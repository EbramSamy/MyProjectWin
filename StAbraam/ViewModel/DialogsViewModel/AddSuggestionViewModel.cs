using GalaSoft.MvvmLight;
using StAbraam.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace StAbraam.ViewModel.DialogsViewModel
{
    class AddSuggestionViewModel : ViewModelBase, IDataErrorInfo
    {
        DataProvider _data;

        #region constructor
        public AddSuggestionViewModel()
        {
            _data = new DataProvider();
        }
        #endregion


        #region validations
        public string this[string columnName]
        {
            get
            {

                if (columnName == "Suggestion" && (string.IsNullOrWhiteSpace(Suggestion)))
                {
                    IsValid = false;
                    return "Suggestion Can't Be Empty";
                }
                if (columnName == "SelectedService" && (SelectedService == null))
                {
                    IsValid = false;
                    return "Selected Service Can't Be Empty";
                }

                if ((string.IsNullOrWhiteSpace(Suggestion) || (SelectedService == null)))
                {
                    IsValid = false;
                    return null;
                }
                IsValid = true;
                return null;
            }
        }

        [Description("Test-Property")]
        public string Error { get { return string.Empty; } }
        #endregion


        #region properties
        private ObservableCollection<Service> _services;
        public ObservableCollection<Service> Services
        {
            get
            {
                if (_services == null)
                    _services = new ObservableCollection<Service>(_data.GetServices());
                return _services;
            }
            set
            {
                _services = value;
                RaisePropertyChanged("Services");
            }
        }


        private string _suggestion = "";
        public string Suggestion
        {
            get { return this._suggestion; }
            set
            {
                if (Equals(value, _suggestion))
                {
                    return;
                }

                _suggestion = value;
                UserMessage = "";
                RaisePropertyChanged("Suggestion");
            }
        }


        string _userMessage = "";
        public string UserMessage
        {
            get { return this._userMessage; }
            set
            {
                if (Equals(value, _userMessage))
                {
                    return;
                }

                _userMessage = value;
                RaisePropertyChanged("UserMessage");
            }
        }

        private bool _isValid = false;
        public bool IsValid
        {
            get { return this._isValid; }
            set
            {
                _isValid = value;
                RaisePropertyChanged("IsValid");
            }
        }
        #endregion


        #region Commands
        private ICommand _oKCommand;
        public ICommand OKCommand
        {
            get { return this._oKCommand; }
            set
            {
                _oKCommand = value;
                RaisePropertyChanged("OKCommand");
            }
        }

        private ICommand _CancelCommand;
        public ICommand CancelCommand
        {
            get { return this._CancelCommand; }
            set
            {
                _CancelCommand = value;
                RaisePropertyChanged("CancelCommand");
            }
        }

        private Service _selectedService;
        public Service SelectedService
        {
            get
            {
                return _selectedService;
            }
            set
            {
                _selectedService = value;
                RaisePropertyChanged("SelectedService");
            }
        }



        #endregion
    }
}
