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
        }
        #endregion

        #region Async Methods
        public async Task GoToTheme()
        {
            await Task.Delay(1);
        }

        public async Task GoToNoTheme()
        {
            ((WindowViewModel)((MainWindow)System.Windows.Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.NoThemeSelectionPage;
            await Task.Delay(1);
        }

        public async Task GoToVocabularyList()
        {
            await Task.Delay(1);
        }

        public async Task GoToSetting()
        {
            await Task.Delay(1);
        }

        public async Task GoToHistory()
        {
            await Task.Delay(1);
        } 
        #endregion
    }
}
