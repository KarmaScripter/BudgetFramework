﻿// <copyright file = "AnnualReimbursableSurvey.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetFramework
{
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// 
    /// </summary>
    [SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    public class AnnualReimbursableSurvey
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public Source Source { get; set; }

        /// <summary>
        /// Gets or sets the Record property.
        /// </summary>
        /// <value>
        /// The data row.
        /// </value>
        public DataRow Record { get; set; }

        /// <summary>
        /// Gets the arguments.
        /// </summary>
        /// <value>
        /// The arguments.
        /// </value>
        public IDictionary<string, object> Data { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnualReimbursableSurvey"/> class.
        /// </summary>
        public AnnualReimbursableSurvey( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnualReimbursableSurvey"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        public AnnualReimbursableSurvey( IQuery query )
        {
            Record = new DataBuilder( query ).Record;
            Data = Record.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnualReimbursableSurvey"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public AnnualReimbursableSurvey( IDataModel builder )
        {
            Record = builder.Record;
            Data = Record.ToDictionary( );
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnnualReimbursableSurvey"/> class.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        public AnnualReimbursableSurvey( DataRow dataRow )
        {
            Record = dataRow;
            Data = dataRow.ToDictionary( );
        }
    }
}
