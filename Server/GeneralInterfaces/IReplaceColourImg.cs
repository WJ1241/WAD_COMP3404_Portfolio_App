using System.Drawing;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to replace a specified image with a different coloured version
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 24/03/22
    /// </summary>
    public interface IReplaceColourImg
    {
        #region METHODS

        /// <summary>
        /// Change the Brightness of a specified image
        /// </summary>
        /// <param name="pUID"> Unique ID of Image </param>
        /// <param name="pBrt"> Brightness multiplier </param>
        void ReplaceBrightnessImg(string pUID, float pBrt);

        /// <summary>
        /// Change the Contrast of a specified image
        /// </summary>
        /// <param name="pUID"> Unique ID of Image </param>
        /// <param name="pCon"> Contrast multiplier </param>
        void ReplaceContrastImg(string pUID, float pCon);

        /// <summary>
        /// Change the Saturation of a specified image
        /// </summary>
        /// <param name="pUID"> Unique ID of Image </param>
        /// <param name="pSat"> Saturation multiplier </param>
        void ReplaceSaturationImg(string pUID, int pSat);

        #endregion
    }
}
