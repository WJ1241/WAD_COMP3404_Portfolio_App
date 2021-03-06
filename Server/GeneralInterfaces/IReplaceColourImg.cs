using Server.CustomEventArgs;
using System;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to replace a specified image with a different coloured version
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 25/03/22
    /// </summary>
    public interface IReplaceColourImg
    {
        #region METHODS

        /// <summary>
        /// Replaces an image with a new brightness change
        /// </summary>
        /// <param name="pUID"> Unique ID of Image </param>
        /// <param name="pImgWidth">the width (in pixels) of the desired image</param>
        /// <param name="pImgHeight">the height (in pixels) of the desired image</param>
        /// <param name="pBrt"> Brightness multiplier </param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        void ReplaceBrightnessImg(string pUID, int pImgWidth, int pImgHeight, int pBrt, EventHandler<ImageEventArgs> pImageEvent);

        /// <summary>
        /// Replaces an image with a new contrast change
        /// </summary>
        /// <param name="pUID"> Unique ID of Image </param>
        /// <param name="pImgWidth">the width (in pixels) of the desired image</param>
        /// <param name="pImgHeight">the height (in pixels) of the desired image</param>
        /// <param name="pCon"> Contrast multiplier </param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        void ReplaceContrastImg(string pUID, int pImgWidth, int pImgHeight, int pCon, EventHandler<ImageEventArgs> pImageEvent);

        /// <summary>
        /// Replaces an image with a new saturation change
        /// </summary>
        /// <param name="pUID"> Unique ID of Image </param>
        /// <param name="pImgWidth">the width (in pixels) of the desired image</param>
        /// <param name="pImgHeight">the height (in pixels) of the desired image</param>
        /// <param name="pSat"> Saturation multiplier </param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        void ReplaceSaturationImg(string pUID, int pImgWidth, int pImgHeight, int pSat, EventHandler<ImageEventArgs> pImageEvent);

        #endregion
    }
}
