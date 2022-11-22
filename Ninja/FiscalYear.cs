﻿// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace BudgetFramework
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CalendarYear" />
    /// <seealso cref="CalendarYear" />
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ] 
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeMadeStatic.Global" ) ]
    [ SuppressMessage( "ReSharper", "VirtualMemberNeverOverridden.Global" ) ]
    public abstract class FiscalYear : CalendarYear
    {
        /// <summary>
        /// Gets or sets the bfy.
        /// </summary>
        /// <value>
        /// The bfy.
        /// </value>
        public virtual BFY BFY { get; set; }

        /// <summary>
        /// Gets or sets the fiscal year identifier.
        /// </summary>
        /// <value>
        /// The fiscal year identifier.
        /// </value>
        public virtual int ID { get; set; }

        /// <summary>
        /// Gets or sets the bbfy.
        /// </summary>
        /// <value>
        /// The bbfy.
        /// </value>
        public virtual string FirstYear { get; set; }

        /// <summary>
        /// Gets or sets the ebfy.
        /// </summary>
        /// <value>
        /// The ebfy.
        /// </value>
        public virtual string LastYear { get; set; }

        /// <summary>
        /// Gets or sets the expiring year.
        /// </summary>
        /// <value>
        /// The expiring year.
        /// </value>
        public virtual string ExpiringYear { get; set; }

        /// <summary>
        /// Gets or sets the input year.
        /// </summary>
        /// <value>
        /// The input year.
        /// </value>
        public virtual string InputYear { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public virtual DateOnly StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public virtual DateOnly EndDate { get; set; }

        /// <summary>
        /// Gets or sets the cancellation date.
        /// </summary>
        /// <value>
        /// The cancellation date.
        /// </value>
        public virtual DateOnly CancellationDate { get; set; }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public override DataRow Record { get; set; }

        /// <summary>
        /// Determines whether this instance is current.
        /// </summary>
        /// <returns>
        /// <c>
        /// true
        /// </c>
        /// if this instance is current; otherwise,
        /// <c>
        /// false
        /// </c>
        /// .
        /// </returns>
        public bool IsCurrent( )
        {
            try
            {
                return BFY != 0 && BFY == BFY.Current;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( bool );
            }
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "year" >
        /// The year.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IDictionary<string, object> SetArgs( string year )
        {
            if( !string.IsNullOrEmpty( year )
               && year.Length == 4
               && int.Parse( year ) > 2018
               && int.Parse( year ) < 2040 )
            {
                try
                {
                    var bfy = new Dictionary<string, object> { [ $"{Field.BBFY}" ] = year };
                    return bfy.Any( )
                        ? bfy
                        : default( Dictionary<string, object> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "bfy" >
        /// The bfy.
        /// </param>
        /// <returns>
        /// </returns>
        private protected IDictionary<string, object> SetArgs( BFY bfy )
        {
            if( Enum.IsDefined( typeof( BFY ), bfy ) )
            {
                try
                {
                    var _year = new Dictionary<string, object>( );

                    switch( bfy )
                    {
                        case BFY.Current:
                        {
                            _year?.Add( $"{Field.BBFY}", CurrentYear.ToString( ) );
                            _year?.Add( $"{Field.EBFY}", ( CurrentYear + 1 ).ToString( ) );
                            return _year.Any( )
                                ? _year
                                : default( Dictionary<string, object> );
                        }
                        case BFY.CarryOver:
                        {
                            _year?.Add( $"{Field.BBFY}", ( CurrentYear - 1 ).ToString( ) );
                            _year?.Add( $"{Field.EBFY}", CurrentYear.ToString( ) );
                            return _year?.Any( ) == true
                                ? _year
                                : default( Dictionary<string, object> );
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <returns>
        /// </returns>
        public IDictionary<string, object> ToDictionary( )
        {
            try
            {
                return Record != null
                    ? Record.ToDictionary( )
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }
    }
}