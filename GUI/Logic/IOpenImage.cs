using System;
using System.Collections.Generic;
using Server.GeneralInterfaces;

namespace GUI.Logic
{
    /// <summary>
    /// Interface which allows implementations to Open Files on a client's device
    /// Author: William Smith
    /// Date: 26/11/21
    /// </summary>
    public interface IOpenImage : IMarker
    {
        #region METHODS

        /// <summary>
        /// Open Image(s), User is directed to App's Displayable folder
        /// </summary>
        /// <returns> List of File Names </returns>
        IList<String> OpenImage();

        #endregion
    }
}
