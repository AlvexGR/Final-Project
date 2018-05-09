﻿using Game.Model;
using Game.Presentation;
using Game.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : BasePage<MainViewModel>
    {
        #region Constructor
        public Main()
        {
            InitializeComponent();
            ((MainWindow)Application.Current.MainWindow).imgUser.Visibility = Visibility.Visible;
            ((MainWindow)Application.Current.MainWindow).tbxUser.Visibility = Visibility.Visible;
            ((MainWindow)Application.Current.MainWindow).tbxUser.Text = GetData.currentUser.Username;
        }
        #endregion

        #region Other Methods
        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadFromLeft = isLoadFromRight = firstTime = false;
        }
        #endregion

        #region Click Methods
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            Application.Current.Shutdown();
        }

        private void btnOption_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
            GetData.isTheme = false;
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnTheme_Click(object sender, RoutedEventArgs e)
        {
            GetData.isTheme = true;
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnVocabularyList_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
            ((MainWindow)Application.Current.MainWindow).imgUser.Visibility = Visibility.Hidden;
            ((MainWindow)Application.Current.MainWindow).tbxUser.Visibility = Visibility.Hidden;
        }
        #endregion

        #region MouseEnter and MouseLeave Methods
        //Go Back
        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }

        //Setting
        private void imgSetting_MouseEnter(object sender, MouseEventArgs e)
        {
            imgSetting.Source = new BitmapImage(new Uri("/Images/Button/setting_on.png", UriKind.Relative));
        }

        private void imgSetting_MouseLeave(object sender, MouseEventArgs e)
        {
            imgSetting.Source = new BitmapImage(new Uri("/Images/Button/setting.png", UriKind.Relative));
        }
        #endregion
    }
}
