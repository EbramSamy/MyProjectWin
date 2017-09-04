using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Windows.Input;

namespace StAbraam.ViewModel.DialogsViewModel
{
    class AddSubSpecialtyViewModel : ViewModelBase, IDataErrorInfo
    {
        #region constructor
        public AddSubSpecialtyViewModel(string specialtyName)
        {
            this.SpecialtyName = specialtyName;
        }
        #endregion

        #region validations
        public string this[string columnName]
        {
            get
            {

                if (columnName == "SubSpecialtyName" && (string.IsNullOrWhiteSpace(SubSpecialtyName)))
                {
                    IsValid = false;
                    return "Sub-Specialty Name Can't Be Empty";
                }
                if (string.IsNullOrWhiteSpace(SpecialtyName) || string.IsNullOrWhiteSpace(SubSpecialtyName))
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
        private string _specialtyName = "";
        public string SpecialtyName
        {
            get { return this._specialtyName; }
            set
            {
                if (Equals(value, _specialtyName))
                {
                    return;
                }

                _specialtyName = value;
                UserMessage = "";
                RaisePropertyChanged("SpecialtyName");
            }
        }

        private string _subSpecialtyName = "";
        public string SubSpecialtyName
        {
            get { return this._subSpecialtyName; }
            set
            {
                if (Equals(value, _subSpecialtyName))
                {
                    return;
                }

                _subSpecialtyName = value;
                UserMessage = "";
                RaisePropertyChanged("SpecialtyName");
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
