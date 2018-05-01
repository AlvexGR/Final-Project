using Game.Presentation;
using Game.Presentation.Pages;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Game.UserControls
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Dependency Properties
        public BasePage CurrentPage
        {
            get { return (BasePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        #endregion
        #region Constructor
        public PageHost()
        {
            InitializeComponent();
        }
        #endregion

        #region Property Changed Events
        
        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Get the frame
            var curPageFrame = (d as PageHost).CurPage;
            var tmpPageFrame = (d as PageHost).TmpPage;
            var newPage = (BasePage)e.NewValue;
            var curPage = (BasePage)curPageFrame.Content;
            if (curPageFrame.Content is null) // first loaded
            {
                newPage.firstTime = true;
                curPageFrame.Content = newPage;
                return;
            }

            // Go back to previous page
            if(curPage.isUnloadToRight)
            {
                tmpPageFrame.Content = curPage;
                var prePage = PageStack.pageStack.Pop();
                prePage.isLoadBack = true;
                curPageFrame.Content = prePage;
            }

            // Go to new Page
            if(curPage.isUnloadToLeft)
            {
                tmpPageFrame.Content = curPage;
                PageStack.pageStack.Push((BasePage)curPageFrame.Content);
                newPage.isLoadFromRight = true;
                curPageFrame.Content = newPage;
            }
        }
        #endregion
    }
}
