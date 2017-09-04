using GalaSoft.MvvmLight;
using StAbraam.Classes;
using System.ComponentModel;
using System.Windows.Input;

namespace StAbraam.ViewModel.DialogsViewModel
{
    public class AddPhoneViewModel : ViewModelBase, IDataErrorInfo
    {
        #region validations
        public string this[string columnName]
        {
            get
            {
                if (columnName == "PhoneNo" && (!Utils.IsDigitsOnly(this.PhoneNo)))
                {
                    IsValid = false;
                    return "Phone Number Should be Digits Only";
                }
                IsValid = true;
                return null;
            }
        }

        [Description("Test-Property")]
        public string Error { get { return string.Empty; } }
        #endregion

        #region properties
        string _phoneNo = "";
        public string PhoneNo
        {
            get { return this._phoneNo; }
            set
            {
                if (Equals(value, _phoneNo))
                {
                    return;
                }

                _phoneNo = value;
                UserMessage = "";
                RaisePropertyChanged("PhoneNo");
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
