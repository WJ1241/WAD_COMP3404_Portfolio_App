using System.Collections.Generic;

namespace GUI.Logic.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to Open Files on a client's device
    /// Author: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public interface IOpenImage : ILogic
    {
        #region METHODS

        /// <summary>
        /// Open Image(s), User is directed to App's Displayable folder
        /// </summary>
        /// <returns> List of File Names </returns>
        IList<string> OpenImage();

        #endregion
    }
}
