﻿#pragma checksum "..\..\..\..\Presentation\Pages\Main.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D12DC4A89E4D106A4CE485EB28835A2AA34A4E10"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Game.Presentation;
using Game.Presentation.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Game.Presentation.Pages {
    
    
    /// <summary>
    /// Main
    /// </summary>
    public partial class Main : Game.Presentation.Pages.BasePage<Game.Presentation.MainViewModel>, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Presentation\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTheme;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Presentation\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNoThemes;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Presentation\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVocabularyList;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Presentation\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Presentation\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgSetting;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Presentation\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHistory;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Presentation\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgHistory;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Presentation\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogout;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Presentation\Pages\Main.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgLogout;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Game;component/presentation/pages/main.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Presentation\Pages\Main.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnTheme = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.btnTheme.Click += new System.Windows.RoutedEventHandler(this.btnTheme_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnNoThemes = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.btnNoThemes.Click += new System.Windows.RoutedEventHandler(this.btnNoThemes_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnVocabularyList = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.btnVocabularyList.Click += new System.Windows.RoutedEventHandler(this.btnVocabularyList_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.imgSetting = ((System.Windows.Controls.Image)(target));
            
            #line 27 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.imgSetting.MouseEnter += new System.Windows.Input.MouseEventHandler(this.imgSetting_MouseEnter);
            
            #line default
            #line hidden
            
            #line 27 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.imgSetting.MouseLeave += new System.Windows.Input.MouseEventHandler(this.imgSetting_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnHistory = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.btnHistory.Click += new System.Windows.RoutedEventHandler(this.btnHistory_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.imgHistory = ((System.Windows.Controls.Image)(target));
            
            #line 30 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.imgHistory.MouseEnter += new System.Windows.Input.MouseEventHandler(this.imgHistory_MouseEnter);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.imgHistory.MouseLeave += new System.Windows.Input.MouseEventHandler(this.imgHistory_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnLogout = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.btnLogout.Click += new System.Windows.RoutedEventHandler(this.btnLogout_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.imgLogout = ((System.Windows.Controls.Image)(target));
            
            #line 33 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.imgLogout.MouseEnter += new System.Windows.Input.MouseEventHandler(this.imgLogout_MouseEnter);
            
            #line default
            #line hidden
            
            #line 33 "..\..\..\..\Presentation\Pages\Main.xaml"
            this.imgLogout.MouseLeave += new System.Windows.Input.MouseEventHandler(this.imgLogout_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

