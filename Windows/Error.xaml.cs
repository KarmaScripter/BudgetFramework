// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>
//

namespace BudgetFramework
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for Error.xaml
    /// </summary>
    public partial class Error : Window
    {
        /// <summary>
        /// The application setting
        /// </summary>
        public virtual NameValueCollection Setting { get; set; } = ConfigurationManager.AppSettings;

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public virtual Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the icon path.
        /// </summary>
        /// <value>
        /// The icon path.
        /// </value>
        public virtual string IconPath { get; set; }

        public Error( )
        {
            InitializeComponent( );
        }

        public Error( Exception ex ) 
            : this( )
        {
        }

        public Error( string message ) 
            : this( )
        {
        }
        /// <summary>
        /// Sets the text.
        /// </summary>
        public void SetText( )
        {
            try
            {
                //var _logString = Exception?.ToLogString( "" );
                Console.WriteLine(  );
            }
            catch( Exception ex )
            {
                Console.WriteLine( ex.StackTrace );
            }
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        public void SetText( Exception exc )
        {
            try
            {
               // var _logString = exc?.ToLogString( "" );
               // Console.WriteLine( _logString );
            }
            catch( Exception ex )
            {
                Console.WriteLine( ex.StackTrace );
            }
        }

        /// <summary>
        /// Sets the text.
        /// </summary>
        public void SetText( string msg = "" )
        {
            Console.WriteLine( msg );
        }

        public void OnClick( object sender, EventArgs e )
        {
            if( sender is Button )
            {
                Close( );
            }
        }
    }
}
