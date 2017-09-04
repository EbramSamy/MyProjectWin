using GalaSoft.MvvmLight;
using StAbraam.Classes;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace StAbraam.ViewModel.DialogsViewModel
{
    class AddPeriodViewModel : ViewModelBase, IDataErrorInfo
    {
        #region validations
        public string this[string columnName]
        {
            get
            {
                if (((columnName == "FromDate") || (columnName == "ToDate")) && (DateTime.Compare(FromDate, ToDate) >= 0))
                {
                    IsValid = false;
                    return "Invalid Date From should be befor To";
                }

                IsValid = true;

                return null;
            }
        }

        [Description("Test-Property")]
        public string Error { get { return string.Empty; } }
        #endregion


        #region properties
        private DateTime _fromDate = DateTime.Today;
        public DateTime FromDate
        {
            get { return this._fromDate; }
            set
            {
                if (Equals(value, _fromDate))
                {
                    return;
                }

                _fromDate = value;
                UserMessage = "";
                if (ToDate != null)
                    Difference = new DateDifference(FromDate, ToDate);
                RaisePropertyChanged("FromDate");
                RaisePropertyChanged("ToDate");
            }
        }

        private DateTime _toDate = DateTime.Today;
        public DateTime ToDate
        {
            get { return this._toDate; }
            set
            {
                if (Equals(value, _toDate))
                {
                    return;
                }

                _toDate = value;
                UserMessage = "";
                if (FromDate != null)
                    Difference = new DateDifference(FromDate, ToDate);
                RaisePropertyChanged("ToDate");
                RaisePropertyChanged("FromDate");
            }
        }

        private DateDifference _difference;
        public DateDifference Difference
        {
            get { return this._difference; }
            set
            {
                if (Equals(value, _difference))
                {
                    return;
                }

                _difference = value;
                RaisePropertyChanged("Difference");
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
        private ICommand _addCommand;
        public ICommand AddCommand
        {
            get { return this._addCommand; }
            set
            {
                _addCommand = value;
                RaisePropertyChanged("AddCommand");
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
