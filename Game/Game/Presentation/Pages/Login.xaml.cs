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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : BasePage<LoginViewModel>
    {
        private MainDb db = new MainDb();
        public Login()
        {
            InitializeComponent();
            tbxUserName.Focus();
        }

        private void ResetAnimationStatus()
        {
            isUnloadToLeft = isUnloadToRight = isLoadBack = isLoadFromRight = firstTime = false;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(CanLogin())
            {
                GetData.currentUser = db.Users.Where(x => x.Username == tbxUserName.Text).First();
                ResetAnimationStatus();
                isUnloadToLeft = true;
                GetData.didRegister = false;
                tbxError.Visibility = Visibility.Hidden;
                (DataContext as LoginViewModel).MainCommand.Execute(null);
            }
        }

        private void BasePage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && CanLogin())
            {
                GetData.currentUser = db.Users.Where(x => x.Username == tbxUserName.Text).First();
                ResetAnimationStatus();
                isUnloadToLeft = true;
                GetData.didRegister = false;
                tbxError.Visibility = Visibility.Hidden;
                (DataContext as LoginViewModel).MainCommand.Execute(null);
            }
        }

        private bool CanLogin()
        {
            tbxUserName.Text = tbxUserName.Text.Trim();
            tbxUserName.SelectionStart = tbxUserName.Text.Length;
            tbxUserName.SelectionLength = 0;
            if(db.Users.Where(x => x.Username == tbxUserName.Text && x.Password == tbxPassword.Password).ToList().Count == 0)
            {
                tbxError.Text = "Tên đăng nhập hoặc mật khẩu sai";
                tbxError.Foreground = Brushes.Red;
                tbxError.Visibility = Visibility.Visible;
                return false;
            }
            return true;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
        }

        private void btnRegister_MouseEnter(object sender, MouseEventArgs e)
        {
            tbxRegister.Foreground = Brushes.DarkGoldenrod;
            tbxRegister.TextDecorations = TextDecorations.Underline;
        }

        private void btnRegister_MouseLeave(object sender, MouseEventArgs e)
        {
            tbxRegister.Foreground = Brushes.Blue;
            tbxRegister.TextDecorations = null;
        }

    }
}
