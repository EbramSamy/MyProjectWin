using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows.Input;

namespace StAbraam.ViewModel.DialogsViewModel
{
    class AddCityViewModel : ViewModelBase, IDataErrorInfo
    {
        #region constructor

        public AddCityViewModel(string countryName)
        {
            this.CountryName = countryName;
        }

        #endregion


        #region validations

        public string this[string columnName]
        {
            get
            {

                if (columnName == "CityName" && (string.IsNullOrWhiteSpace(CityName)))
                {
                    IsValid = false;
                    return "City Name Can't Be Empty";
                }
                if (string.IsNullOrWhiteSpace(CountryName) || string.IsNullOrWhiteSpace(CityName))
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

        private string _countryName = "";
        public string CountryName
        {
            get { return this._countryName; }
            set
            {
                if (Equals(value, _countryName))
                {
                    return;
                }

                _countryName = value;
                UserMessage = "";
                RaisePropertyChanged("CountryName");
            }
        }

        private string _cityName = "";
        public string CityName
        {
            get { return this._cityName; }
            set
            {
                if (Equals(value, _cityName))
                {
                    return;
                }

                _cityName = value;
                UserMessage = "";
                RaisePropertyChanged("CityName");
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

        #endregion
    }
}
