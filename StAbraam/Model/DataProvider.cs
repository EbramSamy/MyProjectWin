using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.SqlServerCe;
using System.Linq;
using System.Windows;
using StAbraam.Classes;
using System.Data.Entity.Validation;

namespace StAbraam.Model
{
    public class DataProvider
    {
        private StAbraamEntities _service = new StAbraamEntities();


        public void addDoctor(string fullName, DateTime dateOfBirth, string email, string diocese, Specialty specialty, Sub_Specialty sub_Speciality, string currentOccupation, string currentHospital)
        {
            Doctor doctor = new Doctor()
            {
                FullName = fullName,
                DateOfBirth = dateOfBirth,
                Email = email,
                Diocese = diocese,
                //Speciality = specialty.SpecialtyID,
                //Sub_Speciality = sub_Speciality.Sub_SpecialtyID,
                CurrentOccupation = currentOccupation,
                CurrentHospital = currentHospital,
                //Doctor_Cities=


            };
            try
            {
                _service.Doctors.Add(doctor);
                _service.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                System.Data.SqlServerCe.SqlCeException sqlException = (SqlCeException)updateException.InnerException;
                foreach (SqlCeError error in sqlException.Errors)
                {
                    MessageBox.Show(error.Message);
                }
                _service.Doctors.Remove(doctor);
                return;
            }
            MessageBox.Show("Doctor Added");
        }

        internal List<Doctor> GetDoctors()
        {
            return _service.Doctors.ToList();
        }

        public List<Country> GetCountries()
        {
            return _service.Countries.ToList();
        }

        public List<City> GetCities()
        {
            return _service.Cities.ToList();
        }

        public List<Service> GetServices()
        {
            return _service.Services.ToList();
        }

        public List<City> GetCities(int countryId)
        {
            return _service.Cities.Where(c => c.CountryID == countryId).ToList();
        }

        public City AddCoutryWithCity(string countryName, string cityName)
        {
            Country co = new Country() { CountryName = countryName };
            try
            {
                co = _service.Countries.Add(co);
                _service.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                System.Data.SqlServerCe.SqlCeException sqlException = (SqlCeException)updateException.InnerException;

                foreach (SqlCeError error in sqlException.Errors)
                {
                    MessageBox.Show(error.Message);
                }
                _service.Countries.Remove(co);
                MessageBox.Show("لم تضاف الدوله");
                return null;
            }
            MessageBox.Show("تم اضافة الدوله");


            City ci = new City() { CityName = cityName, CountryID = co.CountryID };
            try
            {
                _service.Cities.Add(ci);
                _service.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                System.Data.SqlServerCe.SqlCeException sqlException = (SqlCeException)updateException.InnerException;

                foreach (SqlCeError error in sqlException.Errors)
                {
                    MessageBox.Show(error.Message);
                }
                _service.Cities.Remove(ci);
                MessageBox.Show("لم تضاف المدينه");
                return null;
            }
            MessageBox.Show("تم اضافةالمدينه");
            return ci;
        }

        internal City AddCity(int countryID, string cityName)
        {
            City ci = new City() { CityName = cityName, CountryID = countryID };
            try
            {
                _service.Cities.Add(ci);
                _service.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                System.Data.SqlServerCe.SqlCeException sqlException = (SqlCeException)updateException.InnerException;

                foreach (SqlCeError error in sqlException.Errors)
                {
                    MessageBox.Show(error.Message);
                }
                _service.Cities.Remove(ci);
                MessageBox.Show("لم تضاف المدينه");
                return null;
            }
            MessageBox.Show("تم اضافةالمدينه");
            return ci;
        }

        internal List<Specialty> GetSpecialties()
        {
            return _service.Specialties.ToList(); ;
        }

        internal List<Sub_Specialty> GetSubSpecialties(int specialtyID)
        {
            return _service.Sub_Specialty.Where(s => s.SpecialtyID == specialtyID).ToList();
        }

        internal Sub_Specialty AddSpecialtyWithSubSpecialty(string specialtyName, string subSpecialtyName)
        {
            Specialty sp = new Specialty() { SpecialtyName = specialtyName };
            try
            {
                sp = _service.Specialties.Add(sp);
                _service.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                System.Data.SqlServerCe.SqlCeException sqlException = (SqlCeException)updateException.InnerException;

                foreach (SqlCeError error in sqlException.Errors)
                {
                    MessageBox.Show(error.Message);
                }
                _service.Specialties.Remove(sp);
                MessageBox.Show("لم يضاف التخصص");
                return null;
            }
            MessageBox.Show("تم اضافة التخصص");


            Sub_Specialty subSp = new Sub_Specialty() { Sub_SpecialtyName = subSpecialtyName, SpecialtyID = sp.SpecialtyID };
            try
            {
                _service.Sub_Specialty.Add(subSp);
                _service.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                System.Data.SqlServerCe.SqlCeException sqlException = (SqlCeException)updateException.InnerException;

                foreach (SqlCeError error in sqlException.Errors)
                {
                    MessageBox.Show(error.Message);
                }
                _service.Sub_Specialty.Remove(subSp);
                MessageBox.Show("لم يضاف تخصص فرعي");
                return null;
            }
            MessageBox.Show("تم اضافة تخصص فرعي");
            return subSp;
        }

        internal Sub_Specialty AddSubSpecialty(int specialtyID, string subSpecialtyName)
        {
            Sub_Specialty subSp = new Sub_Specialty() { Sub_SpecialtyName = subSpecialtyName, SpecialtyID = specialtyID };
            try
            {
                _service.Sub_Specialty.Add(subSp);
                _service.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                System.Data.SqlServerCe.SqlCeException sqlException = (SqlCeException)updateException.InnerException;

                foreach (SqlCeError error in sqlException.Errors)
                {
                    MessageBox.Show(error.Message);
                }
                _service.Sub_Specialty.Remove(subSp);
                MessageBox.Show("لم يضاف تخصص فرعي");
                return null;
            }
            MessageBox.Show("تم اضافة تخصص فرعي");
            return subSp;
        }

        internal List<Language> GetLanguages()
        {
            return _service.Languages.ToList();
        }

        internal Language AddLanguage(string languageName)
        {
            Language la = new Language() { LanguageName = languageName };
            try
            {
                la = _service.Languages.Add(la);
                _service.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                System.Data.SqlServerCe.SqlCeException sqlException = (SqlCeException)updateException.InnerException;

                foreach (SqlCeError error in sqlException.Errors)
                {
                    MessageBox.Show(error.Message);
                }
                _service.Languages.Remove(la);
                MessageBox.Show("لم تضاف اللغه");
                return null;
            }
            MessageBox.Show("تم اضافة لغة");
            return la;
        }

        internal Service AddService(string serviceName)
        {
            Service se = new Service() { ServiceName = serviceName };
            try
            {
                se = _service.Services.Add(se);
                _service.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                System.Data.SqlServerCe.SqlCeException sqlException = (SqlCeException)updateException.InnerException;

                foreach (SqlCeError error in sqlException.Errors)
                {
                    MessageBox.Show(error.Message);
                }
                _service.Services.Remove(se);
                MessageBox.Show("لم تضاف الخدمه ");
                return null;
            }
            MessageBox.Show("تم اضافة الخدمة");
            return se;
        }

        internal void AddDoctor(string fullName, string nationalID, DateTime? dateOfBirth, ObservableCollection<Mobile> mobiles, string email, Country selectedCountry, City selectedCity, string diocese, Specialty selectedSpecialty, Sub_Specialty selectedSubSpecialty, string currentOccupation, ObservableCollection<Language> spokenLanguages, string currentAffiliation, ObservableCollection<Clinic> clinics, ObservableCollection<Service> servedList, ObservableCollection<Service> toJoinList, ObservableCollection<ServiceAbroadPeriod> periods, ObservableCollection<Suggestion> suggestions)
        {
            //int spId = -1;
            //int subId = -1;
            //if (selectedSpecialty != null)
            //    spId = selectedSpecialty.SpecialtyID;
            //if (selectedSpecialty != null)
            //    subId = selectedSubSpecialty.SpecialtyID;
            Doctor doctor = new Doctor()
            {
                FullName = fullName,
                NationalID = nationalID,
                DateOfBirth = dateOfBirth,
                Mobiles = mobiles,
                Email = email,
                //Doctor_Countries =countries,
                //Doctor_Cities=cities,
                Diocese = diocese,
                //Speciality = spId,
                //Sub_Speciality = subId,
                CurrentOccupation = currentOccupation,
                //Doctor_Languages=spokenLanguages,

                CurrentHospital = currentAffiliation,
                RegistrationDate = DateTime.Today
                //Doctor_PreferedPeriod=periods
                //Doctor_Cities=


            };
            try
            {
                doctor = _service.Doctors.Add(doctor);
                _service.SaveChanges();
                bool result = false;
                result = AddCountryToDoctor(doctor, selectedCountry);
                if (result)
                {
                    result = AddCityToDoctor(doctor, selectedCity);
                }
                if (result)
                {
                    result = AddSpecialityToDoctor(doctor, selectedSpecialty);
                }
                if (result)
                {
                    result = AddSubSpecialityToDoctor(doctor, selectedSubSpecialty);
                }
                if (result)
                {
                    result = AddSpokenLanguagesToDoctor(doctor, spokenLanguages);
                }
                if (result)
                {
                    result = AddClinicsToDoctor(doctor, clinics);
                }
                if (result)
                {
                    result = AddServedListToDoctor(doctor, servedList);
                }
                if (result)
                {
                    result = AddToJoinListToDoctor(doctor, toJoinList);
                }
                if (result)
                {
                    result = AddPeriodsToDoctor(doctor, periods);
                }
                if (result)
                {
                    result = AddSuggestionsToDoctor(doctor, suggestions);
                }
                if (!result)
                {
                    _service.Doctors.Remove(doctor);
                    MessageBox.Show("لم تتم اضافة الطبيب");
                }
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                System.Data.SqlServerCe.SqlCeException sqlException = (SqlCeException)updateException.InnerException;
                foreach (SqlCeError error in sqlException.Errors)
                {
                    MessageBox.Show(error.Message);
                }
                _service.Doctors.Remove(doctor);
                MessageBox.Show("لم تتم اضافة الطبيب");
                return;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctors.Remove(doctor);
                MessageBox.Show("لم تتم اضافة الطبيب");
                return;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctors.Remove(doctor);
                MessageBox.Show("لم تتم اضافة الطبيب");
                return;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctors.Remove(doctor);
                MessageBox.Show("لم تتم اضافة الطبيب");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctors.Remove(doctor);
                MessageBox.Show("لم تتم اضافة الطبيب");
                return;
            }
            MessageBox.Show("تم اضافة الطبيب ");
        }
        #region Add Properties for Doctor
        public bool AddCountryToDoctor(Doctor doctor, Country selectedCountry)
        {
            List<Doctor_Countries> countries = new List<Doctor_Countries>();
            try
            {
                if (selectedCountry != null)
                {

                    countries.Add(new Doctor_Countries() { Country = selectedCountry, Doctor = doctor });
                    _service.Doctor_Countries.AddRange(countries);
                    _service.SaveChanges();
                    //doctor.Doctor_Countries = countries;

                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Countries.RemoveRange(countries);
                MessageBox.Show("لم تتم اضافة الدول");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Countries.RemoveRange(countries);
                MessageBox.Show("لم تتم اضافة الدول");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Countries.RemoveRange(countries);
                MessageBox.Show("لم تتم اضافة الدول");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Countries.RemoveRange(countries);
                MessageBox.Show("لم تتم اضافة الدول");
                return false;
            }

        }

        public bool AddCityToDoctor(Doctor doctor, City selectedCity)
        {
            List<Doctor_Cities> cities = new List<Doctor_Cities>();
            try
            {
                if (selectedCity != null)
                {

                    cities.Add(new Doctor_Cities() { City = selectedCity, Doctor = doctor });

                    _service.Doctor_Cities.AddRange(cities);
                    _service.SaveChanges();

                    // doctor.Doctor_Cities = cities;
                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Cities.RemoveRange(cities);
                MessageBox.Show("لم تتم اضافة المدينه");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Cities.RemoveRange(cities);
                MessageBox.Show("لم تتم اضافة المدينه");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Cities.RemoveRange(cities);
                MessageBox.Show("لم تتم اضافة المدينه");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Cities.RemoveRange(cities);
                MessageBox.Show("لم تتم اضافة المدينه");
                return false;
            }

        }

        internal void UpdateDoctor(Doctor doctor, string fullName, string nationalID, DateTime? dateOfBirth, ObservableCollection<Mobile> mobiles, string email, Country selectedCountry, City selectedCity, string diocese, Specialty selectedSpecialty, Sub_Specialty selectedSubSpecialty, string currentOccupation, ObservableCollection<Language> spokenLanguages, string currentAffiliation, ObservableCollection<Clinic> clinics, ObservableCollection<Service> servedList, ObservableCollection<Service> toJoinList, ObservableCollection<ServiceAbroadPeriod> periods, ObservableCollection<Suggestion> suggestions)
        {
            if (doctor != null)
            {
               // Doctor doctor = _service.Doctors.Where(d => d.Id == doc.Id).FirstOrDefault();
                if (doctor != null)
                {
                    doctor.FullName = fullName;
                    doctor.NationalID = nationalID;
                    doctor.DateOfBirth = dateOfBirth;
                    doctor.Mobiles = mobiles;
                    doctor.Email = email;
                    doctor.Diocese = diocese;
                    doctor.CurrentOccupation = currentOccupation;
                    doctor.CurrentHospital = currentAffiliation;
                    doctor.RegistrationDate = DateTime.Today;

                    try
                    {
                      //  doctor = _service.Doctors.Add(doctor);
                        _service.SaveChanges();
                        bool result = false;
                        result = UpdateCountryToDoctor(doctor, selectedCountry);
                        if (result)
                        {
                            result = UpdateCityToDoctor(doctor, selectedCity);
                        }
                        if (result)
                        {
                            result = UpdateSpecialityToDoctor(doctor, selectedSpecialty);
                        }
                        if (result)
                        {
                            result = UpdateSubSpecialityToDoctor(doctor, selectedSubSpecialty);
                        }
                        if (result)
                        {
                            result = UpdateSpokenLanguagesToDoctor(doctor, spokenLanguages);
                        }
                        if (result)
                        {
                            result = UpdateClinicsToDoctor(doctor, clinics);
                        }
                        if (result)
                        {
                            result = UpdateServedListToDoctor(doctor, servedList);
                        }
                        if (result)
                        {
                            result = UpdateToJoinListToDoctor(doctor, toJoinList);
                        }
                        if (result)
                        {
                            result = UpdatePeriodsToDoctor(doctor, periods);
                        }
                        if (result)
                        {
                            result = UpdateSuggestionsToDoctor(doctor, suggestions);
                        }
                        if (!result)
                        {
                            _service.Doctors.Remove(doctor);
                            MessageBox.Show("لم تتم تعديل الطبيب");
                        }
                    }
                    catch (DbUpdateException ex)
                    {
                        UpdateException updateException = (UpdateException)ex.InnerException;
                        System.Data.SqlServerCe.SqlCeException sqlException = (SqlCeException)updateException.InnerException;
                        foreach (SqlCeError error in sqlException.Errors)
                        {
                            MessageBox.Show(error.Message);
                        }
                        _service.Doctors.Remove(doctor);
                        MessageBox.Show("لم تتم تعديل الطبيب");
                        return;
                    }
                    catch (NotSupportedException ex)
                    {
                        MessageBox.Show(ex.Message);
                        _service.Doctors.Remove(doctor);
                        MessageBox.Show("لم تتم تعديل الطبيب");
                        return;
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(ex.Message);
                        _service.Doctors.Remove(doctor);
                        MessageBox.Show("لم تتم تعديل الطبيب");
                        return;
                    }
                    catch (DbEntityValidationException ex)
                    {
                        List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                        foreach (DbEntityValidationResult error in dbVError)
                        {
                            foreach (var e in error.ValidationErrors)
                            {
                                MessageBox.Show(e.ErrorMessage);
                            }

                        }
                        MessageBox.Show(ex.Message);
                        _service.Doctors.Remove(doctor);
                        MessageBox.Show("لم تتم نعديل الطبيب");
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        _service.Doctors.Remove(doctor);
                        MessageBox.Show("لم تتم تعديل الطبيب");
                        return;
                    }
                    MessageBox.Show("تم تعديل الطبيب ");
                }

            }


        }

        private bool UpdateSuggestionsToDoctor(Doctor doctor, ObservableCollection<Suggestion> suggestions)
        {
            List<Doctor_Suggestion> doctorSugg = doctor.Doctor_Suggestion.ToList();
            try
            {
                if (suggestions.Count != 0)
                {


                    foreach (var s in suggestions)
                    {
                        if (doctorSugg.Any(ds => ds.Suggestion.SuggestionID == s.SuggestionID))
                        {
                            var sugg = doctorSugg.Where(ds => ds.Suggestion.SuggestionID == s.SuggestionID).FirstOrDefault();
                            sugg.Suggestion.Suggestion1 = s.Suggestion1;
                            sugg.Suggestion.Service = s.Service;
                        }
                        else
                        {
                            _service.Doctor_Suggestion.Add(new Doctor_Suggestion() { Suggestion = s, Doctor = doctor });
                        }
                    }
                    //_service.Doctor_Suggestion.AddRange(doctorSugg);
                    _service.SaveChanges();
                    //doctor.Doctor_Suggestion = doctorSugg;
                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Suggestion.RemoveRange(doctorSugg);
                MessageBox.Show("لم تتم اضافة الاقتراحات");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Suggestion.RemoveRange(doctorSugg);
                MessageBox.Show("لم تتم اضافة الاقتراحات");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Suggestion.RemoveRange(doctorSugg);
                MessageBox.Show("لم تتم اضافة الاقتراحات");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Suggestion.RemoveRange(doctorSugg);
                MessageBox.Show("لم تتم اضافة الاقتراحات");
                return false;
            }
        }

        private bool UpdatePeriodsToDoctor(Doctor doctor, ObservableCollection<ServiceAbroadPeriod> periods)
        {
            List<Doctor_PreferedPeriod> dPer = doctor.Doctor_PreferedPeriod.ToList();
            try
            {
                if (periods.Count != 0)
                {


                    foreach (var p in periods)
                    {
                        if (!dPer.Any(pr => pr.PeriodID == p.Period.PeriodID))
                        {
                           // dPer.Add(new Doctor_PreferedPeriod() { Period = p.Period, Doctor = doctor });
                            _service.Doctor_PreferedPeriod.Add(new Doctor_PreferedPeriod() { Period = p.Period, Doctor = doctor });
                        }
                           
                    }

                   // _service.Doctor_PreferedPeriod.AddRange(dPer);
                    _service.SaveChanges();
                    //doctor.Doctor_PreferedPeriod = dPer;
                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_PreferedPeriod.RemoveRange(dPer);
                MessageBox.Show("لم تتم اضافة الفترات المفضله للخدمه");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_PreferedPeriod.RemoveRange(dPer);
                MessageBox.Show("لم تتم اضافة الفترات المفضله للخدمه");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_PreferedPeriod.RemoveRange(dPer);
                MessageBox.Show("لم تتم اضافة الفترات المفضله للخدمه");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_PreferedPeriod.RemoveRange(dPer);
                MessageBox.Show("لم تتم اضافة الفترات المفضله للخدمه");
                return false;
            }

        }

        private bool UpdateToJoinListToDoctor(Doctor doctor, ObservableCollection<Service> toJoinList)
        {
            List<Doctor_ToJoinServices> TjCServ = doctor.Doctor_ToJoinServices.ToList();
            try
            {
                if (toJoinList.Count != 0)
                {

                    foreach (var s in toJoinList)
                    {
                        if (!TjCServ.Any(ts => ts.ServiceID == s.ServiceID))
                        {
                            _service.Doctor_ToJoinServices.Add(new Doctor_ToJoinServices() { Service = s, Doctor = doctor });
                        }
                           
                    }
                   // _service.Doctor_ToJoinServices.AddRange(TjCServ);
                    _service.SaveChanges();
                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_ToJoinServices.RemoveRange(TjCServ);
                MessageBox.Show("لم تتم الخدمات التي يرغب الخادم في الانضمام لها");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_ToJoinServices.RemoveRange(TjCServ);
                MessageBox.Show("لم تتم الخدمات التي يرغب الخادم في الانضمام لها");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_ToJoinServices.RemoveRange(TjCServ);
                MessageBox.Show("لم تتم الخدمات التي يرغب الخادم في الانضمام لها");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_ToJoinServices.RemoveRange(TjCServ);
                MessageBox.Show("لم تتم الخدمات التي يرغب الخادم في الانضمام لها");
                return false;
            }
        }

        private bool UpdateServedListToDoctor(Doctor doctor, ObservableCollection<Service> servedList)
        {
            List<Doctor_CurrentService> dCServ = doctor.Doctor_CurrentService.ToList();
            try
            {
                if (servedList.Count != 0)
                {

                    foreach (var s in servedList)
                    {
                        if (!dCServ.Any(ds => ds.ServiceID == s.ServiceID))
                        {
                            _service.Doctor_CurrentService.Add(new Doctor_CurrentService() { Service = s, Doctor = doctor });
                        }
                           
                    }
                   // _service.Doctor_CurrentService.AddRange(dCServ);
                    _service.SaveChanges();
                    //doctor.Doctor_CurrentService = dCServ;
                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_CurrentService.RemoveRange(dCServ);
                MessageBox.Show("لم تتم اضافة الخدمات الحالية");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_CurrentService.RemoveRange(dCServ);
                MessageBox.Show("لم تتم اضافة الخدمات الحالية");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_CurrentService.RemoveRange(dCServ);
                MessageBox.Show("لم تتم اضافة الخدمات الحالية");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_CurrentService.RemoveRange(dCServ);
                MessageBox.Show("لم تتم اضافة الخدمات الحالية");
                return false;
            }
        }

        private bool UpdateClinicsToDoctor(Doctor doctor, ObservableCollection<Clinic> clinics)
        {
            List<Doctor_Clinic> dclinics = doctor.Doctor_Clinic.ToList();
            try
            {
                if (clinics.Count != 0)
                {


                    foreach (var cl in clinics)
                    {
                        if (!dclinics.Any(c => c.ClinicID == cl.ClinicID))
                        {
                            _service.Doctor_Clinic.Add(new Doctor_Clinic() { Clinic = cl, Doctor = doctor });
                        }
                        
                    }
                   // _service.Doctor_Clinic.AddRange(dclinics);
                    _service.SaveChanges();

                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Clinic.RemoveRange(dclinics);
                MessageBox.Show("لم تتم اضافة العيادات");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Clinic.RemoveRange(dclinics);
                MessageBox.Show("لم تتم اضافة العيادات");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Clinic.RemoveRange(dclinics);
                MessageBox.Show("لم تتم اضافة العيادات");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Clinic.RemoveRange(dclinics);
                MessageBox.Show("لم تتم اضافة العيادات");
                return false;
            }
        }

        private bool UpdateSpokenLanguagesToDoctor(Doctor doctor, ObservableCollection<Language> spokenLanguages)
        {
            List<Doctor_Languages> languages = doctor.Doctor_Languages.ToList();
            try
            {
                if (spokenLanguages.Count != 0)
                {


                    foreach (var lang in spokenLanguages)
                    {
                        if (!languages.Any(a => a.LanguageID == lang.LanguagID))
                        {
                            _service.Doctor_Languages.Add(new Doctor_Languages() { Language = lang, Doctor = doctor });
                        }
                           
                    }
                    //_service.Doctor_Languages.AddRange(languages);
                    _service.SaveChanges();
                    //doctor.Doctor_Languages = languages;

                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Languages.RemoveRange(languages);
                MessageBox.Show("لم تتم اضافة اللغات");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Languages.RemoveRange(languages);
                MessageBox.Show("لم تتم اضافة اللغات");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Languages.RemoveRange(languages);
                MessageBox.Show("لم تتم اضافة اللغات");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Languages.RemoveRange(languages);
                MessageBox.Show("لم تتم اضافة اللغات");
                return false;
            }
        }

        private bool UpdateSubSpecialityToDoctor(Doctor doctor, Sub_Specialty selectedSubSpecialty)
        {
            List<Doctor_Sub_Specialty> docSubSpecialities = doctor.Doctor_Sub_Specialty.ToList();
            try
            {
                if (selectedSubSpecialty != null)
                {
                    if (!docSubSpecialities.Any(d => d.Sub_SpecialtyID == selectedSubSpecialty.Sub_SpecialtyID))
                    {
                        _service.Doctor_Sub_Specialty.Remove(docSubSpecialities.FirstOrDefault());
                        _service.Doctor_Sub_Specialty.Add(new Doctor_Sub_Specialty() { Sub_Specialty = selectedSubSpecialty, Doctor = doctor });
                    }

                   // _service.Doctor_Sub_Specialty.AddRange(docSubSpecialities);
                    _service.SaveChanges();

                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Sub_Specialty.RemoveRange(docSubSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص الفرعي");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Sub_Specialty.RemoveRange(docSubSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص الفرعي");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Sub_Specialty.RemoveRange(docSubSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص الفرعي");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Sub_Specialty.RemoveRange(docSubSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص الفرعي");
                return false;
            }
        }

        private bool UpdateSpecialityToDoctor(Doctor doctor, Specialty selectedSpecialty)
        {
            List<Doctor_Specialty> docSpecialities = doctor.Doctor_Specialty.ToList();
            try
            {
                if (selectedSpecialty != null)
                {
                    if (!docSpecialities.Any(s => s.SpecialtyID == selectedSpecialty.SpecialtyID))
                    {
                        _service.Doctor_Specialty.Remove(docSpecialities.FirstOrDefault());
                        _service.Doctor_Specialty.Add(new Doctor_Specialty() { Specialty = selectedSpecialty, Doctor = doctor });
                    }

                    //_service.Doctor_Specialty.AddRange(docSpecialities);
                    _service.SaveChanges();

                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Specialty.RemoveRange(docSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Specialty.RemoveRange(docSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Specialty.RemoveRange(docSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Specialty.RemoveRange(docSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص");
                return false;
            }
        }

        private bool UpdateCityToDoctor(Doctor doctor, City selectedCity)
        {
            List<Doctor_Cities> cities = doctor.Doctor_Cities.ToList();
            try
            {
                if (selectedCity != null)
                {
                    if (!cities.Any(d => d.CityID == selectedCity.CityID))
                    {
                        _service.Doctor_Cities.Remove(cities.ToList().FirstOrDefault());
                        _service.Doctor_Cities.Add(new Doctor_Cities() { City = selectedCity, Doctor = doctor });
                    }


                   // _service.Doctor_Cities.AddRange(cities);
                    _service.SaveChanges();

                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Cities.RemoveRange(cities);
                MessageBox.Show("لم تتم اضافة المدينه");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Cities.RemoveRange(cities);
                MessageBox.Show("لم تتم اضافة المدينه");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Cities.RemoveRange(cities);
                MessageBox.Show("لم تتم اضافة المدينه");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Cities.RemoveRange(cities);
                MessageBox.Show("لم تتم اضافة المدينه");
                return false;
            }
        }

        private bool UpdateCountryToDoctor(Doctor doctor, Country selectedCountry)
        {
            List<Doctor_Countries> countries = doctor.Doctor_Countries.ToList();
            try
            {
                if (selectedCountry != null)
                {
                    if (!countries.Any(d => d.CountryID == selectedCountry.CountryID))
                    {
                        _service.Doctor_Countries.Remove(countries.ToList().FirstOrDefault());
                        _service.Doctor_Countries.Add(new Doctor_Countries() { Country = selectedCountry, Doctor = doctor });
                    }
                   // _service.Doctor_Countries.AddRange(countries);
                    _service.SaveChanges();


                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Countries.RemoveRange(countries);
                MessageBox.Show("لم تتم اضافة الدول");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Countries.RemoveRange(countries);
                MessageBox.Show("لم تتم اضافة الدول");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Countries.RemoveRange(countries);
                MessageBox.Show("لم تتم اضافة الدول");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Countries.RemoveRange(countries);
                MessageBox.Show("لم تتم اضافة الدول");
                return false;
            }
        }

        public bool AddSpecialityToDoctor(Doctor doctor, Specialty selectedSpecialty)
        {
            List<Doctor_Specialty> docSpecialities = new List<Doctor_Specialty>();
            try
            {
                if (selectedSpecialty != null)
                {

                    docSpecialities.Add(new Doctor_Specialty() { Specialty = selectedSpecialty, Doctor = doctor });
                    _service.Doctor_Specialty.AddRange(docSpecialities);
                    _service.SaveChanges();

                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Specialty.RemoveRange(docSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Specialty.RemoveRange(docSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Specialty.RemoveRange(docSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Specialty.RemoveRange(docSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص");
                return false;
            }

        }

        public bool AddSubSpecialityToDoctor(Doctor doctor, Sub_Specialty selectedSubSpecialty)
        {
            List<Doctor_Sub_Specialty> docSubSpecialities = new List<Doctor_Sub_Specialty>();
            try
            {
                if (selectedSubSpecialty != null)
                {

                    docSubSpecialities.Add(new Doctor_Sub_Specialty() { Sub_Specialty = selectedSubSpecialty, Doctor = doctor });
                    _service.Doctor_Sub_Specialty.AddRange(docSubSpecialities);
                    _service.SaveChanges();

                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Sub_Specialty.RemoveRange(docSubSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص الفرعي");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Sub_Specialty.RemoveRange(docSubSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص الفرعي");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Sub_Specialty.RemoveRange(docSubSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص الفرعي");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Sub_Specialty.RemoveRange(docSubSpecialities);
                MessageBox.Show("لم تتم اضافة التخصص الفرعي");
                return false;
            }

        }

        public bool AddSpokenLanguagesToDoctor(Doctor doctor, ObservableCollection<Language> spokenLanguages)
        {
            List<Doctor_Languages> languages = new List<Doctor_Languages>();
            try
            {
                if (spokenLanguages.Count != 0)
                {


                    foreach (var lang in spokenLanguages)
                    {
                        languages.Add(new Doctor_Languages() { Language = lang, Doctor = doctor });
                    }
                    _service.Doctor_Languages.AddRange(languages);
                    _service.SaveChanges();
                    //doctor.Doctor_Languages = languages;

                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Languages.RemoveRange(languages);
                MessageBox.Show("لم تتم اضافة اللغات");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Languages.RemoveRange(languages);
                MessageBox.Show("لم تتم اضافة اللغات");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Languages.RemoveRange(languages);
                MessageBox.Show("لم تتم اضافة اللغات");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Languages.RemoveRange(languages);
                MessageBox.Show("لم تتم اضافة اللغات");
                return false;
            }

        }


        public bool AddClinicsToDoctor(Doctor doctor, ObservableCollection<Clinic> clinics)
        {
            List<Doctor_Clinic> dclinics = new List<Doctor_Clinic>();
            try
            {
                if (clinics.Count != 0)
                {


                    foreach (var cl in clinics)
                    {
                        dclinics.Add(new Doctor_Clinic() { Clinic = cl, Doctor = doctor });
                    }
                    _service.Doctor_Clinic.AddRange(dclinics);
                    _service.SaveChanges();
                    // doctor.Doctor_Clinic = dclinics;
                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Clinic.RemoveRange(dclinics);
                MessageBox.Show("لم تتم اضافة العيادات");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Clinic.RemoveRange(dclinics);
                MessageBox.Show("لم تتم اضافة العيادات");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Clinic.RemoveRange(dclinics);
                MessageBox.Show("لم تتم اضافة العيادات");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Clinic.RemoveRange(dclinics);
                MessageBox.Show("لم تتم اضافة العيادات");
                return false;
            }

        }


        public bool AddServedListToDoctor(Doctor doctor, ObservableCollection<Service> servedList)
        {
            List<Doctor_CurrentService> dCServ = new List<Doctor_CurrentService>();
            try
            {
                if (servedList.Count != 0)
                {

                    foreach (var s in servedList)
                    {
                        dCServ.Add(new Doctor_CurrentService() { Service = s, Doctor = doctor });
                    }
                    _service.Doctor_CurrentService.AddRange(dCServ);
                    _service.SaveChanges();
                    //doctor.Doctor_CurrentService = dCServ;
                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_CurrentService.RemoveRange(dCServ);
                MessageBox.Show("لم تتم اضافة الخدمات الحالية");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_CurrentService.RemoveRange(dCServ);
                MessageBox.Show("لم تتم اضافة الخدمات الحالية");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_CurrentService.RemoveRange(dCServ);
                MessageBox.Show("لم تتم اضافة الخدمات الحالية");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_CurrentService.RemoveRange(dCServ);
                MessageBox.Show("لم تتم اضافة الخدمات الحالية");
                return false;
            }

        }


        public bool AddToJoinListToDoctor(Doctor doctor, ObservableCollection<Service> toJoinList)
        {
            List<Doctor_ToJoinServices> TjCServ = new List<Doctor_ToJoinServices>();
            try
            {
                if (toJoinList.Count != 0)
                {

                    foreach (var s in toJoinList)
                    {
                        TjCServ.Add(new Doctor_ToJoinServices() { Service = s, Doctor = doctor });
                    }
                    _service.Doctor_ToJoinServices.AddRange(TjCServ);
                    _service.SaveChanges();
                    //doctor.Doctor_ToJoinServices = TjCServ;
                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_ToJoinServices.RemoveRange(TjCServ);
                MessageBox.Show("لم تتم الخدمات التي يرغب الخادم في الانضمام لها");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_ToJoinServices.RemoveRange(TjCServ);
                MessageBox.Show("لم تتم الخدمات التي يرغب الخادم في الانضمام لها");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_ToJoinServices.RemoveRange(TjCServ);
                MessageBox.Show("لم تتم الخدمات التي يرغب الخادم في الانضمام لها");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_ToJoinServices.RemoveRange(TjCServ);
                MessageBox.Show("لم تتم الخدمات التي يرغب الخادم في الانضمام لها");
                return false;
            }

        }


        public bool AddPeriodsToDoctor(Doctor doctor, ObservableCollection<ServiceAbroadPeriod> periods)
        {
            List<Doctor_PreferedPeriod> dPer = new List<Doctor_PreferedPeriod>();
            try
            {
                if (periods.Count != 0)
                {


                    foreach (var p in periods)
                    {
                        dPer.Add(new Doctor_PreferedPeriod() { Period = p.Period, Doctor = doctor });
                    }

                    _service.Doctor_PreferedPeriod.AddRange(dPer);
                    _service.SaveChanges();
                    //doctor.Doctor_PreferedPeriod = dPer;
                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_PreferedPeriod.RemoveRange(dPer);
                MessageBox.Show("لم تتم اضافة الفترات المفضله للخدمه");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_PreferedPeriod.RemoveRange(dPer);
                MessageBox.Show("لم تتم اضافة الفترات المفضله للخدمه");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_PreferedPeriod.RemoveRange(dPer);
                MessageBox.Show("لم تتم اضافة الفترات المفضله للخدمه");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_PreferedPeriod.RemoveRange(dPer);
                MessageBox.Show("لم تتم اضافة الفترات المفضله للخدمه");
                return false;
            }

        }

        public bool AddSuggestionsToDoctor(Doctor doctor, ObservableCollection<Suggestion> suggestions)
        {
            List<Doctor_Suggestion> doctorSugg = new List<Doctor_Suggestion>();
            try
            {
                if (suggestions.Count != 0)
                {


                    foreach (var s in suggestions)
                    {
                        doctorSugg.Add(new Doctor_Suggestion() { Suggestion = s, Doctor = doctor });
                    }
                    _service.Doctor_Suggestion.AddRange(doctorSugg);
                    _service.SaveChanges();
                    //doctor.Doctor_Suggestion = doctorSugg;
                }
                return true;
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Suggestion.RemoveRange(doctorSugg);
                MessageBox.Show("لم تتم اضافة الاقتراحات");
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Suggestion.RemoveRange(doctorSugg);
                MessageBox.Show("لم تتم اضافة الاقتراحات");
                return false;
            }
            catch (DbEntityValidationException ex)
            {
                List<DbEntityValidationResult> dbVError = ((System.Data.Entity.Validation.DbEntityValidationException)ex).EntityValidationErrors.ToList();
                foreach (DbEntityValidationResult error in dbVError)
                {
                    foreach (var e in error.ValidationErrors)
                    {
                        MessageBox.Show(e.ErrorMessage);
                    }

                }
                MessageBox.Show(ex.Message);
                _service.Doctor_Suggestion.RemoveRange(doctorSugg);
                MessageBox.Show("لم تتم اضافة الاقتراحات");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _service.Doctor_Suggestion.RemoveRange(doctorSugg);
                MessageBox.Show("لم تتم اضافة الاقتراحات");
                return false;
            }

        }

        #endregion

        #region Remove Porperties From Doctor 
        public bool RemoveCountriesToDoctor(Doctor doctor)
        {
            try
            {
                foreach (var doctor_country in doctor.Doctor_Countries)
                {
                    _service.Doctor_Countries.Remove(doctor_country);
                }

                return true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("RemoveCountriesToDoctor :" + ex.Message);
                return false;
            }
        }

        #endregion
        internal List<Doctor> SearchForDoctor(string fullName, string nationalID, DateTime? dateOfBirth = null, string phoneNo = "", string email = "", Country selectedCountry = null, City selectedCity = null, string diocese = "", Specialty selectedSpecialty = null, Sub_Specialty selectedSubSpecialty = null, string currentOccupation = "", Language selectedLanguage = null, string currentAffiliation = "", string clinicLandline = "", string clinicStreetName = "", string clinicDistrict = "", Service selectedCurrentService = null, Service selectedToJoinService = null, DateTime? from = null, DateTime? to = null, string suggestion = "", DateTime? registrationDate = null)
        {
            List<Doctor> result = _service.Doctors.ToList();

            if (!string.IsNullOrEmpty(fullName))
            {
                result = result.Where(d => d.FullName.Contains(fullName)).ToList();
            }
            if (!string.IsNullOrEmpty(nationalID))
            {
                result = result.Where(d => d.NationalID == nationalID).ToList();
            }
            if (dateOfBirth != null)
            {
                result = result.Where(d => d.DateOfBirth == dateOfBirth).ToList();
            }
            if (!string.IsNullOrEmpty(phoneNo))
            {
                result = result.Where(d => d.Mobiles.Where(m => m.MobileNo == phoneNo).Count() > 0).ToList();
            }
            if (!string.IsNullOrEmpty(email))
            {
                result = result.Where(d => d.Email == email).ToList();
            }
            if (selectedCountry != null)
            {
                result = result.Where(d => d.Doctor_Countries.Where(c => c.CountryID == selectedCountry.CountryID).Count() > 0).ToList();
            }
            if (selectedCity != null)
            {
                result = result.Where(d => d.Doctor_Cities.Where(c => c.CityID == selectedCity.CityID).Count() > 0).ToList();
            }
            if (!string.IsNullOrEmpty(diocese))
            {
                result = result.Where(d => d.Diocese == diocese).ToList();
            }
            if (selectedSpecialty != null)
            {
                result = result.Where(d => d.Doctor_Specialty.Where(s => s.SpecialtyID == selectedSpecialty.SpecialtyID).Count() > 0).ToList();
            }
            if (selectedSubSpecialty != null)
            {
                result = result.Where(d => d.Doctor_Sub_Specialty.Where(s => s.Sub_SpecialtyID == selectedSubSpecialty.Sub_SpecialtyID).Count() > 0).ToList();
            }
            if (!string.IsNullOrEmpty(currentOccupation))
            {
                result = result.Where(d => d.CurrentOccupation == currentOccupation).ToList();
            }
            if (selectedLanguage != null)
            {
                result = result.Where(d => d.Doctor_Languages.Where(l => l.LanguageID == selectedLanguage.LanguagID).Count() > 0).ToList();
            }
            if (!string.IsNullOrEmpty(currentAffiliation))
            {
                result = result.Where(d => d.CurrentHospital == currentAffiliation).ToList();
            }
            if (!string.IsNullOrEmpty(clinicLandline))
            {
                result = result.Where(d => d.Doctor_Clinic.Where(c => c.Clinic.Landline == clinicLandline).Count() > 0).ToList();
            }
            if (!string.IsNullOrEmpty(clinicStreetName))
            {
                result = result.Where(d => d.Doctor_Clinic.Where(c => c.Clinic.Address.StreetName == clinicStreetName).Count() > 0).ToList();
            }
            if (!string.IsNullOrEmpty(clinicDistrict))
            {
                result = result.Where(d => d.Doctor_Clinic.Where(c => c.Clinic.Address.District == clinicDistrict).Count() > 0).ToList();
            }
            if (!string.IsNullOrEmpty(suggestion))
            {
                result = result.Where(d => d.Doctor_Suggestion.Where(s => s.Suggestion.Suggestion1.Contains(suggestion)).Count() > 0).ToList();
            }
            if (registrationDate != null)
            {
                result = result.Where(d => d.RegistrationDate == registrationDate).ToList();
            }
            if (from != null && to != null)
            {
                result = result.Where(d => d.Doctor_PreferedPeriod.Where(p => (p.Period.From.Month == from.Value.Month) || (p.Period.To.Month == to.Value.Month)).Count() > 0).ToList();
            }
            return result;
        }
    }
}
