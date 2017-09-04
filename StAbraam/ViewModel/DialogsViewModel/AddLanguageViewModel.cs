using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows.Input;

namespace StAbraam.ViewModel.DialogsViewModel
{
    class AddLanguageViewModel : ViewModelBase, IDataErrorInfo
    {
        #region validations
        public string this[string columnName]
        {
            get
            {
                if (columnName == "LanguageName" && string.IsNullOrWhiteSpace(LanguageName))
                {
                    IsValid = false;
                    return "What Is The Language ?!";
                }
                IsValid = true;
                return null;
            }
        }

        [Description("Test-Property")]
        public string Error { get { return string.Empty; } }
        #endregion

        #region properties
        string _languageName = "";
        public string LanguageName
        {
            get { return this._languageName; }
            set
            {
                if (Equals(value, _languageName))
                {
                    return;
                }

                _languageName = value;
                UserMessage = "";
                RaisePropertyChanged("LanguageName");
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

        public bool IsValid
        {
            get;
            set;
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
