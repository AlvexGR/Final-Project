using Game.Model;
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
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : BasePage<SettingViewModel>
    {
        #region Properties
        private MainDb db;
        #endregion

        #region Constructor
        public Setting()
        {
            InitializeComponent();
            db = new MainDb();
        }
        #endregion

        #region Other Methods
        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadFromLeft = isLoadFromRight = firstTime = false;
        }

        private bool CanChange()
        {
            if (String.IsNullOrEmpty(tbxNewPass.Password))
            {
                tbxStatus.Text = "Chưa nhập mật khẩu mới";
                tbxStatus.Visibility = Visibility.Visible;
                tbxStatus.Foreground = Brushes.Red;
                return false;
            }
            if (db.Users.Find(GetData.currentUser.Id).Password != tbxCurPass.Password)
            {
                tbxStatus.Text = "Mật khẩu hiện tại không đúng";
                tbxStatus.Visibility = Visibility.Visible;
                tbxStatus.Foreground = Brushes.Red;
                return false;
            }
            if (tbxNewPass.Password.Length <= 7)
            {
                tbxStatus.Text = "Mật khẩu phải ít nhất 8 kí tự";
                tbxStatus.Visibility = Visibility.Visible;
                return false;
            }
            if (tbxNewPass.Password != tbxReNewPass.Password)
            {
                tbxStatus.Text = "Mật khẩu mới không khớp";
                tbxStatus.Visibility = Visibility.Visible;
                tbxStatus.Foreground = Brushes.Red;
                return false;
            }
            return true;
        }
        #endregion

        #region Click Methods
        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (CanChange())
            {
                tbxStatus.Text = "Thay đổi mật khẩu thành công";
                tbxStatus.Visibility = Visibility.Visible;
                tbxStatus.Foreground = Brushes.Green;
                var user = db.Users.Find(GetData.currentUser.Id);
                user.Password = tbxNewPass.Password;
                db.SaveChanges();
                tbxCurPass.Password = tbxNewPass.Password = tbxReNewPass.Password = "";

            }
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
    }
}
