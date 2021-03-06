﻿using Game.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Game.Presentation
{
    public class ThemeSelectionViewModel : BaseViewModel
    {
        
        #region Public Properties
        public ICommand PreviousCommand { set; get; }
        public ICommand WordSetCommand { set; get; }

        #endregion

        #region Constructor
        public ThemeSelectionViewModel()
        {
            PreviousCommand = new RelayCommand(async() => await GoToPrevious());
            WordSetCommand = new RelayCommand(async () => await GoToWordSet());
        }
        #endregion

        #region Async Methods
        public async Task GoToPrevious()
        {
            var pageName = GetNameOfObject.GetName(PageStack.pageStack.Peek().ToString()) + "Page";
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = (AppPage.AppPage)Enum.Parse(typeof(AppPage.AppPage), pageName);
            await Task.Delay(1);
        }

        public async Task GoToWordSet()
        {
            ((WindowViewModel)((MainWindow)Application.Current.MainWindow).DataContext).CurrentPage = AppPage.AppPage.WordSetPage;
            await Task.Delay(1);
        }
        #endregion
    }
}
