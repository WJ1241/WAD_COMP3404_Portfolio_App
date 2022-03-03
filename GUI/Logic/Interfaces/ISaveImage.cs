using System.Drawing;

namespace GUI.Logic.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to Save Image to client's device
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public interface ISaveImage : ILogic
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
