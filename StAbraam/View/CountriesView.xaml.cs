using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using StAbraam.Classes;
using StAbraam.Model;
using StAbraam.View.Dialogs;
using StAbraam.ViewModel.DialogsViewModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace StAbraam.View
{
    /// <summary>
    /// Interaction logic for CountriesView.xaml
    /// </summary>
    public partial class CountriesView : UserControl
    {
        StAbraamEntities context = new StAbraamEntities();
        public Country newCountry { get; set; }
        CollectionViewSource myCountriesViewSource;
        public CountriesView()
        {
            InitializeComponent();
            newCountry = new Country();
            myCountriesViewSource = (CollectionViewSource)this.Resources["countryViewSource"];
            DataContext = this;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            context.Countries.Load();
            context.Cities.Load();
            myCountriesViewSource.Source = context.Countries.Local;
            myCountriesViewSource.View.Refresh();
        }

        #region commands
        private void LastCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myCountriesViewSource.View.MoveCurrentToLast();
        }
        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myCountriesViewSource.View.MoveCurrentToPrevious();
        }
        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myCountriesViewSource.View.MoveCurrentToNext();
        }
        private void FirstCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myCountriesViewSource.View.MoveCurrentToFirst();
        }
        private void DeleteCountryCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var cur = myCountriesViewSource.View.CurrentItem as Country;
            if (cur != null)
            {
                var cust = (from c in context.Countries.ToList()
                            where c.CountryID == cur.CountryID
                            select c).FirstOrDefault();
                if (cust != null)
                {
                    foreach (var drcountry in cust.Doctor_Countries.ToList())
                    {
                        Delete_Doctor_Country(drcountry);
                    }

                    foreach (var city in cust.Cities.ToList())
                    {
                        Delete_City(city);
                    }

                    context.Countries.Remove(cust);
                }
                context.SaveChanges();
                myCountriesViewSource.View.Refresh();
                Messenger.Default.Send<string>(Utils.CityAddedMessage);
                Messenger.Default.Send<string>(Utils.CountryAddedMessage);
            }
        }
        private void UpdateCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (newCountryGrid.IsVisible)
            {
                newCountry = new Model.Country();
                Model.Country nCountry = myCountriesViewSource.View.CurrentItem as Model.Country;
                if (nCountry != null)
                {
                    newCountry.CountryName = nCountry?.CountryName;
                    if (!string.IsNullOrWhiteSpace(newCountry?.CountryName))
                    {
                        myCountriesViewSource.View.Refresh();
                        myCountriesViewSource.View.MoveCurrentTo(newCountry);
                        context.SaveChanges();
                        Messenger.Default.Send<string>(Utils.LanguageAddedMessage);
                    }
                    else
                    {
                        MessageBox.Show("Country Is Empty.");
                    }
                }
                newCountryGrid.Visibility = Visibility.Collapsed;
                existingCountryGrid.Visibility = Visibility.Visible;
            }
        }
        private void AddCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingCountryGrid.Visibility = Visibility.Collapsed;
            newCountryGrid.Visibility = Visibility.Visible;
            //foreach (var child in newCountryGrid.Children)
            //{
            //    var tb = child as TextBox;
            //    if (tb != null)
            //    {
            //        tb.Text = "";
            //    }
            //}
        }
        private void CancelCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingCountryGrid.Visibility = Visibility.Visible;
            newCountryGrid.Visibility = Visibility.Collapsed;
        }


        private void Delete_Doctor_Country(Doctor_Countries dCountry)
        {
            var dC = (from dc in context.Doctor_Countries.Local
                      where dc.Id == dCountry.Id
                      select dc).FirstOrDefault();
            context.Doctor_Countries.Remove(dC);
            context.SaveChanges();
        }

        private void Delete_City(City city)
        {
            if (city != null)
            {
                var cust = (from c in context.Cities.ToList()
                            where c.CityID == city.CityID
                            select c).FirstOrDefault();
                if (cust != null)
                {
                    foreach (var drCity in cust.Doctor_Cities.ToList())
                    {
                        Delete_Doctor_City(drCity);
                    }
                    context.Cities.Remove(cust);
                }
                context.SaveChanges();
            }
        }

        private void Delete_Doctor_City(Doctor_Cities dCity)
        {
            var dC = (from dc in context.Doctor_Cities.Local
                      where dc.Id == dCity.Id
                      select dc).FirstOrDefault();
            context.Doctor_Cities.Remove(dC);
            context.SaveChanges();
        }
        #endregion

        private void btnAdd_Click(object sender, RoutedEventArgs e)
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
                    DataProvider dp = new DataProvider();
                    City ci = dp.AddCoutryWithCity(countryDialogVm.CountryName, countryDialogVm.CityName);
                    context.Countries.Load();
                    context.Cities.Load();
                    myCountriesViewSource.View.Refresh();
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
        }
    }
}
