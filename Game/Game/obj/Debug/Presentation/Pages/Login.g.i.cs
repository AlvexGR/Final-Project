﻿#pragma checksum "..\..\..\..\Presentation\Pages\Login.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0F7DBE1C8D7BB3DAE49BF4B4266DF18BB79AB663"
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
    /// Login
    /// </summary>
    public partial class Login : Game.Presentation.Pages.BasePage<Game.Presentation.LoginViewModel>, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Presentation\Pages\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxUserName;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Presentation\Pages\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox tbxPassword;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Presentation\Pages\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLogin;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\Presentation\Pages\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgNoTheme;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Presentation\Pages\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbxError;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Presentation\Pages\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegister;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Presentation\Pages\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbxRegister;
        
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
            System.Uri resourceLocater = new System.Uri("/Game;component/presentation/pages/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Presentation\Pages\Login.xaml"
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
            this.tbxUserName = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\..\Presentation\Pages\Login.xaml"
            this.tbxUserName.KeyDown += new System.Windows.Input.KeyEventHandler(this.BasePage_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbxPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 25 "..\..\..\..\Presentation\Pages\Login.xaml"
            this.tbxPassword.KeyDown += new System.Windows.Input.KeyEventHandler(this.BasePage_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnLogin = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\Presentation\Pages\Login.xaml"
            this.btnLogin.Click += new System.Windows.RoutedEventHandler(this.btnLogin_Click);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\..\Presentation\Pages\Login.xaml"
            this.btnLogin.KeyDown += new System.Windows.Input.KeyEventHandler(this.BasePage_KeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.imgNoTheme = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.tbxError = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.btnRegister = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\Presentation\Pages\Login.xaml"
            this.btnRegister.Click += new System.Windows.RoutedEventHandler(this.btnRegister_Click);
            
            #line default
            #line hidden
            
            #line 44 "..\..\..\..\Presentation\Pages\Login.xaml"
            this.btnRegister.MouseEnter += new System.Windows.Input.MouseEventHandler(this.btnRegister_MouseEnter);
            
            #line default
            #line hidden
            
            #line 44 "..\..\..\..\Presentation\Pages\Login.xaml"
            this.btnRegister.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btnRegister_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tbxRegister = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
