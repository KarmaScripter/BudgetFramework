﻿// // <copyright file = "IKey.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetFramework
{
    /// <summary>
    /// 
    /// </summary>
    public interface IKey
    {
        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <returns></returns>
        int Index { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns></returns>
        string Name { get; set; }
    }
}