﻿// // <copyright file = "IMap.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetFramework
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public interface IMap
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <returns></returns>
        IKey GetKey( );

        /// <summary>
        /// Gets the elements.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IElement> GetElements( );

        /// <summary>
        /// Gets the input.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, object> GetInput( );

        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <returns></returns>
        IDictionary<string, object> GetOutput( );
    }
}