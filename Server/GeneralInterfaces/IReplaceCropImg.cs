using System;
using System.Drawing;
using Server.CustomEventArgs;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to replace an image with a newly cropped one
    /// Authors: Declan Kerby-Collins, William Eardley & William Smith
    /// Date: 25/03/22
    /// </summary>
    public interface IReplaceCropImg
    {
        #region METHODS

        /// <summary>
        /// Replaces an image with a crop change
        /// </summary>
        /// <param name="pFrame"> Frame for cropped image </param>
        /// <param name="pCropBox"> User cropped rectangle </param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        void ReplaceCropImg(Bitmap pFrame, Rectangle pCropBox, EventHandler<ImageEventArgs> pImageEvent);

        #endregion
    }
}
