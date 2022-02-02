using System;
using System.Collections.Generic;
using System.Drawing;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to edit Images
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public interface IManageImg : IService
    {
        #region METHODS

        /// <summary>
        /// Filters a passed in list, to prevent duplication of strings
        /// </summary>
        /// <param name="pList"> List of Strings </param>
        /// <returns> Filtered List of Strings </returns>
        IList<String> ReturnFilteredList(IList<String> pList);

        /// <summary>
        /// Returns Image using File Name as a key to the Dictionary
        /// </summary>
        /// <param name="pFileName"> UID to access Specific Image </param>
        /// <returns> Image stored via pFileName in Dictionary </returns>
        Image ReturnImg(String pFileName);

        /// <summary>
        /// Returns Image using File Name as a key to the Dictionary
        /// </summary>
        /// <param name="pFileName"> UID to access Specific Image </param>
        /// <param name="pFrameWidth"> Width to change Image to </param>
        /// <param name="pFrameHeight"> Height to change Image to </param>
        /// <returns> Image stored via pFileName in Dictionary </returns>
        Image ReturnImg(String pFileName, int pFrameWidth, int pFrameHeight);

        #endregion
    }
}
