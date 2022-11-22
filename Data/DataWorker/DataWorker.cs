// <copyright file = "DataWorker.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetFramework
{
    using System.ComponentModel;
    using System.Windows;

    public class DataWorker : BackgroundWorker
    {
        public DataModel UnitBuilder { get; set; }

        public DataWorker( )
        {
        }
    }
}