﻿using Game.Model;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : BasePage<RegisterViewModel>
    {
        #region Properties
        private MainDb db;
        #endregion

        #region Constructor
        public Register()
        {
            InitializeComponent();
            db = new MainDb();
            tbxUserName.Focus();
        }
        #endregion

        #region Other Methods
        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadFromLeft = isLoadFromRight = firstTime = false;
        }

        private bool CanRegister()
        {
            tbxUserName.Text = tbxUserName.Text.Trim();
            if (tbxUserName.Text.Length <= 3)
            {
                tbxError.Text = "Tên đăng nhập phải ít nhất 4 kí tự";
                tbxError.Visibility = Visibility.Visible;
                return false;
            }
            if (tbxPassword.Password.Length <= 7)
            {
                tbxError.Text = "Mật khẩu phải ít nhất 8 kí tự";
                tbxError.Visibility = Visibility.Visible;
                return false;
            }
            if (tbxPassword.Password != tbxReEnterPassword.Password)
            {
                tbxError.Text = "Mật khẩu không khớp";
                tbxError.Visibility = Visibility.Visible;
                return false;
            }
            if (db.Users.Where(x => x.Username == tbxUserName.Text).ToList().Count == 1)
            {
                tbxError.Text = "Tên tài khoản đã tồn tại";
                tbxError.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }
        #endregion

        #region Click Methods
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (CanRegister())
            {
                ResetAnimationStatus();
                isUnloadToRight = true;
                GetData.didRegister = true;
                GetData.currentUser.Username = tbxUserName.Text;
                User user = new User()
                {
                    Password = tbxPassword.Password,
                    Username = tbxUserName.Text
                };
                db.Users.Add(user);
                db.SaveChanges();
                (DataContext as RegisterViewModel).LoginCommand.Execute(null);
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
        }
        #endregion

        #region MouseEnter and MouseLeave Methods
        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }
        #endregion

        #region KeyDown Methods
        private void BasePage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && CanRegister())
            {
                ResetAnimationStatus();
                isUnloadToRight = true;
                GetData.didRegister = true;
                GetData.currentUser.Username = tbxUserName.Text;
                User user = new User()
                {
                    Password = tbxPassword.Password,
                    Username = tbxUserName.Text
                };
                db.Users.Add(user);
                db.SaveChanges();
                (DataContext as RegisterViewModel).LoginCommand.Execute(null);
            }
        }
        #endregion
    }
}
