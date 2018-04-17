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
    /// Interaction logic for ThemeSelection.xaml
    /// </summary>
    public partial class ThemeSelection : BasePage<ThemeSelectionViewModel>
    {
        private MainDb db = new MainDb();
        private Dictionary<string, int> idx = new Dictionary<string, int>();
        public ThemeSelection()
        {
            InitializeComponent();
            List<Theme> lst = db.Themes.ToList();
            foreach(var thm in lst)
            {
                lvTheme.Items.Add(thm.Name);
                idx[thm.Name] = thm.Id;
            }
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

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ResetAnimationStatus();
            isUnloadToLeft = true;
            GetData.curTheme = idx[lvTheme.SelectedItem.ToString()];
            GetData.isTheme = true;
        }
    }
}
