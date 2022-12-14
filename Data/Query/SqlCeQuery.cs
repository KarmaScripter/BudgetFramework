// <copyright file = "SqlCeQuery.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetFramework
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Windows;
    using Microsoft.Win32;

    /// <inheritdoc/>
    /// <summary>
    /// </summary>
    /// <seealso cref = "T:BudgetFramework.Query"/>
    public class SqlCeQuery : Query
    {
        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref = "T:BudgetFramework.SqlCeQuery"/>
        /// class.
        /// </summary>
        public SqlCeQuery( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SqlCeQuery"/> class.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        public SqlCeQuery( Source source )
            : base( source, Provider.Access, SQL.SELECT )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SqlCeQuery"/> class.
        /// </summary>
        /// <param name = "source" >
        /// The source.
        /// </param>
        /// <param name = "dict" >
        /// The dictionary.
        /// </param>
        public SqlCeQuery( Source source, IDictionary<string, object> dict )
            : base( source, Provider.Access, dict, SQL.SELECT )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCeQuery"/> class.
        /// </summary>
        /// <param name="source">The source Data.</param>
        /// <param name="provider">The provider used.</param>
        /// <param name="dict">The dictionary of parameters.</param>
        /// <param name="commandType">The type of sql command.</param>
        public SqlCeQuery( Source source, Provider provider, IDictionary<string, object> dict,
            SQL commandType )
            : base( source, provider, dict, commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCeQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="updates"></param>
        /// <param name="where">The where.</param>
        /// <param name="commandType">Type of the command.</param>
        public SqlCeQuery( Source source, Provider provider, IDictionary<string, object> updates,
            IDictionary<string, object> where, SQL commandType = SQL.UPDATE )
            : base( source, provider, updates, where, commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCeQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="criteria">The criteria.</param>
        /// <param name="commandType">Type of the command.</param>
        public SqlCeQuery( Source source, Provider provider, IEnumerable<string> columns,
            IDictionary<string, object> criteria, SQL commandType = SQL.SELECT )
            : base( source, provider, columns, criteria, commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "SqlCeQuery"/> class.
        /// </summary>
        /// <param name = "sqlStatement" >
        /// The sqlStatement.
        /// </param>
        public SqlCeQuery( ISqlStatement sqlStatement )
            : base( sqlStatement )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCeQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="sqlText">The SQL text.</param>
        public SqlCeQuery( Source source, Provider provider, string sqlText )
            : base( source, provider, sqlText )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCeQuery"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="provider">The provider.</param>
        /// <param name="dict">The dictionary.</param>
        public SqlCeQuery( Source source, Provider provider, IDictionary<string, object> dict )
            : base( source, provider, dict )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCeQuery"/> class.
        /// </summary>
        /// <param name="fullPath">The fullpath.</param>
        /// <param name="sqlText"></param>
        /// <param name="commandType">The commandType.</param>
        public SqlCeQuery( string fullPath, string sqlText, SQL commandType = SQL.SELECT )
            : base( fullPath, sqlText, commandType )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlCeQuery"/> class.
        /// </summary>
        /// <param name="fullPath">The fullpath.</param>
        /// <param name="commandType">The commandType.</param>
        /// <param name="dict">The dictionary.</param>
        public SqlCeQuery( string fullPath, SQL commandType, IDictionary<string, object> dict )
            : base( fullPath, commandType, dict )
        {
        }

        /// <summary>
        /// Gets the excel file path.
        /// </summary>
        /// <returns>
        /// </returns>
        private string GetExcelFilePath( )
        {
            try
            {
                var _fileName = "";
                var _fileDialog = new OpenFileDialog
                {
                    Title = "Excel File Dialog",
                    InitialDirectory = @"c:\",
                    Filter = "All files (*.*)|*.*|All files (*.*)|*.*",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                if( !string.IsNullOrEmpty( _fileDialog.SafeFileName ) )
                {
                    _fileName = _fileDialog.FileName;
                }

                return _fileName;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( string );
            }
        }

        /// <summary>
        /// Creates the table from excel file.
        /// </summary>
        /// <param name = "fileName" >
        /// The filePath.
        /// </param>
        /// <param name = "sheetName" >
        /// The sheetName.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable CreateTableFromExcelFile( string fileName, ref string sheetName )
        {
            if( !string.IsNullOrEmpty( fileName )
               && !string.IsNullOrEmpty( sheetName ) )
            {
                try
                {
                    var _dataSet = new DataSet( );
                    var _dataTable = new DataTable( );
                    _dataSet.DataSetName = fileName;
                    _dataTable.TableName = sheetName;
                    _dataSet.Tables.Add( _dataTable );
                    var _sql = $"SELECT * FROM {sheetName}$";
                    var cstring = GetExcelFilePath( );
                    if( !string.IsNullOrEmpty( cstring ) )
                    {
                        var _excelQuery = new ExcelQuery( cstring, _sql );
                        var _connection = DataConnection as OleDbConnection;
                        _connection?.Open( );
                        var _dataAdapter = _excelQuery.GetAdapter( );
                        _dataAdapter.Fill( _dataSet );
                        return _dataTable.Columns.Count > 0
                            ? _dataTable
                            : default( DataTable );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Creates the table from CSV file.
        /// </summary>
        /// <param name = "filePath" >
        /// The filePath.
        /// </param>
        /// <param name = "sheetName" >
        /// The sheetName.
        /// </param>
        /// <returns>
        /// </returns>
        public DataTable CreateTableFromCsvFile( string filePath, ref string sheetName )
        {
            if( !string.IsNullOrEmpty( filePath )
               && !string.IsNullOrEmpty( sheetName ) )
            {
                try
                {
                    var _dataSet = new DataSet( );
                    var _dataTable = new DataTable( );
                    var _fileName = ConnectionBuilder?.FileName;
                    if( _fileName != null )
                    {
                        _dataSet.DataSetName = _fileName;
                    }

                    _dataTable.TableName = sheetName;
                    _dataSet.Tables.Add( _dataTable );
                    var _cstring = GetExcelFilePath( );
                    if( !string.IsNullOrEmpty( _cstring ) )
                    {
                        var _sql = $"SELECT * FROM {sheetName}$";
                        var _csvQuery = new CsvQuery( _cstring, _sql );
                        var _dataAdapter = _csvQuery.GetAdapter( ) as OleDbDataAdapter;
                        _dataAdapter?.Fill( _dataSet, sheetName );
                        return _dataTable.Columns.Count > 0
                            ? _dataTable
                            : default( DataTable );
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( DataTable );
                }
            }

            return default( DataTable );
        }

        /// <summary>
        /// Checks if sheet name exists.
        /// </summary>
        /// <param name = "sheetName" >
        /// The sheetName.
        /// </param>
        /// <param name = "schemaTable" >
        /// The datatable.
        /// </param>
        /// <returns>
        /// </returns>
        private bool CheckIfSheetNameExists( string sheetName, DataTable schemaTable )
        {
            if( !string.IsNullOrEmpty( sheetName )
               && schemaTable != null
               && schemaTable.Columns.Count > 0 )
            {
                for( var i = 0; i < schemaTable.Rows.Count; i++ )
                {
                    var _dataRow = schemaTable.Rows[ i ];
                    if( sheetName == _dataRow[ "TABLENAME" ].ToString( ) )
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                base.Dispose( disposing );
                IsDisposed = true;
            }

            Dispose( );
        }
    }
}