using GalaSoft.MvvmLight.Messaging;
using StAbraam.Classes;
using StAbraam.Model;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace StAbraam.View
{
    /// <summary>
    /// Interaction logic for CitiesView.xaml
    /// </summary>
    public partial class CitiesView : UserControl
    {
        StAbraamEntities context = new StAbraamEntities();
        public Model.City newCity { get; set; }
        CollectionViewSource myCityViewSource;
        CollectionViewSource myCountriesViewSource;
        public CitiesView()
        {
            InitializeComponent();
            newCity = new City();
            myCityViewSource = (CollectionViewSource)this.Resources["cityViewSource"];
            myCountriesViewSource = (CollectionViewSource)this.Resources["countryViewSource"];
            DataContext = this;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            context.Cities.Load();
            //add_countryIDColumn.ItemsSource = context.Countries;
            myCityViewSource.Source = context.Cities.Local;
            myCountriesViewSource.Source = context.Countries.ToList();
        }


        #region commands
        private void LastCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myCityViewSource.View.MoveCurrentToLast();
        }
        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myCityViewSource.View.MoveCurrentToPrevious();
        }
        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myCityViewSource.View.MoveCurrentToNext();
        }
        private void FirstCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myCityViewSource.View.MoveCurrentToFirst();
        }
        private void DeleteCityCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var cur = myCityViewSource.View.CurrentItem as City;
            if (cur != null)
            {
                var cust = (from c in context.Cities.ToList()
                            where c.CityID == cur.CityID
                            select c).FirstOrDefault();
                if (cust != null)
                {
                    foreach (var drCities in cust.Doctor_Cities.ToList())
                    {
                        Delete_Doctor_City(drCities);
                    }
                    context.Cities.Remove(cust);
                }
                context.SaveChanges();
                myCityViewSource.View.Refresh();
                Messenger.Default.Send<string>(Utils.LanguageAddedMessage);
            }
        }
        private void UpdateCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (newCityGrid.IsVisible)
            {
                newCity = new Model.City();
                Model.City ncity = myCityViewSource.View.CurrentItem as Model.City;
                if (ncity != null&& ncity?.CountryID!=null)
                {
                    newCity.CityName = ncity?.CityName;
                    newCity.CountryID = ncity?.CountryID??context.Countries.FirstOrDefault().CountryID;
                    if (!string.IsNullOrWhiteSpace(newCity?.CityName))
                    {
                        myCityViewSource.View.Refresh();
                        myCityViewSource.View.MoveCurrentTo(newCity);
                        context.SaveChanges();
                        Messenger.Default.Send<string>(Utils.CityAddedMessage);
                    }
                    else
                    {
                        MessageBox.Show("City Is Empty.");
                    }
                }
                else
                {
                    MessageBox.Show("City or selected Country Is Empty.");
                }
                newCityGrid.Visibility = Visibility.Collapsed;
                existingCityGrid.Visibility = Visibility.Visible;
            }
        }
        private void AddCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingCityGrid.Visibility = Visibility.Collapsed;
            newCityGrid.Visibility = Visibility.Visible;
            //add_countryIDColumn.ItemsSource = context.Countries;
            myCountriesViewSource.Source = context.Countries.ToList();
        }
        private void CancelCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingCityGrid.Visibility = Visibility.Visible;
            newCityGrid.Visibility = Visibility.Collapsed;
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

       
    }
}
