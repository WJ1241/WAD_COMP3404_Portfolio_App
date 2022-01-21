using System.Drawing;
using Server.GeneralInterfaces;

namespace GUI.Logic
{
    /// <summary>
    /// Interface which allows implementations to Save Image to client's device
    /// Author: William Smith
    /// Date: 26/11/21
    /// </summary>
    public interface ISaveImage : IMarker
    {
        #region METHODS

        /// <summary>
        /// Saves Image, Gives user choice of where to store
        /// </summary>
        /// <param name="pImage"> Image currently displayed on screen </param>
        void SaveImage(Image pImage);

        #endregion
    }
}
