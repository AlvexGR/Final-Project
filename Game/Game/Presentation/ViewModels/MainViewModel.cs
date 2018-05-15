using Game.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Game.Presentation
{
    public class MainViewModel : BaseViewModel
    {
        
        #region Public Properties
        public ICommand ThemeCommand { set; get; }
        public ICommand OptionCommand { set; get; }
        public ICommand VocabularyListCommand { set; get; }
        public ICommand SettingCommand { set; get; }
        public ICommand PreviousCommand { set; get; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            ThemeCommand = new RelayCommand(async() => await GoToTheme());
            OptionCommand = new RelayCommand(async() => await GoToOption());
            SettingCommand = new RelayCommand(async () => await GoToSetting());
            VocabularyListCommand = new RelayCommand(async () => await GoToVocabularyList());
            PreviousCommand = new RelayCommand(async () => await GoToPrevious());
        }
        #endregion

        #region Async Methods
        public async Task GoToPrevious()
        {
            var pageName = GetNameOfObject.GetName(PageStack.pageStack.Peek().ToString()) + "Page";
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = (AppPage.AppPage)Enum.Parse(typeof(AppPage.AppPage), pageName);
            await Task.Delay(1);
        }

        public async Task GoToTheme()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.ThemeSelectionPage;
            await Task.Delay(1);
        }

        public async Task GoToOption()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.WordSetPage;
            await Task.Delay(1);
        }

        public async Task GoToVocabularyList()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.VocabularyListPage;
            await Task.Delay(1);
        }

        public async Task GoToSetting()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.SettingPage;
            await Task.Delay(1);
        }
        #endregion
    }
}
