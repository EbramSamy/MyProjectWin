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
    /// Interaction logic for SubSpecialtiesView.xaml
    /// </summary>
    public partial class SubSpecialtiesView : UserControl
    {
        StAbraamEntities context = new StAbraamEntities();
        public Model.Sub_Specialty newSubSpecialty { get; set; }
        CollectionViewSource mySubSpecialtyViewSource;
        CollectionViewSource mySpecialtyViewSource;
        public SubSpecialtiesView()
        {
            InitializeComponent();
            newSubSpecialty = new Sub_Specialty();
            mySubSpecialtyViewSource = (CollectionViewSource)this.Resources["sub_SpecialtyViewSource"];
            mySpecialtyViewSource = (CollectionViewSource)this.Resources["specialtyViewSource"];
            DataContext = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            context.Sub_Specialty.Load();

            mySubSpecialtyViewSource.Source = context.Sub_Specialty.Local;
            mySpecialtyViewSource.Source = context.Specialties.ToList();
        }


        #region commands
        private void LastCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            mySubSpecialtyViewSource.View.MoveCurrentToLast();
        }
        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            mySubSpecialtyViewSource.View.MoveCurrentToPrevious();
        }
        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            mySubSpecialtyViewSource.View.MoveCurrentToNext();
        }
        private void FirstCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            mySubSpecialtyViewSource.View.MoveCurrentToFirst();
        }
        private void DeleteSub_SpecialtyCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var cur = mySubSpecialtyViewSource.View.CurrentItem as Sub_Specialty;
            if (cur != null)
            {
                var cust = (from ss in context.Sub_Specialty.ToList()
                            where ss.Sub_SpecialtyID == cur.Sub_SpecialtyID
                            select ss).FirstOrDefault();
                if (cust != null)
                {
                    foreach (var drSub_Specialty in cust.Doctor_Sub_Specialty.ToList())
                    {
                        Delete_Doctor_Sub_Speciality(drSub_Specialty);
                    }
                    context.Sub_Specialty.Remove(cust);
                }
                context.SaveChanges();
                mySubSpecialtyViewSource.View.Refresh();
                Messenger.Default.Send<string>(Utils.LanguageAddedMessage);
            }
        }
        private void UpdateCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (newSub_SpecialtyGrid.IsVisible)
            {
                newSubSpecialty = new Model.Sub_Specialty();
                Model.Sub_Specialty nSubSpecialty = mySubSpecialtyViewSource.View.CurrentItem as Model.Sub_Specialty;
                if (nSubSpecialty != null && nSubSpecialty?.Sub_SpecialtyID != null)
                {
                    newSubSpecialty.Sub_SpecialtyName = nSubSpecialty?.Sub_SpecialtyName;
                    newSubSpecialty.SpecialtyID = nSubSpecialty?.SpecialtyID ?? context.Specialties.FirstOrDefault().SpecialtyID;
                    if (!string.IsNullOrWhiteSpace(newSubSpecialty?.Sub_SpecialtyName))
                    {
                        mySubSpecialtyViewSource.View.Refresh();
                        mySubSpecialtyViewSource.View.MoveCurrentTo(newSubSpecialty);
                        context.SaveChanges();
                        Messenger.Default.Send<string>(Utils.subSpecialtyAddedMessage);
                    }
                    else
                    {
                        MessageBox.Show("Sub-Specialty Is Empty.");
                    }
                }
                else
                {
                    MessageBox.Show("Sub-Specialty or selected Specialty Is Empty.");
                }
                newSub_SpecialtyGrid.Visibility = Visibility.Collapsed;
                existingSub_SpecialtyGrid.Visibility = Visibility.Visible;
            }
        }
        private void AddCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingSub_SpecialtyGrid.Visibility = Visibility.Collapsed;
            newSub_SpecialtyGrid.Visibility = Visibility.Visible;

            mySpecialtyViewSource.Source = context.Specialties.ToList();
        }
        private void CancelCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingSub_SpecialtyGrid.Visibility = Visibility.Visible;
            newSub_SpecialtyGrid.Visibility = Visibility.Collapsed;
        }
        private void Delete_Doctor_Sub_Speciality(Doctor_Sub_Specialty dSub_Specialty)
        {
            var dS = (from ds in context.Doctor_Sub_Specialty.Local
                      where ds.Id == dSub_Specialty.Id
                      select ds).FirstOrDefault();
            context.Doctor_Sub_Specialty.Remove(dS);
            context.SaveChanges();
        }
        #endregion

    }
}
