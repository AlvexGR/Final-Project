﻿#pragma checksum "..\..\..\..\Presentation\Pages\VocabularyList.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C73C9F79F786584454105FD9811715A0FCB26E82"
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
    /// VocabularyList
    /// </summary>
    public partial class VocabularyList : Game.Presentation.Pages.BasePage<Game.Presentation.VocabularyListViewModel>, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdAllWords;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdKnownWords;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdUnknownWords;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxVocabularies;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGoBack;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgBackButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Game;component/presentation/pages/vocabularylist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
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
            this.rdAllWords = ((System.Windows.Controls.RadioButton)(target));
            
            #line 29 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
            this.rdAllWords.Checked += new System.Windows.RoutedEventHandler(this.rdAllWords_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.rdKnownWords = ((System.Windows.Controls.RadioButton)(target));
            
            #line 30 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
            this.rdKnownWords.Checked += new System.Windows.RoutedEventHandler(this.rdKnownWords_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rdUnknownWords = ((System.Windows.Controls.RadioButton)(target));
            
            #line 31 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
            this.rdUnknownWords.Checked += new System.Windows.RoutedEventHandler(this.rdUnknownWords_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbxVocabularies = ((System.Windows.Controls.ListBox)(target));
            return;
            case 5:
            this.btnGoBack = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
            this.btnGoBack.Click += new System.Windows.RoutedEventHandler(this.btnGoBack_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.imgBackButton = ((System.Windows.Controls.Image)(target));
            
            #line 49 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
            this.imgBackButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.imgBackButton_MouseEnter);
            
            #line default
            #line hidden
            
            #line 49 "..\..\..\..\Presentation\Pages\VocabularyList.xaml"
            this.imgBackButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.imgBackButton_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

