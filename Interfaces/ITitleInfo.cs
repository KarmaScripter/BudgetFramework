// // <copyright file = "ITitleInfo.cs" company = "Terry D. Eppler">
// // Copyright (c) Terry D. Eppler. All rights reserved.
// // </copyright>

namespace BudgetFramework
{
    using System.Drawing;
    using Syncfusion.Windows.Tools;

    public interface ITitleInfo
    {
        /// <summary> Sets the main title. </summary>
        /// <returns> </returns>
        string GetMainText( );

        /// <summary> Sets the axis title. </summary>
        /// <returns> </returns>
        string GetAxisText( );
    }
}