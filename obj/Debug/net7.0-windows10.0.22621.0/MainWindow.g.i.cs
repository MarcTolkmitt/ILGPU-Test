﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "058B036A37FDD902D1C758BB3884783B513C68C2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using ILGPU_Test;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ILGPU_Test {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu hauptMenu;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuTest;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuFFNladen;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuFFNspeichern;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuFFNinit;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuFFNtrain;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuFFNtrain10;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuFFNpredict;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer textScroll;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ILGPU Test;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.hauptMenu = ((System.Windows.Controls.Menu)(target));
            return;
            case 2:
            
            #line 12 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuQuit);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MenuTest = ((System.Windows.Controls.MenuItem)(target));
            
            #line 14 "..\..\..\MainWindow.xaml"
            this.MenuTest.Click += new System.Windows.RoutedEventHandler(this.MenuTest_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MenuFFNladen = ((System.Windows.Controls.MenuItem)(target));
            
            #line 16 "..\..\..\MainWindow.xaml"
            this.MenuFFNladen.Click += new System.Windows.RoutedEventHandler(this.FFNladen_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MenuFFNspeichern = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\..\MainWindow.xaml"
            this.MenuFFNspeichern.Click += new System.Windows.RoutedEventHandler(this.FFNspeichern_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MenuFFNinit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\..\MainWindow.xaml"
            this.MenuFFNinit.Click += new System.Windows.RoutedEventHandler(this.FFNinit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MenuFFNtrain = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\MainWindow.xaml"
            this.MenuFFNtrain.Click += new System.Windows.RoutedEventHandler(this.FFNtrain_1_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MenuFFNtrain10 = ((System.Windows.Controls.MenuItem)(target));
            
            #line 20 "..\..\..\MainWindow.xaml"
            this.MenuFFNtrain10.Click += new System.Windows.RoutedEventHandler(this.FFNtrain_10_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MenuFFNpredict = ((System.Windows.Controls.MenuItem)(target));
            
            #line 21 "..\..\..\MainWindow.xaml"
            this.MenuFFNpredict.Click += new System.Windows.RoutedEventHandler(this.FFNpredict_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.textScroll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 11:
            this.textBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

