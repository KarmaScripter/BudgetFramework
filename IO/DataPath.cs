// // <copyright file = "DataPath.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetFramework
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PathBase" />
    public class DataPath : PathBase, IPath
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataPath"/> class.
        /// </summary>
        public DataPath( )
        {
        }

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="DataPath"/> class.
        /// </summary>
        /// <param name="input">The input.</param>
        public DataPath( string input )
            : base( input )
        {
        }
    }
}