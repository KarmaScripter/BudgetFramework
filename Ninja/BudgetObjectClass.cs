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
    /// Object classes are categories in a classification system that presents
    /// obligations by the items or services purchased by the Federal Government. The
    /// object classes present obligations according to their initial purpose, not the
    /// end product or service. Major object classes are divided into smaller classes
    /// known as Finance Object Classes. EPA uses the categories defined by the values
    /// of the ObjectClasses enumeration.
    /// </summary>
    /// <seealso cref = "IProgram"/>
    /// <seealso cref = "IBudgetObjectClass"/>
    /// <seealso cref = "ISource"/>
    /// <seealso cref = "IDataModel"/>
    /// <seealso cref = "IBudgetObjectClass"/>
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ConvertIfStatementToSwitchStatement" ) ]
    [ SuppressMessage( "ReSharper", "AutoPropertyCanBeMadeGetOnly.Global" ) ]
    public class BudgetObjectClass : Element, IBudgetObjectClass, ISource
    {
        /// <summary>
        /// The codes
        /// </summary>
        public readonly IEnumerable<string> Codes = new[ ]
        {
            "10",
            "17",
            "21",
            "28",
            "36",
            "37",
            "38",
            "41"
        };

        /// <summary>
        /// The source
        /// </summary>
        public Source Source { get; set; } =  Source.BudgetObjectClasses;

        /// <summary>
        /// Gets the Data.
        /// </summary>
        /// <value>
        /// The Data.
        /// </value>
        public DataRow Record { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        public override string Code { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name { get; set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Data { get; set; }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public BOC Category { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        public BudgetObjectClass( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "boc" >
        /// The code.
        /// </param>
        public BudgetObjectClass( BOC boc )
            : this( )
        {
            Record = new DataBuilder( Source, SetArgs( boc ) )?.Record;
            ID = GetId( Record, PrimaryKey.BudgetObjectClassesId );
            Name = Record[ $"{ Field.BocName }" ].ToString( );
            Code = Record[ $"{ Field.BocCode }" ].ToString( );
            Category = boc;
            Data = Record?.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        public BudgetObjectClass( string code )
            : this( )
        {
            Record = new DataBuilder( Source, SetArgs( code ) )?.Record;
            ID = GetId( Record, PrimaryKey.BudgetObjectClassesId );
            Name = Record[ $"{ Field.BocName }" ].ToString( );
            Code = Record[ $"{ Field.BocCode }" ].ToString( );
            Data = Record?.ToDictionary( );

            if ( Name != null )
            {
                Category = (BOC)Enum.Parse( typeof( BOC ), Name );
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "query" >
        /// The query.
        /// </param>
        public BudgetObjectClass( IQuery query )
        {
            Record = new DataBuilder( query )?.Record;
            ID = GetId( Record, PrimaryKey.BudgetObjectClassesId );
            Name = Record[ $"{ Field.BocName }" ].ToString( );
            Code = Record[ $"{ Field.BocCode }" ].ToString( );
            Data = Record?.ToDictionary( );

            if ( Name != null )
            {
                Category = (BOC)Enum.Parse( typeof( BOC ), Name );
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "builder" >
        /// The database.
        /// </param>
        public BudgetObjectClass( IDataModel builder )
        {
            Record = builder?.Record;
            ID = GetId( Record, PrimaryKey.BudgetObjectClassesId );
            Name = Record?[ $"{ Field.BocName }" ].ToString( );
            Code = Record?[ $"{ Field.BocCode }" ].ToString( );
            Data = Record?.ToDictionary( );

            if ( Name != null )
            {
                Category = (BOC)Enum.Parse( typeof( BOC ), Name );
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "BudgetObjectClass"/> class.
        /// </summary>
        /// <param name = "dataRow" >
        /// The Data.
        /// </param>
        public BudgetObjectClass( DataRow dataRow )
        {
            Record = dataRow;
            ID = GetId( Record, PrimaryKey.BudgetObjectClassesId );
            Name = dataRow[ $"{ Field.BocName }" ].ToString( );
            Code = dataRow[ $"{ Field.BocCode }" ].ToString( );
            Data = Record?.ToDictionary( );

            if ( Name != null )
            {
                Category = (BOC)Enum.Parse( typeof( BOC ), Name );
            }
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
                return Data?.Any( ) == true
                    ? Data
                    : default( IDictionary<string, object> );
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( IDictionary<string, object> );
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name = "prc" >
        /// The ProgramResultCodes.
        /// </param>
        /// <returns>
        /// </returns>
        public double GetValue( IProgramResultsCode prc )
        {
            try
            {
                var _amount = prc.Amount;
                return _amount > -1
                    ? _amount
                    : 0;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return -1D;
            }
        }

        /// <summary>
        /// Sets the arguments.
        /// </summary>
        /// <param name = "code" >
        /// The code.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> SetArgs( string code )
        {
            if( !string.IsNullOrEmpty( code )
               && code.Length == 2
               && Codes.Contains( code ) )
            {
                try
                {
                    return new Dictionary<string, object> { [ $"{ Field.Code }" ] = code };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }
            else if( !string.IsNullOrEmpty( code )
                    && code.Length > 2
                    && Enum.GetNames( typeof( BOC ) ).Contains( code ) )
            {
                try
                {
                    return new Dictionary<string, object> { [ $"{ Field.Name }" ] = code };
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
        /// <param name = "boc" >
        /// The boc.
        /// </param>
        /// <returns>
        /// </returns>
        private IDictionary<string, object> SetArgs( BOC boc )
        {
            if( !string.IsNullOrEmpty( boc.ToString( ) )
               && boc.ToString( ).Length == 2
               && Codes.Contains( boc.ToString( ) ) )
            {
                try
                {
                    return new Dictionary<string, object>
                    {
                        [ Field.Code.ToString( ) ] = boc.ToString( )
                    };
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IDictionary<string, object> );
                }
            }

            return default( IDictionary<string, object> );
        }

        protected override int GetId( DataRow dataRow )
        {
            try
            {
                return dataRow != null
                    ? int.Parse( dataRow[ 0 ].ToString(  ) )
                    : -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( int );
            }
        }

        protected override int GetId( DataRow dataRow, PrimaryKey primaryKey )
        {
            try
            {
                return Enum.IsDefined( typeof( PrimaryKey ), primaryKey ) && dataRow != null
                    ? int.Parse( dataRow[ $"{ primaryKey }" ].ToString(  ) )
                    : -1;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( int );
            }
        }

        /// <summary>
        /// Gets the budget object class category.
        /// </summary>
        /// <returns>
        /// </returns>
        public BOC GetBudgetObjectClassCategory( )
        {
            try
            {
                return !string.IsNullOrEmpty( Name ) && Enum.IsDefined( typeof( BOC ), Name )
                    ? (BOC)Enum.Parse( typeof( BOC ), Name )
                    : BOC.NS;
            }
            catch( SystemException ex )
            {
                Fail( ex );
                return default( BOC );
            }
        }
    }
}