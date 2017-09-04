using StAbraam.Model;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using StAbraam.Classes;

namespace StAbraam.View
{
    /// <summary>
    /// Interaction logic for Services.xaml
    /// </summary>
    public partial class ServicesView : UserControl
    {
        StAbraamEntities context = new StAbraamEntities();
        public Model.Service newService { get; set; }
        CollectionViewSource myServicesViewSource;
        public ServicesView()
        {
            InitializeComponent();
            newService = new Service();
            myServicesViewSource = (CollectionViewSource)this.Resources["serviceViewSource"];
            DataContext = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            context.Services.Load();
            myServicesViewSource.Source = context.Services.Local;

        }

        #region commands
        private void LastCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myServicesViewSource.View.MoveCurrentToLast();
        }
        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myServicesViewSource.View.MoveCurrentToPrevious();
        }
        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myServicesViewSource.View.MoveCurrentToNext();
        }
        private void FirstCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myServicesViewSource.View.MoveCurrentToFirst();
        }
        private void DeleteServiceCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var cur = myServicesViewSource.View.CurrentItem as Service;
            if (cur != null)
            {
                var cust = (from s in context.Services.ToList()
                            where s.ServiceID == cur.ServiceID
                            select s).FirstOrDefault();
                if (cust != null)
                {
                    foreach (var drService in cust.Doctor_CurrentService.ToList())
                    {
                        Delete_Doctor_CurrentService(drService);
                    }
                    foreach (var drService in cust.Doctor_ToJoinServices.ToList())
                    {
                        Delete_Doctor_ToJoinService(drService);
                    }
                    foreach (var serSuggest in cust.Suggestions.ToList())
                    {
                        Delete_Service_Suggestion(serSuggest);
                    }
                    context.Services.Remove(cust);
                }
                context.SaveChanges();
                myServicesViewSource.View.Refresh();
                Messenger.Default.Send<string>(Utils.ServiceAddedMessage);
            }
        }



        private void UpdateCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (newServiceGrid.IsVisible)
            {
                newService = new Model.Service();
                Model.Service nService = myServicesViewSource.View.CurrentItem as Model.Service;
                if (nService != null)
                {
                    newService.ServiceName = nService?.ServiceName;
                    if (!string.IsNullOrWhiteSpace(newService?.ServiceName))
                    {
                        myServicesViewSource.View.Refresh();
                        myServicesViewSource.View.MoveCurrentTo(newService);
                        context.SaveChanges();
                        Messenger.Default.Send<string>(Utils.ServiceAddedMessage);
                    }
                    else
                    {
                        MessageBox.Show("Service Is Empty.");
                    }
                }
                newServiceGrid.Visibility = Visibility.Collapsed;
                existingServiceGrid.Visibility = Visibility.Visible;
            }
        }
        private void AddCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingServiceGrid.Visibility = Visibility.Collapsed;
            newServiceGrid.Visibility = Visibility.Visible;

        }
        private void CancelCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existingServiceGrid.Visibility = Visibility.Visible;
            newServiceGrid.Visibility = Visibility.Collapsed;
        }
        private void Delete_Doctor_CurrentService(Doctor_CurrentService dCurrentService)
        {
            var dC = (from dc in context.Doctor_CurrentService.Local
                      where dc.Id == dCurrentService.Id
                      select dc).FirstOrDefault();
            context.Doctor_CurrentService.Remove(dC);
            context.SaveChanges();
        }

        private void Delete_Doctor_ToJoinService(Doctor_ToJoinServices dToJoinService)
        {
            var dC = (from dc in context.Doctor_ToJoinServices.Local
                      where dc.Id == dToJoinService.Id
                      select dc).FirstOrDefault();
            context.Doctor_ToJoinServices.Remove(dC);
            context.SaveChanges();
        }

        private void Delete_Service_Suggestion(Suggestion serSuggest)
        {
            var dC = (from dc in context.Suggestions.Local
                      where dc.SuggestionID == serSuggest.SuggestionID
                      select dc).FirstOrDefault();
            if (dC != null)
            {
                foreach (var drSuggestions in dC.Doctor_Suggestion.ToList())
                {
                    Delete_Doctor_Suggestion(drSuggestions);
                }
                context.Suggestions.Remove(dC);
                context.SaveChanges();
            }

        }
        private void Delete_Doctor_Suggestion(Doctor_Suggestion drSuggestions)
        {
            var dC = (from dc in context.Doctor_Suggestion.Local
                      where dc.Id == drSuggestions.Id
                      select dc).FirstOrDefault();
            context.Doctor_Suggestion.Remove(dC);
            context.SaveChanges();
        }
        #endregion
    }
}
