﻿#pragma checksum "..\..\..\..\Presentation\Pages\WordReview.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EB55049166A7C2EC1077CC2129BAD42F732CBFB5"
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
    /// WordReview
    /// </summary>
    public partial class WordReview : Game.Presentation.Pages.BasePage<Game.Presentation.WordReviewViewModel>, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Presentation\Pages\WordReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGoLeft;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Presentation\Pages\WordReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGoRight;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\Presentation\Pages\WordReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image wordImage;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Presentation\Pages\WordReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbxEnglishWord;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Presentation\Pages\WordReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbxSpelling;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Presentation\Pages\WordReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbxDefinition;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Presentation\Pages\WordReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPronoun;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\Presentation\Pages\WordReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MediaElement mePronoun;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Presentation\Pages\WordReview.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGoBack;
        
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
            System.Uri resourceLocater = new System.Uri("/Game;component/presentation/pages/wordreview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Presentation\Pages\WordReview.xaml"
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
            this.btnGoLeft = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Presentation\Pages\WordReview.xaml"
            this.btnGoLeft.Click += new System.Windows.RoutedEventHandler(this.btnGoLeft_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnGoRight = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\Presentation\Pages\WordReview.xaml"
            this.btnGoRight.Click += new System.Windows.RoutedEventHandler(this.btnGoRight_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.wordImage = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.tbxEnglishWord = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.tbxSpelling = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.tbxDefinition = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btnPronoun = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\..\Presentation\Pages\WordReview.xaml"
            this.btnPronoun.Click += new System.Windows.RoutedEventHandler(this.btnPronoun_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.mePronoun = ((System.Windows.Controls.MediaElement)(target));
            return;
            case 9:
            this.btnGoBack = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\Presentation\Pages\WordReview.xaml"
            this.btnGoBack.Click += new System.Windows.RoutedEventHandler(this.btnGoBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

