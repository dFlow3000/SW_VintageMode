﻿#pragma checksum "..\..\StartMenue.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "330538F07F95776071CD75D3762C1B5408194438"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using ShipWar;
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


namespace ShipWar {
    
    
    /// <summary>
    /// StartMenue
    /// </summary>
    public partial class StartMenue : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\StartMenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_Singleplayer;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\StartMenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IMG_BTN_Singleplayer;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\StartMenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BTN_Multiplayer;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\StartMenue.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IMG_BTN_Multiplayer;
        
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
            System.Uri resourceLocater = new System.Uri("/ShipWar;component/startmenue.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StartMenue.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            
            #line 8 "..\..\StartMenue.xaml"
            ((ShipWar.StartMenue)(target)).Loaded += new System.Windows.RoutedEventHandler(this.StartMenue_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BTN_Singleplayer = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\StartMenue.xaml"
            this.BTN_Singleplayer.Click += new System.Windows.RoutedEventHandler(this.BTN_Singleplayer_Click);
            
            #line default
            #line hidden
            
            #line 17 "..\..\StartMenue.xaml"
            this.BTN_Singleplayer.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.BTN_SingleplayerMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.IMG_BTN_Singleplayer = ((System.Windows.Controls.Image)(target));
            
            #line 18 "..\..\StartMenue.xaml"
            this.IMG_BTN_Singleplayer.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.BTN_SingleplayerMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BTN_Multiplayer = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\StartMenue.xaml"
            this.BTN_Multiplayer.Click += new System.Windows.RoutedEventHandler(this.BTN_Multiplayer_Click);
            
            #line default
            #line hidden
            
            #line 20 "..\..\StartMenue.xaml"
            this.BTN_Multiplayer.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.BTN_MultiplayerMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.IMG_BTN_Multiplayer = ((System.Windows.Controls.Image)(target));
            
            #line 21 "..\..\StartMenue.xaml"
            this.IMG_BTN_Multiplayer.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.BTN_MultiplayerMouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

