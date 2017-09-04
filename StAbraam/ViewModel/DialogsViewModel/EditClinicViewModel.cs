using GalaSoft.MvvmLight;
using StAbraam.Classes;
using StAbraam.Model;
using System.ComponentModel;
using System.Windows.Input;

namespace StAbraam.ViewModel.DialogsViewModel
{
    class EditClinicViewModel : ViewModelBase, IDataErrorInfo
    {
        #region constructor
        public EditClinicViewModel(Clinic clinic)
        {
            Landline = clinic.Landline;
            BuildingNo = clinic.Address.BuildingNo;
            District = clinic.Address.District;
            StreetNo = clinic.Address.StreetName;

        }
        #endregion

        #region validations
        public string this[string columnName]
        {
            get
            {
                if (columnName == "District" && (string.IsNullOrWhiteSpace(District)))
                {
                    IsValid = false;
                    return "District Name Can't Be Empty";
                }
                if (columnName == "Landline" && (string.IsNullOrWhiteSpace(Landline) || !Utils.IsDigitsOnly(Landline)))
                {
                    IsValid = false;
                    return "Landline Is Should be digits ";
                }
                if (string.IsNullOrWhiteSpace(District) || string.IsNullOrWhiteSpace(Landline) || !Utils.IsDigitsOnly(Landline))
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
        private string _landline = "";
        public string Landline
        {
            get { return this._landline; }
            set
            {
                if (Equals(value, _landline))
                {
                    return;
                }

                _landline = value;
                UserMessage = "";
                RaisePropertyChanged("Landline");
            }
        }

        private string _buildingNo = "";
        public string BuildingNo
        {
            get { return this._buildingNo; }
            set
            {
                if (Equals(value, _buildingNo))
                {
                    return;
                }

                _buildingNo = value;
                UserMessage = "";
                RaisePropertyChanged("BuildingNo");
            }
        }

        private string _streetNo = "";
        public string StreetNo
        {
            get { return this._streetNo; }
            set
            {
                if (Equals(value, _streetNo))
                {
                    return;
                }

                _streetNo = value;
                UserMessage = "";
                RaisePropertyChanged("StreetNo");
            }
        }


        private string _district = "";
        public string District
        {
            get { return this._district; }
            set
            {
                if (Equals(value, _district))
                {
                    return;
                }

                _district = value;
                UserMessage = "";
                RaisePropertyChanged("District");
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

        private ICommand _removeCommand;
        public ICommand RemoveCommand
        {
            get { return this._removeCommand; }
            set
            {
                _removeCommand = value;
                RaisePropertyChanged("RemoveCommand");
            }
        }


        #endregion
    }
}
