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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : BasePage<RegisterViewModel>
    {
        private MainDb db = new MainDb();
        public Register()
        {
            InitializeComponent();
            tbxUserName.Focus();
        }
        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(CanRegister())
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
        
        private bool CanRegister()
        {
            tbxUserName.Text = tbxUserName.Text.Trim();
            if (tbxUserName.Text.Length <= 3)
            {
                tbxError.Text = "Tên tài khoản phải ít nhất 4 kí tự";
                tbxError.Visibility = Visibility.Visible;
                return false;
            }
            if(tbxPassword.Password.Length <= 7)
            {
                tbxError.Text = "Mật khẩu phải ít nhất 8 kí tự";
                tbxError.Visibility = Visibility.Visible;
                return false;
            }
            if(tbxPassword.Password != tbxReEnterPassword.Password)
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

    }
}
