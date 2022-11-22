// <copyright file = "DataGridExtensions.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
//  </copyright>

namespace BudgetFramework
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Windows.Controls;

    /// <summary>
    /// 
    /// </summary>
    public static class DataGridExtensions
    {
        /// <summary>
        /// The GetDataTable
        /// </summary>
        /// <param name="dataGrid">The dataGridView
        /// <see cref="DataGrid" /></param>
        /// <returns>
        /// The
        /// <see cref="DataTable" />
        /// </returns>
        public static DataTable GetDataTable( this DataGrid dataGrid )
        {
            try
            {
                var _table = new DataTable( );
                foreach( DataGridColumn _column in dataGrid.Columns )
                {
                    _table.Columns.Add( new DataColumn
                    {
                        ColumnName = _column.Header.ToString( )
                    } );
                }

                foreach( var item in dataGrid.ItemsSource )
                {
                    var _values = dataGrid.Items;
                    for( var i = 0; i < _values.Count; i++ )
                    {
                    }

                    _table.Rows.Add( _values );
                }

                return _table;
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataTable );
            }
        }

        /// <summary>
        /// The SetColumns
        /// </summary>
        /// <param name="dataGrid">The dataGridView</param>
        /// <param name="columns">The fields
        /// <see><cref> string[] </cref></see></param>
        /// <returns>
        /// The
        /// <see cref="DataTable" />
        /// </returns>
        public static DataTable SetColumns( this DataGrid dataGrid, string[ ] columns )
        {
            if( columns?.Length > 0 )
            {
                try
                {
                    var _grid = dataGrid.GetDataTable( );
                    if( _grid != null )
                    {
                        var _view = new System.Data.DataView( _grid );
                        if( _grid?.Columns.Count > 0 )
                        {
                            var _table = _view.ToTable( true, columns );
                            return _table?.Columns?.Count > 0
                                ? _table
                                : default( DataTable );
                        }
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
        /// The SetColumns
        /// </summary>
        /// <param name="dataGrid">The dataGridView
        /// <see cref="DataGrid" /></param>
        /// <param name="fields">The fields
        /// <see /></param>
        /// <returns>
        /// The
        /// <see cref="DataTable" />
        /// </returns>
        public static DataTable SetColumns( this DataGrid dataGrid, Field[ ] fields )
        {
            if( fields?.Length > 0 )
            {
                try
                {
                    using var _dataTable = dataGrid.GetDataTable( );
                    using var _view = new System.Data.DataView( _dataTable );
                    if( _dataTable?.Columns?.Count > 0 )
                    {
                        var _columns = fields
                            ?.Select( f => f.ToString( ) )
                            ?.ToArray( );

                        var _table = _view?.ToTable( true, _columns );
                        return _table?.Columns?.Count > 0
                            ? _table
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
        /// The SetColumns
        /// </summary>
        /// <param name="dataGrid">The dataGridView
        /// <see cref="DataGrid" /></param>
        /// <param name="index">The index
        /// <see /></param>
        /// <returns>
        /// The
        /// <see cref="DataTable" />
        /// </returns>
        public static DataTable SetColumns( this DataGrid dataGrid, int[ ] index )
        {
            try
            {
                using var _dataTable = dataGrid?.GetDataTable( );
                if( _dataTable?.Columns?.Count > 0
                   && index?.Length > 0 )
                {
                    var _columns = _dataTable.Columns;
                    var _names = new string[ index.Length ];
                    if( _columns?.Count > 0
                       && _names?.Length > 0 )
                    {
                        for( var i = 0; i < index.Length; i++ )
                        {
                            _names[ i ] = _columns[ index[ i ] ].ColumnName;
                        }
                    }

                    using var _view = new System.Data.DataView( _dataTable );
                    var _table = _view?.ToTable( true, _names );
                    return _table.Columns.Count > 0
                        ? _table
                        : default( DataTable );
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
                return default( DataTable );
            }

            return default( DataTable );
        }

        /// <summary>
        /// The CommaDelimitedRows
        /// </summary>
        /// <param name="dataGrid">The dataGridView
        /// <see cref="DataGrid" /></param>
        /// <returns>
        /// The
        /// <see />
        /// </returns>
        public static IEnumerable<string> CommaDelimitedRows( this DataGrid dataGrid )
        {
            if( dataGrid?.Columns.Count > 0 )
            {
                try
                {
                    var _list = new List<string>( );
                    return _list?.Any( ) == true
                        ? _list.ToArray( )
                        : default( IEnumerable<string> );
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default( IEnumerable<string> );
                }
            }

            return default( IEnumerable<string> );
        }

        /// <summary>
        /// The ExportToCommaDelimitedFile
        /// </summary>
        /// <param name="dataGrid">The dataGridView
        /// <see cref="DataGrid" /></param>
        /// <param name="fileName">The fileName
        /// <see cref="string" /></param>
        public static void ExportToCommaDelimitedFile( this DataGrid dataGrid, string fileName )
        {
            if( dataGrid != null )
            {
                try
                {
                    var _baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    if( !string.IsNullOrEmpty( _baseDirectory ) )
                    {
                        var _path = Path.Combine( _baseDirectory, fileName );
                        if( !string.IsNullOrEmpty( _path ) )
                        {
                            File.WriteAllLines( _path, dataGrid.CommaDelimitedRows( ) );
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// The ExpandColumns
        /// </summary>
        /// <param name="dataGridView">The dataGridView
        /// <see cref="DataGrid" /></param>
        public static void ExpandColumns( this DataGrid dataGridView )
        {
            try
            {
                foreach( DataGridColumn _column in dataGridView.Columns )
                {
                }
            }
            catch( Exception ex )
            {
                Fail( ex );
            }
        }

        /// <summary>
        /// The PascalizeHeaders
        /// </summary>
        /// <param name="dataGrid">The dataGridView
        /// <see cref="DataGrid" /></param>
        /// <param name="dataTable">The dataTable
        /// <see cref="DataTable" /></param>
        public static void PascalizeHeaders( this DataGrid dataGrid, DataTable dataTable )
        {
            if( dataTable?.Columns?.Count > 0 )
            {
                try
                {
                    foreach( var column in dataGrid.Columns )
                    {
                        var _name = column.Header.ToString( );
                        if( !string.IsNullOrEmpty( dataTable.Columns[ _name ].Caption ) )
                        {
                            column.Header = dataTable.Columns[ _name ].Caption;
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }

        /// <summary>
        /// The PascalizeHeaders
        /// </summary>
        /// <param name="dataGrid">The dataGridView
        /// <see cref="DataGrid" /></param>
        public static void PascalizeHeaders( this DataGrid dataGrid )
        {
            if( dataGrid.CurrentItem != null )
            {
                try
                {
                    using var _table = dataGrid.GetDataTable( );
                    if( _table?.Columns?.Count > 0 )
                    {
                        foreach( DataGridColumn _column in dataGrid.Columns )
                        {
                            if( !string.IsNullOrEmpty( _table.Columns[ _column.Header.ToString( ) ].Caption ) )
                            {
                                _column.Header = _table.Columns[ _column.Header.ToString( ) ].Caption;
                            }
                        }
                    }
                }
                catch( Exception ex )
                {
                    Fail( ex );
                }
            }
        }
         
        /// <summary>Fails the specified ex.</summary>
        /// <param name="ex">The ex.</param>
        private static void Fail( Exception ex )
        {
            var _error = new Error( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}