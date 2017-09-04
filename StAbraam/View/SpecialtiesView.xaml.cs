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
    /// Interaction logic for SpecialtiesView.xaml
    /// </summary>
    public partial class SpecialtiesView : UserControl
    {
        StAbraamEntities context = new StAbraamEntities();
        public Specialty newSpecialty { get; set; }
        CollectionViewSource mySpecialtiesViewSource;
        public SpecialtiesView()
        {
            InitializeComponent();
            newSpecialty = new Specialty();
            mySpecialtiesViewSource = (CollectionViewSource)this.Resources["specialtyViewSource"];
            DataContext = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            context.Specialties.Load();
            context.Sub_Specialty.Load();
            mySpecialtiesViewSource.Source = context.Specialties.Local;
            mySpecialtiesViewSource.View.Refresh();
        }

        #region commands
        private void LastCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            mySpecialtiesViewSource.View.MoveCurrentToLast();
        }
        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            mySpecialtiesViewSource.View.MoveCurrentToPrevious();
        }
        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            mySpecialtiesViewSource.View.MoveCurrentToNext();
        }
        private void FirstCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            mySpecialtiesViewSource.View.MoveCurrentToFirst();
        }
        private void DeleteSpecialtyCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var cur = mySpecialtiesViewSource.View.CurrentItem as Specialty;
            if (cur != null)
            {
                var cust = (from s in context.Specialties.ToList()
                            where s.SpecialtyID == cur.SpecialtyID
                            select s).FirstOrDefault();
                if (cust != null)
                {
                    foreach (var drSpecialty in cust.Doctor_Specialty.ToList())
                    {
                        Delete_Doctor_Specialty(drSpecialty);
                    }

                    foreach (var sub_Specialty in cust.Sub_Specialty.ToList())
                    {
                        Delete_Sub_Specialty(sub_Specialty);
                    }

                    context.Specialties.Remove(cust);
                }
                context.SaveChanges();
                mySpecialtiesViewSource.View.Refresh();
                Messenger.Default.Send<string>(Utils.SpecialtyAddedMessage);
                Messenger.Default.Send<string>(Utils.subSpecialtyAddedMessage);
            }
        }
        private void UpdateCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (newSpecialtyGrid.IsVisible)
            {
                newSpecialty = new Model.Specialty();
                Model.Specialty nSpecialty = mySpecialtiesViewSource.View.CurrentItem as Model.Specialty;
                if (nSpecialty != null)
                {
                    newSpecialty.SpecialtyName = nSpecialty?.SpecialtyName;
                    if (!string.IsNullOrWhiteSpace(newSpecialty?.SpecialtyName))
                    {
                        mySpecialtiesViewSource.View.Refresh();
                        mySpecialtiesViewSource.View.MoveCurrentTo(newSpecialty);
                        context.SaveChanges();
                        Messenger.Default.Send<string>(Utils.LanguageAddedMessage);
                    }
                    else
                    {
                        MessageBox.Show("Specialty Is Empty.");
                    }
                }
                newSpecialtyGrid.Visibility = Visibility.Collapsed;
                existingSpecialtyGrid.Visibility = Visibility.Visible;
            }
        }
        private void AddCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingSpecialtyGrid.Visibility = Visibility.Collapsed;
            newSpecialtyGrid.Visibility = Visibility.Visible;
        }
        private void CancelCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingSpecialtyGrid.Visibility = Visibility.Visible;
            newSpecialtyGrid.Visibility = Visibility.Collapsed;
        }


        private void Delete_Doctor_Specialty(Doctor_Specialty dSpecislity)
        {
            var dS = (from ds in context.Doctor_Specialty.Local
                      where ds.Id == dSpecislity.Id
                      select ds).FirstOrDefault();
            context.Doctor_Specialty.Remove(dS);
            context.SaveChanges();
        }

        private void Delete_Sub_Specialty(Sub_Specialty subSpecialty)
        {
            if (subSpecialty != null)
            {
                var cust = (from ss in context.Sub_Specialty.ToList()
                            where ss.Sub_SpecialtyID == subSpecialty.Sub_SpecialtyID
                            select ss).FirstOrDefault();
                if (cust != null)
                {
                    foreach (var drSubSpecialty in cust.Doctor_Sub_Specialty.ToList())
                    {
                        Delete_Doctor_Sub_Specialty(drSubSpecialty);
                    }
                    context.Sub_Specialty.Remove(cust);
                }
                context.SaveChanges();
            }
        }

        private void Delete_Doctor_Sub_Specialty(Doctor_Sub_Specialty dSubSpecialty)
        {
            var dSS = (from dss in context.Doctor_Sub_Specialty.Local
                       where dss.Id == dSubSpecialty.Id
                       select dss).FirstOrDefault();
            context.Doctor_Sub_Specialty.Remove(dSS);
            context.SaveChanges();
        }
        #endregion

        private void btnAdd_Click(object sender, RoutedEventArgs e)
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
                    DataProvider dP = new DataProvider();
                    Sub_Specialty subSpec = dP.AddSpecialtyWithSubSpecialty(specialtyDialogVm.SpecialtyName, specialtyDialogVm.SubSpecialtyName);
                    context.Specialties.Load();
                    context.Sub_Specialty.Load();
                    mySpecialtiesViewSource.View.Refresh();
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
        }
    }
}
