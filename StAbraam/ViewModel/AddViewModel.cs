using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StAbraam.Classes;
using StAbraam.Model;
using StAbraam.View.Dialogs;
using StAbraam.ViewModel.DialogsViewModel;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.Diagnostics;

namespace StAbraam.ViewModel
{
    public class AddViewModel : ViewModelBase, IDataErrorInfo
    {
        DataProvider _data;

        #region constructor
        public AddViewModel()
        {
            Messenger.Default.Register<string>(this, DataChanged);
            _data = new DataProvider();
            SelectedCountry = _data.GetCountries().FirstOrDefault();
            if (SelectedCountry != null)
            {
                SelectedCity = SelectedCountry.Cities.FirstOrDefault();
            }
            SelectedSpecialty = _data.GetSpecialties().FirstOrDefault();
            if (SelectedSpecialty != null)
            {
                SelectedSubSpecialty = SelectedSpecialty.Sub_Specialty.FirstOrDefault();
            }

        }
        #endregion

        #region validations
        private void DataChanged(string message)
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
                if (columnName == "FullName" && this.FullName.Length < 3)
                {
                    return "Name length have to be more than 3 characters";
                }
                if (columnName == "NationalID" && (this.NationalID.Length < 14 || this.NationalID.Length > 14 || !(Utils.IsDigitsOnly(this.NationalID))))
                {
                    return "National ID should be 14 No.";
                }
                if (columnName == "DateOfBirth" && (this.DateOfBirth == null))
                {
                    return "No date given!";
                }
                else if (columnName == "DateOfBirth" && this.DateOfBirth.Value > DateTime.Today)
                {
                    return "Date Have to be less than today";
                }
                if (columnName == "Email" && !(this.Email.Contains("@")))
                {
                    return "InValid E-Mail";
                }
                return null;
            }
        }
        [Description("Test-Property")]
        public string Error { get { return string.Empty; } }
        #endregion


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
        private ObservableCollection<Mobile> _mobiles = null;
        public ObservableCollection<Mobile> Mobiles
        {
            get
            {
                if (_mobiles == null)
                    _mobiles = new ObservableCollection<Mobile>();
                return _mobiles;
            }
            set
            {
                if (Equals(value, _mobiles))
                {
                    return;
                }
                _mobiles = value;
                RaisePropertyChanged("Mobiles");
            }
        }
        private ObservableCollection<Clinic> _clinics = null;
        public ObservableCollection<Clinic> Clinics
        {
            get
            {
                if (_clinics == null)
                    _clinics = new ObservableCollection<Clinic>();
                return _clinics;
            }
            set
            {
                _clinics = value;
                RaisePropertyChanged("Clinics");
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
        private ObservableCollection<Service> _servedList;
        public ObservableCollection<Service> ServedList
        {
            get
            {
                if (_servedList == null)
                    _servedList = new ObservableCollection<Service>();
                return _servedList;
            }
            set
            {
                _servedList = value;
                RaisePropertyChanged("ServedList");
            }
        }
        private ObservableCollection<Service> _toJoinList;
        public ObservableCollection<Service> ToJoinList
        {
            get
            {
                if (_toJoinList == null)
                    _toJoinList = new ObservableCollection<Service>();
                return _toJoinList;
            }
            set
            {
                _toJoinList = value;
                RaisePropertyChanged("ToJoinList");
            }
        }
        private ObservableCollection<ServiceAbroadPeriod> _periods;
        public ObservableCollection<ServiceAbroadPeriod> Periods
        {
            get
            {
                if (_periods == null)
                    _periods = new ObservableCollection<ServiceAbroadPeriod>();
                return _periods;
            }
            set
            {
                _periods = value;
                RaisePropertyChanged("Periods");
            }
        }
        private ObservableCollection<Suggestion> _suggestions;
        public ObservableCollection<Suggestion> Suggestions
        {
            get
            {
                if (_suggestions == null)
                    _suggestions = new ObservableCollection<Suggestion>();
                return _suggestions;
            }
            set
            {
                _suggestions = value;
                RaisePropertyChanged("Suggestions");
            }
        }
        private Mobile _selectedPhone;
        public Mobile SelectedPhone
        {
            get
            {
                return _selectedPhone;
            }
            set
            {
                _selectedPhone = value;
                RaisePropertyChanged("SelectedPhone");
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
        private Service _selectedServedList;
        public Service SelectedServedList
        {
            get
            {
                return _selectedServedList;
            }
            set
            {
                _selectedServedList = value;
                RaisePropertyChanged("SelectedServedList");
            }
        }
        private Service _selectedServiceToAddToJoin;
        public Service SelectedServiceToAddToJoin
        {
            get
            {
                return _selectedServiceToAddToJoin;
            }
            set
            {
                _selectedServiceToAddToJoin = value;
                RaisePropertyChanged("SelectedServiceToAddToJoin");
            }
        }
        private Service _selectedToJoin;
        public Service SelectedToJoin
        {
            get
            {
                return _selectedToJoin;
            }
            set
            {
                _selectedToJoin = value;
                RaisePropertyChanged("SelectedToJoin");
            }
        }
        private ServiceAbroadPeriod _selectedPeriod;
        public ServiceAbroadPeriod SelectedPeriod
        {
            get
            {
                return _selectedPeriod;
            }
            set
            {
                _selectedPeriod = value;
                RaisePropertyChanged("SelectedPeriod");
            }
        }
        private Suggestion _selectedSuggestion;
        public Suggestion SelectedSuggestion
        {
            get
            {
                return _selectedSuggestion;
            }
            set
            {
                _selectedSuggestion = value;
                RaisePropertyChanged("SelectedSuggestion");
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

        #endregion

        #region Commands
        private ICommand addPhoneCommand;
        public ICommand AddPhoneCommand
        {
            get
            {
                return addPhoneCommand ?? (addPhoneCommand = new RelayCommand(() =>
                {
                    AddPhone phoneDialog = new AddPhone();
                    AddPhoneViewModel phoneDialogVm = new AddPhoneViewModel();
                    phoneDialogVm.CancelCommand = new RelayCommand(() =>
                    {
                        phoneDialog.Close();
                    });
                    phoneDialogVm.OKCommand = new RelayCommand(() =>
                    {
                        if (phoneDialogVm.IsValid)
                        {
                            Mobiles.Add(new Mobile() { MobileNo = phoneDialogVm.PhoneNo });
                            phoneDialog.Close();
                        }
                        else
                        {
                            phoneDialogVm.UserMessage = "Invalid Phone No";
                        }
                    });
                    phoneDialog.DataContext = phoneDialogVm;
                    phoneDialog.ShowDialog();
                }));
            }
            set
            {
                addPhoneCommand = value;
            }
        }

        private ICommand addCountryCommand;
        public ICommand AddCountryCommand
        {
            get
            {
                return addCountryCommand ?? (addCountryCommand = new RelayCommand(() =>
                {
                    AddCountry countryDialog = new AddCountry();
                    AddCountryViewModel countryDialogVm = new AddCountryViewModel();
                    countryDialogVm.CancelCommand = new RelayCommand(() =>
                    {
                        countryDialog.Close();
                    });
                    countryDialogVm.OKCommand = new RelayCommand(() =>
                    {
                        if (countryDialogVm.IsValid)
                        {
                            City ci = _data.AddCoutryWithCity(countryDialogVm.CountryName, countryDialogVm.CityName);
                            Countries = new ObservableCollection<Country>(_data.GetCountries());
                            SelectedCountry = ci.Country;
                            Cities = new ObservableCollection<City>(_data.GetCities(SelectedCountry.CountryID));
                            SelectedCity = ci;
                            countryDialog.Close();
                            Messenger.Default.Send<string>(Utils.CountryAddedMessage);
                        }
                        else
                        {
                            countryDialogVm.UserMessage = "Please Complete Info ";
                        }
                    });
                    countryDialog.DataContext = countryDialogVm;
                    countryDialog.ShowDialog();
                }));
            }
            set
            {
                addCountryCommand = value;
            }
        }

        private ICommand addCityCommand;
        public ICommand AddCityCommand
        {
            get
            {
                return addCityCommand ?? (addCityCommand = new RelayCommand(() =>
                {
                    if (SelectedCountry != null)
                    {
                        AddCity cityDialog = new AddCity();
                        AddCityViewModel cityDialogVm = new AddCityViewModel(SelectedCountry.CountryName);
                        cityDialogVm.CancelCommand = new RelayCommand(() =>
                        {
                            cityDialog.Close();
                        });
                        cityDialogVm.OKCommand = new RelayCommand(() =>
                        {
                            if (cityDialogVm.IsValid)
                            {
                                City ci = _data.AddCity(SelectedCountry.CountryID, cityDialogVm.CityName);
                                SelectedCountry = ci.Country;
                                Cities = new ObservableCollection<City>(_data.GetCities(SelectedCountry.CountryID));
                                SelectedCity = ci;
                                cityDialog.Close();
                                Messenger.Default.Send<string>(Utils.CityAddedMessage);
                            }
                            else
                            {
                                cityDialogVm.UserMessage = "Please Complete Info ";
                            }
                        });
                        cityDialog.DataContext = cityDialogVm;
                        cityDialog.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Country");
                    }
                }));
            }
            set
            {
                addCityCommand = value;
            }
        }

        private ICommand addSpecialtyCommand;
        public ICommand AddSpecialtyCommand
        {
            get
            {
                return addSpecialtyCommand ?? (addSpecialtyCommand = new RelayCommand(() =>
                {
                    AddSpecialty specialtyDialog = new AddSpecialty();
                    AddSpecialtyViewModel specialtyDialogVm = new AddSpecialtyViewModel();
                    specialtyDialogVm.CancelCommand = new RelayCommand(() =>
                    {
                        specialtyDialog.Close();
                    });
                    specialtyDialogVm.OKCommand = new RelayCommand(() =>
                    {
                        if (specialtyDialogVm.IsValid)
                        {
                            Sub_Specialty subSpec = _data.AddSpecialtyWithSubSpecialty(specialtyDialogVm.SpecialtyName, specialtyDialogVm.SubSpecialtyName);
                            Specialties = new ObservableCollection<Specialty>(_data.GetSpecialties());
                            SelectedSpecialty = subSpec.Specialty;
                            SubSpecialties = new ObservableCollection<Sub_Specialty>(_data.GetSubSpecialties(SelectedSpecialty.SpecialtyID));
                            SelectedSubSpecialty = subSpec;
                            specialtyDialog.Close();
                            Messenger.Default.Send<string>(Utils.SpecialtyAddedMessage);
                        }
                        else
                        {
                            specialtyDialogVm.UserMessage = "Please Complete Info ";
                        }
                    });
                    specialtyDialog.DataContext = specialtyDialogVm;
                    specialtyDialog.ShowDialog();
                }));
            }
            set
            {
                addSpecialtyCommand = value;
            }
        }


        private ICommand addSubSpecialtyCommand;
        public ICommand AddSubSpecialtyCommand
        {
            get
            {
                return addSubSpecialtyCommand ?? (addSubSpecialtyCommand = new RelayCommand(() =>
                {
                    if (SelectedSpecialty != null)
                    {
                        AddSubSpecialty subSpecialtyDialog = new AddSubSpecialty();
                        AddSubSpecialtyViewModel subSpecialtyDialogVm = new AddSubSpecialtyViewModel(SelectedSpecialty.SpecialtyName);
                        subSpecialtyDialogVm.CancelCommand = new RelayCommand(() =>
                        {
                            subSpecialtyDialog.Close();
                        });
                        subSpecialtyDialogVm.OKCommand = new RelayCommand(() =>
                        {
                            if (subSpecialtyDialogVm.IsValid)
                            {
                                Sub_Specialty subSpe = _data.AddSubSpecialty(SelectedSpecialty.SpecialtyID, subSpecialtyDialogVm.SubSpecialtyName);
                                SelectedSpecialty = subSpe.Specialty;
                                SubSpecialties = new ObservableCollection<Sub_Specialty>(_data.GetSubSpecialties(SelectedSpecialty.SpecialtyID));
                                SelectedSubSpecialty = subSpe;
                                subSpecialtyDialog.Close();
                                Messenger.Default.Send<string>(Utils.subSpecialtyAddedMessage);
                            }
                            else
                            {
                                subSpecialtyDialogVm.UserMessage = "Please Complete Info ";
                            }
                        });
                        subSpecialtyDialog.DataContext = subSpecialtyDialogVm;
                        subSpecialtyDialog.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Specialty");
                    }
                }));
            }
            set
            {
                addSubSpecialtyCommand = value;
            }
        }

        private ICommand addNewLanguageCommand;
        public ICommand AddNewLanguageCommand
        {
            get
            {
                return addNewLanguageCommand ?? (addNewLanguageCommand = new RelayCommand(() =>
                {
                    AddLanguage addLanguage = new AddLanguage();
                    AddLanguageViewModel addLanguageDialogVm = new AddLanguageViewModel();
                    addLanguageDialogVm.CancelCommand = new RelayCommand(() =>
                    {
                        addLanguage.Close();
                    });
                    addLanguageDialogVm.OKCommand = new RelayCommand(() =>
                    {
                        if (addLanguageDialogVm.IsValid)
                        {
                            Language addedLang = _data.AddLanguage(addLanguageDialogVm.LanguageName);
                            if (addLanguage != null)
                            {
                                Languages = new ObservableCollection<Language>(_data.GetLanguages());
                                SelectedLanguage = addedLang;
                            }
                            addLanguage.Close();
                            Messenger.Default.Send<string>(Utils.LanguageAddedMessage);
                        }
                        else
                        {
                            addLanguageDialogVm.UserMessage = "Invalid Language ";
                        }
                    });
                    addLanguage.DataContext = addLanguageDialogVm;
                    addLanguage.ShowDialog();
                }));
            }
            set
            {
                addNewLanguageCommand = value;
            }
        }

        private ICommand addLanguageAsSpokenCommand;
        public ICommand AddLanguageAsSpokenCommand
        {
            get
            {
                return addLanguageAsSpokenCommand ?? (addLanguageAsSpokenCommand = new RelayCommand(() =>
                {
                    if (SpokenLanguages.Where(s => s.LanguagID == SelectedLanguage.LanguagID).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Language Already Added");
                        return;
                    }
                    SpokenLanguages.Add(SelectedLanguage);
                }));
            }
            set
            {
                addLanguageAsSpokenCommand = value;
            }
        }

        private ICommand addClincCommand;
        public ICommand AddClincCommand
        {
            get
            {
                return addClincCommand ?? (addClincCommand = new RelayCommand(() =>
                {
                    AddClinic clinicDialog = new AddClinic();
                    AddClinicViewModel clinicDialogVm = new AddClinicViewModel();
                    clinicDialogVm.CancelCommand = new RelayCommand(() =>
                    {
                        clinicDialog.Close();
                    });
                    clinicDialogVm.AddCommand = new RelayCommand(() =>
                    {
                        if (clinicDialogVm.IsValid)
                        {
                            Clinics.Add(new Clinic() { Landline = clinicDialogVm.Landline, Address = new Address() { BuildingNo = clinicDialogVm.BuildingNo, StreetName = clinicDialogVm.StreetNo, District = clinicDialogVm.District } });
                            clinicDialog.Close();
                        }
                        else
                        {
                            clinicDialogVm.UserMessage = "Invalid Clinic Details ";
                        }
                    });
                    clinicDialog.DataContext = clinicDialogVm;
                    clinicDialog.ShowDialog();
                }));
            }
            set
            {
                addClincCommand = value;
            }
        }

        private ICommand editClincCommand;
        public ICommand EditClincCommand
        {
            get
            {
                return editClincCommand ?? (editClincCommand = new RelayCommand(() =>
                {
                    if (SelectedClinic != null)
                    {
                        EditClinic clinicDialog = new EditClinic();
                        EditClinicViewModel clinicDialogVm = new EditClinicViewModel(SelectedClinic);
                        clinicDialogVm.CancelCommand = new RelayCommand(() =>
                        {
                            clinicDialog.Close();
                        });
                        clinicDialogVm.RemoveCommand = new RelayCommand(() =>
                        {
                            Clinics.Remove(SelectedClinic);
                            clinicDialog.Close();
                        });
                        clinicDialogVm.AddCommand = new RelayCommand(() =>
                        {
                            if (clinicDialogVm.IsValid)
                            {
                                SelectedClinic.Landline = clinicDialogVm.Landline;
                                SelectedClinic.Address.BuildingNo = clinicDialogVm.BuildingNo;
                                SelectedClinic.Address.StreetName = clinicDialogVm.StreetNo;
                                SelectedClinic.Address.District = clinicDialogVm.District;
                                clinicDialog.Close();
                            }
                            else
                            {
                                clinicDialogVm.UserMessage = "Invalid Clinic Details ";
                            }
                        });
                        clinicDialog.DataContext = clinicDialogVm;
                        clinicDialog.ShowDialog();
                    }
                }));
            }
            set
            {
                editClincCommand = value;
            }
        }

        private ICommand addNewServiceCommand;
        public ICommand AddNewServiceCommand
        {
            get
            {
                return addNewServiceCommand ?? (addNewServiceCommand = new RelayCommand(() =>
                {
                    AddService addService = new AddService();
                    AddServiceViewModel addServiceDialogVm = new AddServiceViewModel();
                    addServiceDialogVm.CancelCommand = new RelayCommand(() =>
                    {
                        addService.Close();
                    });
                    addServiceDialogVm.OKCommand = new RelayCommand(() =>
                    {
                        if (addServiceDialogVm.IsValid)
                        {
                            Service addedserv = _data.AddService(addServiceDialogVm.ServiceName);
                            if (addedserv != null)
                            {
                                Services = new ObservableCollection<Service>(_data.GetServices());
                                // SelectedService = addedserv;
                            }
                            addService.Close();
                            Messenger.Default.Send<string>(Utils.ServiceAddedMessage);
                        }
                        else
                        {
                            addServiceDialogVm.UserMessage = "Invalid Service ";
                        }
                    });
                    addService.DataContext = addServiceDialogVm;
                    addService.ShowDialog();
                }));
            }
            set
            {
                addNewServiceCommand = value;
            }
        }

        private ICommand addServiceAsServedCommand;
        public ICommand AddServiceAsServedCommand
        {
            get
            {
                return addServiceAsServedCommand ?? (addServiceAsServedCommand = new RelayCommand(() =>
                {
                    try
                    {
                        if (ServedList.Where(s => s.ServiceID == SelectedService.ServiceID).FirstOrDefault() != null)
                        {
                            MessageBox.Show("Service Already Added");
                            return;
                        }
                        ServedList.Add(SelectedService);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }));
            }
            set
            {
                addServiceAsServedCommand = value;
            }
        }

        private ICommand removeFromServedList;
        public ICommand RemoveFromServedList
        {
            get
            {
                return removeFromServedList ?? (removeFromServedList = new RelayCommand(() =>
                {
                    ServedList.Remove(SelectedService);
                }));
            }
            set
            {
                removeFromServedList = value;
            }
        }

        private ICommand removeSpokenLanguageCommand;
        public ICommand RemoveSpokenLanguageCommand
        {
            get
            {
                return removeSpokenLanguageCommand ?? (removeSpokenLanguageCommand = new RelayCommand(() =>
                {
                    SpokenLanguages.Remove(SelectedLanguage);
                }));
            }
            set
            {
                removeSpokenLanguageCommand = value;
            }
        }

        private ICommand addServiceAsToJoinCommand;
        public ICommand AddServiceAsToJoinCommand
        {
            get
            {
                return addServiceAsToJoinCommand ?? (addServiceAsToJoinCommand = new RelayCommand(() =>
                {
                    if (ToJoinList.Where(s => s.ServiceID == SelectedServiceToAddToJoin.ServiceID).FirstOrDefault() != null)
                    {
                        MessageBox.Show("Service Already Added");
                        return;
                    }
                    ToJoinList.Add(SelectedServiceToAddToJoin);
                }));
            }
            set
            {
                addServiceAsToJoinCommand = value;
            }
        }

        private ICommand removeFromToJoinList;
        public ICommand RemoveFromToJoinList
        {
            get
            {
                return removeFromToJoinList ?? (removeFromToJoinList = new RelayCommand(() =>
                {
                    ToJoinList.Remove(SelectedToJoin);
                }));
            }
            set
            {
                removeFromToJoinList = value;
            }
        }

        private ICommand removePhoneCommand;
        public ICommand RemovePhoneCommand
        {
            get
            {
                return removePhoneCommand ?? (removePhoneCommand = new RelayCommand(() =>
                {
                    Mobiles.Remove(SelectedPhone);
                }));
            }
            set
            {
                removePhoneCommand = value;
            }
        }

        private ICommand addPeriodCommand;
        public ICommand AddPeriodCommand
        {
            get
            {
                return addPeriodCommand ?? (addPeriodCommand = new RelayCommand(() =>
                {
                    AddPeriod addPeriod = new AddPeriod();
                    AddPeriodViewModel addPeriodViewModelDialogVm = new AddPeriodViewModel();
                    addPeriodViewModelDialogVm.CancelCommand = new RelayCommand(() =>
                    {
                        addPeriod.Close();
                    });
                    addPeriodViewModelDialogVm.AddCommand = new RelayCommand(() =>
                    {
                        if (addPeriodViewModelDialogVm.IsValid)
                        {
                            Periods.Add(new ServiceAbroadPeriod(new Period() { From = addPeriodViewModelDialogVm.FromDate, To = addPeriodViewModelDialogVm.ToDate }));
                            addPeriod.Close();
                        }
                        else
                        {
                            addPeriodViewModelDialogVm.UserMessage = "Invalid Period ";
                        }
                    });
                    addPeriod.DataContext = addPeriodViewModelDialogVm;
                    addPeriod.ShowDialog();
                }));
            }
            set
            {
                addPeriodCommand = value;
            }
        }

        private ICommand removePeriodCommand;
        public ICommand RemovePeriodCommand
        {
            get
            {
                return removePeriodCommand ?? (removePeriodCommand = new RelayCommand(() =>
                {
                    Periods.Remove(SelectedPeriod);
                }));
            }
            set
            {
                removePeriodCommand = value;
            }
        }

        private ICommand addDoctorCommand;
        public ICommand AddDoctorCommand
        {
            get
            {
                return addDoctorCommand ?? (addDoctorCommand = new RelayCommand(() =>
                {
                    _data.AddDoctor(FullName, NationalID, DateOfBirth, Mobiles, Email, SelectedCountry, SelectedCity, Diocese, SelectedSpecialty, SelectedSubSpecialty, CurrentOccupation, SpokenLanguages, CurrentAffiliation, Clinics, ServedList, ToJoinList, Periods, Suggestions);
                    Messenger.Default.Send<string>(Utils.DoctorAddedMessage);
                }));
            }

            set
            {
                addDoctorCommand = value;
            }
        }

        private ICommand addSuggestionCommand;
        public ICommand AddSuggestionCommand
        {
            get
            {
                return addSuggestionCommand ?? (addSuggestionCommand = new RelayCommand(() =>
                {
                    AddSuggestion addSuggestion = new AddSuggestion();
                    AddSuggestionViewModel addSuggestionVm = new AddSuggestionViewModel();
                    addSuggestionVm.CancelCommand = new RelayCommand(() =>
                    {
                        addSuggestion.Close();
                    });
                    addSuggestionVm.OKCommand = new RelayCommand(() =>
                    {
                        if (addSuggestionVm.IsValid)
                        {
                            Suggestions.Add(new Suggestion() { ServiceID = addSuggestionVm.SelectedService.ServiceID, Suggestion1 = addSuggestionVm.Suggestion });
                            addSuggestion.Close();
                        }
                        else
                        {
                            addSuggestionVm.UserMessage = "Please Complete Info ";
                        }
                    });
                    addSuggestion.DataContext = addSuggestionVm;
                    addSuggestion.ShowDialog();
                }));
            }
            set
            {
                addSuggestionCommand = value;
            }
        }

        private ICommand removeSuggestionCommand;
        public ICommand RemoveSuggestionCommand
        {
            get
            {
                return removeSuggestionCommand ?? (removeSuggestionCommand = new RelayCommand(() =>
                {
                    Suggestions.Remove(SelectedSuggestion);
                }));
            }
            set
            {
                removeSuggestionCommand = value;
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
                        NationalID = ""; DateOfBirth = null;
                        Mobiles.Clear();
                        Email = "";
                        SelectedCountry = null;
                        SelectedCity = null;
                        Diocese = "";
                        SelectedSpecialty = null;
                        SelectedSubSpecialty = null;
                        CurrentOccupation = "";
                        SpokenLanguages = null;
                        CurrentAffiliation = "";
                        Clinics.Clear();
                        ServedList.Clear();
                        ToJoinList.Clear();
                        Periods.Clear();
                        Suggestions.Clear();
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