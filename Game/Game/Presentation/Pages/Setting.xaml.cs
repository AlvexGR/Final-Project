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
        private MainDb db = new MainDb();
        public Setting()
        {
            InitializeComponent();
            slideVolume.Value = GetData.volume;
        }

        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToRight = true;
        }
        private void imgBackButton_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button_on.png", UriKind.Relative));
        }

        private void imgBackButton_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBackButton.Source = new BitmapImage(new Uri("/Images/Button/back_button.png", UriKind.Relative));
        }

        private bool CanChange()
        {
            if(GetData.currentUser.Password != tbxCurPass.Password)
            {
                tbxStatus.Text = "Mật khẩu hiện tại không đúng";
                tbxStatus.Visibility = Visibility.Visible;
                tbxStatus.Foreground = Brushes.Red;
                return false;
            }
            if(tbxNewPass.Password != tbxReNewPass.Password)
            {
                tbxStatus.Text = "Mật khẩu mới không khớp";
                tbxStatus.Visibility = Visibility.Visible;
                tbxStatus.Foreground = Brushes.Red;
                return false;
            }
            return true;
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if(CanChange())
            {
                tbxStatus.Text = "Thay đổi mật khẩu thành công";
                tbxStatus.Visibility = Visibility.Visible;
                tbxStatus.Foreground = Brushes.Green;
                tbxCurPass.Password = tbxNewPass.Password = tbxReNewPass.Password = "";
            }
        }

        private void slideVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbxVolume.Text = "Âm lượng: " + slideVolume.Value.ToString();
        }
    }
}
