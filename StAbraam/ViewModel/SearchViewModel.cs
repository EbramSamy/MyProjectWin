using GalaSoft.MvvmLight;
using System.ComponentModel;
using System;
using GalaSoft.MvvmLight.Messaging;
using StAbraam.Classes;
using System.Diagnostics;
using System.Collections.ObjectModel;
using StAbraam.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Data;
using Microsoft.Win32;
using System.Windows;

namespace StAbraam.ViewModel
{
    public class SearchViewModel : ViewModelBase, IDataErrorInfo
    {
        private DataProvider _data;
        public SearchViewModel()
        {
            _data = new DataProvider();
            Messenger.Default.Register<string>(this, DoctorAdded);
        }

        private void DoctorAdded(string message)
        {
            if (message.Equals(Utils.DoctorAddedMessage))
            {
                Debug.WriteLine("Doctor Added Clicked");
                //DoctorList = new ObservableCollection<Doctor>(_data.GetDoctors());

            }
            else if ((message.Equals(Utils.CountryAddedMessage)))
            {
                Countries = new ObservableCollection<Country>(_data.GetCountries());
            }
            else if ((message.Equals(Utils.CityAddedMessage)))
            {
                if (SelectedCountry != null)
                    Cities = new ObservableCollection<City>(_data.GetCities(SelectedCountry.CountryID));
            }
            else if ((message.Equals(Utils.SpecialtyAddedMessage)))
            {
                Specialties = new ObservableCollection<Specialty>(_data.GetSpecialties());
            }
            else if ((message.Equals(Utils.subSpecialtyAddedMessage)))
            {
                if (SelectedSpecialty != null)
                    SubSpecialties = new ObservableCollection<Sub_Specialty>(_data.GetSubSpecialties(SelectedSpecialty.SpecialtyID));
            }
            else if ((message.Equals(Utils.ServiceAddedMessage)))
            {
                Services = new ObservableCollection<Service>(_data.GetServices());
            }
            else if ((message.Equals(Utils.LanguageAddedMessage)))
            {
                Languages = new ObservableCollection<Language>(_data.GetLanguages());
            }
        }

        public string this[string columnName]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }


        private bool _isSearchOpen;
        public bool IsSearchOpen
        {
            get
            {
                return _isSearchOpen;
            }
            set
            {
                _isSearchOpen = value;
                RaisePropertyChanged("IsSearchOpen");
            }
        }

        private ICommand _openSearchCommand;
        public ICommand OpenSearchCommand
        {
            get
            {
                if (_openSearchCommand == null)
                {
                    _openSearchCommand = new RelayCommand(() =>
                    {
                        IsSearchOpen = true;
                    });
                }
                return _openSearchCommand;
            }
        }
        private ObservableCollection<Doctor> _doctorList;
        public ObservableCollection<Doctor> DoctorList
        {
            get
            {
                //if (_doctorList == null)
                //    _doctorList = new ObservableCollection<Doctor>(_data.GetDoctors());
                return _doctorList;
            }
            set
            {
                _doctorList = value;
                if(_doctorList!=null && _doctorList.Count>0)
                {
                    CanSave = true;
                }
                else
                {
                    CanSave = false;
                }
                RaisePropertyChanged("DoctorList");
            }
        }


        #region Properties
        private string _fullName = "";
        public string FullName
        {
            get { return this._fullName; }
            set
            {
                if (Equals(value, _fullName))
                {
                    return;
                }
                _fullName = value;
                RaisePropertyChanged("FullName");
            }
        }
        private string _nationalID = "";
        public string NationalID
        {
            get { return this._nationalID; }
            set
            {
                if (Equals(value, _nationalID))
                {
                    return;
                }
                _nationalID = value;
                RaisePropertyChanged("NationalID");
            }
        }
        private DateTime? _dateOfBirth = null;
        public DateTime? DateOfBirth
        {
            get { return this._dateOfBirth; }
            set
            {
                if (Equals(value, _dateOfBirth))
                {
                    return;
                }
                _dateOfBirth = value;
                RaisePropertyChanged("DateOfBirth");
            }
        }
        private string _phoneNo = "";
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
                RaisePropertyChanged("PhoneNo");
            }
        }
        private string _email = "";
        public string Email
        {
            get { return this._email; }
            set
            {
                if (Equals(value, _email))
                {
                    return;
                }
                _email = value;
                RaisePropertyChanged("Email");
            }
        }
        private ObservableCollection<Country> _countries;
        public ObservableCollection<Country> Countries
        {
            get
            {
                if (_countries == null)
                    _countries = new ObservableCollection<Country>(_data.GetCountries());
                return _countries;
            }
            set
            {
                _countries = value;
                RaisePropertyChanged("Countries");
            }
        }
        private ObservableCollection<City> _cities;
        public ObservableCollection<City> Cities
        {
            get
            {
                if (SelectedCountry != null)
                    _cities = new ObservableCollection<City>(_data.GetCities(SelectedCountry.CountryID));
                return _cities;
            }
            set
            {
                _cities = value;
                RaisePropertyChanged("Cities");
            }
        }
        private string _diocese = "";
        public string Diocese
        {
            get { return this._diocese; }
            set
            {
                if (Equals(value, _diocese))
                {
                    return;
                }
                _diocese = value;
                RaisePropertyChanged("Diocese");
            }
        }

        private ObservableCollection<Specialty> _specialties;
        public ObservableCollection<Specialty> Specialties
        {
            get
            {
                if (_specialties == null)
                    _specialties = new ObservableCollection<Specialty>(_data.GetSpecialties());
                return _specialties;
            }
            set
            {
                _specialties = value;
                RaisePropertyChanged("Specialties");
            }
        }
        private ObservableCollection<Sub_Specialty> _subSpecialties;
        public ObservableCollection<Sub_Specialty> SubSpecialties
        {
            get
            {
                if (SelectedSpecialty != null)
                    _subSpecialties = new ObservableCollection<Sub_Specialty>(_data.GetSubSpecialties(SelectedSpecialty.SpecialtyID));
                return _subSpecialties;
            }
            set
            {
                _subSpecialties = value;
                RaisePropertyChanged("SubSpecialties");
            }
        }
        private ObservableCollection<Language> _languages;
        public ObservableCollection<Language> Languages
        {
            get
            {
                if (_languages == null)
                    _languages = new ObservableCollection<Language>(_data.GetLanguages());
                return _languages;
            }
            set
            {
                _languages = value;
                RaisePropertyChanged("Languages");
            }
        }
        private ObservableCollection<Language> _spokenLanguages;
        public ObservableCollection<Language> SpokenLanguages
        {
            get
            {
                if (_spokenLanguages == null)
                    _spokenLanguages = new ObservableCollection<Language>();
                return _spokenLanguages;
            }
            set
            {
                _spokenLanguages = value;
                RaisePropertyChanged("SpokenLanguages");
            }
        }
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
        private Country _selectedCountry;
        public Country SelectedCountry
        {
            get
            {
                return _selectedCountry;
            }
            set
            {
                _selectedCountry = value;
                if (SelectedCountry != null)
                    Cities = new ObservableCollection<City>(_data.GetCities(SelectedCountry.CountryID));
                RaisePropertyChanged("SelectedCountry");
            }
        }
        private Clinic _selectedClinic;
        public Clinic SelectedClinic
        {
            get
            {
                return _selectedClinic;
            }
            set
            {
                _selectedClinic = value;
                RaisePropertyChanged("SelectedClinic");
            }
        }
        private City _selectedCity;
        public City SelectedCity
        {
            get
            {
                return _selectedCity;
            }
            set
            {
                _selectedCity = value;
                RaisePropertyChanged("SelectedCity");
            }
        }
        private Specialty _selectedSpecialty;
        public Specialty SelectedSpecialty
        {
            get
            {
                return _selectedSpecialty;
            }
            set
            {
                _selectedSpecialty = value;
                if (SelectedSpecialty != null)
                    SubSpecialties = new ObservableCollection<Sub_Specialty>(_data.GetSubSpecialties(SelectedSpecialty.SpecialtyID));
                RaisePropertyChanged("SelectedSpecialty");
            }
        }
        private Sub_Specialty _selectedSubSpecialty;
        public Sub_Specialty SelectedSubSpecialty
        {
            get
            {
                return _selectedSubSpecialty;
            }
            set
            {
                _selectedSubSpecialty = value;
                RaisePropertyChanged("SelectedSubSpecialty");
            }
        }
        private string _currentOccupation;
        public string CurrentOccupation
        {
            get
            {
                return _currentOccupation;
            }
            set
            {
                _currentOccupation = value;
                RaisePropertyChanged("CurrentOccupation");
            }
        }
        private string _currentAffiliation;
        public string CurrentAffiliation
        {
            get
            {
                return _currentAffiliation;
            }
            set
            {
                _currentAffiliation = value;
                RaisePropertyChanged("CurrentAffiliation");
            }
        }
        private string _clinicLandline;
        public string ClinicLandline
        {
            get
            {
                return _clinicLandline;
            }
            set
            {
                _clinicLandline = value;
                RaisePropertyChanged("ClinicLandline");
            }
        }
        private string _clinicStreetName;
        public string ClinicStreetName
        {
            get
            {
                return _clinicStreetName;
            }
            set
            {
                _clinicStreetName = value;
                RaisePropertyChanged("ClinicStreetName");
            }
        }
        private string _clinicDistrict;
        public string ClinicDistrict
        {
            get
            {
                return _clinicDistrict;
            }
            set
            {
                _clinicDistrict = value;
                RaisePropertyChanged("ClinicDistrict");
            }
        }
        private Language _selectedLanguage;
        public Language SelectedLanguage
        {
            get
            {
                return _selectedLanguage;
            }
            set
            {
                _selectedLanguage = value;
                RaisePropertyChanged("SelectedLanguage");
            }
        }
        private Service _selectedCurrentService;
        public Service SelectedCurrentService
        {
            get
            {
                return _selectedCurrentService;
            }
            set
            {
                _selectedCurrentService = value;
                RaisePropertyChanged("SelectedCurrentService");
            }
        }

        private Service _selectedToJoinService;
        public Service SelectedToJoinService
        {
            get
            {
                return _selectedToJoinService;
            }
            set
            {
                _selectedToJoinService = value;
                RaisePropertyChanged("SelectedToJoinService");
            }
        }
        private string _suggestion;
        public string Suggestion
        {
            get
            {
                return _suggestion;
            }
            set
            {
                _suggestion = value;
                RaisePropertyChanged("Suggestion");
            }
        }

        private DateTime? _from = null;
        public DateTime? From
        {
            get { return this._from; }
            set
            {
                if (Equals(value, _from))
                {
                    return;
                }
                _from = value;
                RaisePropertyChanged("From");
            }
        }

        private DateTime? _to = null;
        public DateTime? To
        {
            get { return this._to; }
            set
            {
                if (Equals(value, _to))
                {
                    return;
                }
                _to = value;
                RaisePropertyChanged("To");
            }
        }

        private DateTime? _registrationDate = null;
        public DateTime? RegistrationDate
        {
            get { return this._registrationDate; }
            set
            {
                if (Equals(value, _registrationDate))
                {
                    return;
                }
                _registrationDate = value;
                RaisePropertyChanged("RegistrationDate");
            }
        }


        private bool _canSave = false;
        public bool CanSave
        {
            get { return this._canSave; }
            set
            {
                if (Equals(value, _canSave))
                {
                    return;
                }
                _canSave = value;
                RaisePropertyChanged(()=> CanSave);
            }
        }

        #endregion

        #region Commands
        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new RelayCommand(() =>
                {
                    DoctorList = new ObservableCollection<Doctor>(_data.SearchForDoctor(FullName, NationalID, DateOfBirth, PhoneNo, Email, SelectedCountry, SelectedCity, Diocese, SelectedSpecialty, SelectedSubSpecialty, CurrentOccupation, SelectedLanguage, CurrentAffiliation, ClinicLandline, ClinicStreetName, ClinicDistrict, SelectedCurrentService, SelectedToJoinService, From, To, Suggestion, RegistrationDate));
                    IsSearchOpen = false;
                }));
            }
            set
            {
                _searchCommand = value;
            }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(() =>
                {
                    if (CanSave)
                    {
                        ExcelUtlity obj = new ExcelUtlity();
                        DataTable dt = ExcelUtlity.ConvertToDataTable(new List<Doctor>(DoctorList));
                        SaveFileDialog savefile = new SaveFileDialog();
                        // set a default file name
                        savefile.FileName = "Doctors.xls";
                        // set filters - this can be done in properties as well
                        savefile.Filter = "Excel files (*.xls)|*.xls";
                        bool res = savefile.ShowDialog() ?? false;
                        if (res)
                        {
                            obj.WriteDataTableToExcel(dt, "Doctors", savefile.FileName, "Details");
                        }
                        //Utils.SaveReport(new List<Doctor>(DoctorList));
                    }

                }));
            }
            set
            {
                _saveCommand = value;
            }
        }

        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ?? (_clearCommand = new RelayCommand(() =>
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Are You Sure ?", "Clear", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        FullName = "";
                        NationalID = "";
                        DateOfBirth = null;
                        PhoneNo = "";
                        Email = "";
                        SelectedCountry = null;
                        SelectedCity = null;
                        Diocese = "";
                        SelectedSpecialty = null;
                        SelectedSubSpecialty = null;
                        CurrentOccupation = "";
                        SpokenLanguages = null;
                        CurrentAffiliation = "";
                        ClinicLandline = "";
                        ClinicStreetName = "";
                        ClinicDistrict = "";
                        SelectedCurrentService = null;
                        SelectedToJoinService = null;
                        From = null;
                        To = null;
                        Suggestion = null;
                        RegistrationDate = null;
                    }
                }));
            }
            set
            {
                _clearCommand = value;
            }
        }
        #endregion
    }
}
