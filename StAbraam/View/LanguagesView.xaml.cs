using StAbraam.Model;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.Entity;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using StAbraam.Classes;
namespace StAbraam.View
{
    /// <summary>
    /// Interaction logic for LanguagesView.xaml
    /// </summary>
    public partial class LanguagesView : UserControl
    {
        StAbraamEntities context = new StAbraamEntities();
        public Model.Language newLanguage { get; set; }
        CollectionViewSource myLangauagesViewSource;
        public LanguagesView()
        {
            InitializeComponent();
            newLanguage = new Language();
            myLangauagesViewSource = (CollectionViewSource)this.Resources["languageViewSource"];
            DataContext = this;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            context.Languages.Load();
            myLangauagesViewSource.Source = context.Languages.Local;
        }
        #region commands
        private void LastCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myLangauagesViewSource.View.MoveCurrentToLast();
        }
        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myLangauagesViewSource.View.MoveCurrentToPrevious();
        }
        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myLangauagesViewSource.View.MoveCurrentToNext();
        }
        private void FirstCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            myLangauagesViewSource.View.MoveCurrentToFirst();
        }
        private void DeleteLanguageCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var cur = myLangauagesViewSource.View.CurrentItem as Language;
            if (cur != null)
            {
                var cust = (from l in context.Languages.ToList()
                            where l.LanguagID == cur.LanguagID
                            select l).FirstOrDefault();
                if (cust != null)
                {
                    foreach (var drLanguages in cust.Doctor_Languages.ToList())
                    {
                        Delete_Doctor_Language(drLanguages);
                    }
                    context.Languages.Remove(cust);
                }
                context.SaveChanges();
                myLangauagesViewSource.View.Refresh();
                Messenger.Default.Send<string>(Utils.LanguageAddedMessage);
            }
        }
        private void UpdateCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (newLanguageGrid.IsVisible)
            {
                newLanguage = new Model.Language();
                Model.Language nlanguage = myLangauagesViewSource.View.CurrentItem as Model.Language;
                if (nlanguage != null)
                {
                    newLanguage.LanguageName = nlanguage?.LanguageName;
                    if (!string.IsNullOrWhiteSpace(newLanguage?.LanguageName))
                    {
                        myLangauagesViewSource.View.Refresh();
                        myLangauagesViewSource.View.MoveCurrentTo(newLanguage);
                        context.SaveChanges();
                        Messenger.Default.Send<string>(Utils.LanguageAddedMessage);
                    }
                    else
                    {
                        MessageBox.Show("Language Is Empty.");
                    }
                }
                newLanguageGrid.Visibility = Visibility.Collapsed;
                existinglanguageDataGrid.Visibility = Visibility.Visible;
            }
        } 
        private void AddCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existinglanguageDataGrid.Visibility = Visibility.Collapsed;
            newLanguageGrid.Visibility = Visibility.Visible;
            foreach (var child in newLanguageGrid.Children)
            {
                var tb = child as TextBox;
                if (tb != null)
                {
                    tb.Text = "";
                }
            }
        }
        private void CancelCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            existinglanguageDataGrid.Visibility = Visibility.Visible;
            newLanguageGrid.Visibility = Visibility.Collapsed;
        }
        private void Delete_Doctor_Language(Doctor_Languages dLanguage)
        {
            var dL = (from dl in context.Doctor_Languages.Local
                      where dl.Id == dLanguage.Id
                      select dl).FirstOrDefault();
            context.Doctor_Languages.Remove(dL);
            context.SaveChanges();
        }
        #endregion
    }
}