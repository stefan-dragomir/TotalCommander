﻿#pragma checksum "..\..\TextCompare.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "823E3535436D481665538FDEC24B26D38086E265E3E9D83981D2CE91002FF045"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TotalCommander;


namespace TotalCommander {
    
    
    /// <summary>
    /// TextCompare
    /// </summary>
    public partial class TextCompare : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\TextCompare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridFileCompare;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\TextCompare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridInputsLeft;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\TextCompare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLoadLeft;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\TextCompare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPathLeft;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\TextCompare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridInputsRight;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\TextCompare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLoadRight;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\TextCompare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPathRight;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\TextCompare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridSplitter gridSplitter;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\TextCompare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox txtCompareLeft;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\TextCompare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox txtCompareRight;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\TextCompare.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCompare;
        
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
            System.Uri resourceLocater = new System.Uri("/TotalCommander;component/textcompare.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TextCompare.xaml"
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
            
            #line 8 "..\..\TextCompare.xaml"
            ((TotalCommander.TextCompare)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gridFileCompare = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.gridInputsLeft = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.btnLoadLeft = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\TextCompare.xaml"
            this.btnLoadLeft.Click += new System.Windows.RoutedEventHandler(this.btnLoadLeft_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtPathLeft = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.gridInputsRight = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.btnLoadRight = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\TextCompare.xaml"
            this.btnLoadRight.Click += new System.Windows.RoutedEventHandler(this.btnLoadRight_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txtPathRight = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.gridSplitter = ((System.Windows.Controls.GridSplitter)(target));
            return;
            case 10:
            this.txtCompareLeft = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 29 "..\..\TextCompare.xaml"
            this.txtCompareLeft.AddHandler(System.Windows.Controls.ScrollViewer.ScrollChangedEvent, new System.Windows.Controls.ScrollChangedEventHandler(this.txtCompare_ScrollChanged));
            
            #line default
            #line hidden
            return;
            case 11:
            this.txtCompareRight = ((System.Windows.Controls.RichTextBox)(target));
            
            #line 30 "..\..\TextCompare.xaml"
            this.txtCompareRight.AddHandler(System.Windows.Controls.ScrollViewer.ScrollChangedEvent, new System.Windows.Controls.ScrollChangedEventHandler(this.txtCompare_ScrollChanged));
            
            #line default
            #line hidden
            return;
            case 12:
            this.btnCompare = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\TextCompare.xaml"
            this.btnCompare.Click += new System.Windows.RoutedEventHandler(this.btnCompare_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

