using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows.Input;

namespace StAbraam.ViewModel.DialogsViewModel
{
    class AddServiceViewModel : ViewModelBase, IDataErrorInfo
    {
        #region validations
        public string this[string columnName]
        {
            get
            {
                if (columnName == "ServiceName" && string.IsNullOrWhiteSpace(ServiceName))
                {
                    IsValid = false;
                    return "What Is The Service ?!";
                }
                IsValid = true;
                return null;
            }
        }

        [Description("Test-Property")]
        public string Error { get { return string.Empty; } }
        #endregion

        string _serviceName = "";
        public string ServiceName
        {
            get { return this._serviceName; }
            set
            {
                if (Equals(value, _serviceName))
                {
                    return;
                }

                _serviceName = value;
                UserMessage = "";
                RaisePropertyChanged("ServiceName");
            }
        }

        #region properties
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
