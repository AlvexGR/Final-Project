using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Game.Presentation
{
    public class MainViewModel : BaseViewModel
    {
        
        #region Public Properties
        public ICommand ThemeCommand { set; get; }
        public ICommand NoThemeCommand { set; get; }
        public ICommand VocabularyListCommand { set; get; }
        public ICommand SettingCommand { set; get; }
        public ICommand HistoryCommand { set; get; }

        #endregion

        #region Constructor
        public MainViewModel()
        {
            ThemeCommand = new RelayCommand(async() => await GoToTheme());
            NoThemeCommand = new RelayCommand(async() => await GoToNoTheme());
            SettingCommand = new RelayCommand(async () => await GoToSetting());
            HistoryCommand = new RelayCommand(async () => await GoToHistory());
            VocabularyListCommand = new RelayCommand(async () => await GoToVocabularyList());
        }
        #endregion

        #region Async Methods
        public async Task GoToTheme()
        {
            ((WindowViewModel)((MainWindow)System.Windows.Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.ThemeSelectionPage;
            await Task.Delay(1);
        }

        public async Task GoToNoTheme()
        {
            ((WindowViewModel)((MainWindow)System.Windows.Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.NoThemeSelectionPage;
            await Task.Delay(1);
        }

        public async Task GoToVocabularyList()
        {
            ((WindowViewModel)((MainWindow)System.Windows.Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.VocabularyListPage;
            await Task.Delay(1);
        }

        public async Task GoToSetting()
        {
            ((WindowViewModel)((MainWindow)System.Windows.Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.SettingPage;
            await Task.Delay(1);
        }

        public async Task GoToHistory()
        {
            ((WindowViewModel)((MainWindow)System.Windows.Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.HistoryPage;
            await Task.Delay(1);
        } 
        #endregion
    }
}
