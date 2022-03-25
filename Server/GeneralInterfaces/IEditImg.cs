using System.Drawing;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to edit Images
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 25/03/22
    /// </summary>
    public interface IEditImg : IService
    {
        #region METHODS

        #region ORIENTATION

        /// <summary>
        /// Rotates Image 90 degrees clockwise
        /// </summary>
        /// <param name="pImage"> Image to be rotated clockwise </param>
        void ImgRotateClockwise(Image pImage);

        /// <summary>
        /// Rotates Image 90 degrees anticlockwise
        /// </summary>
        /// <param name="pImage"> Image to be rotated anticlockwise </param>
        void ImgRotateAntiClockwise(Image pImage);

        /// <summary>
        /// Flips Image horizontally
        /// </summary>
        /// <param name="pImage"> Image to be flipped horizontally </param>
        void ImgHFlip(Image pImage);

        /// <summary>
        /// Flips Image vertically
        /// </summary>
        /// <param name="pImage"> Image to be flipped vertically </param>
        void ImgVFlip(Image pImage);

        #endregion


        #region SIZE

        /// <summary>
        /// Crops the specified image and returns modification
        /// </summary>
        /// <param name="pImage"> Image to be changed </param>
        /// <returns> Returns newly cropped image </returns>
        Image ImgCrop(Image pImage);

        /// <summary>
        /// Resizes an image to what user specifies
        /// </summary>
        /// <param name="pImage"> Image to be changed </param>
        /// <returns> Returns newly scaled image </returns>
        Image ImgScale(Image pImage);

        #endregion


        #region COLOUR

        /// <summary>
        /// Changes the brightness of a specified image
        /// </summary>
        /// <param name="pImage"> Image to be changed </param>
        /// <param name="pBrt"> Brightness value </param>
        Image ImgBrightness(Image pImage, int pBrt);

        /// <summary>
        /// Changes the contrast of a specified image
        /// </summary>
        /// <param name="pImage"> Image to be changed </param>
        /// <param name="pCon"> Contrast value </param>
        Image ImgContrast(Image pImage, int pCon);

        /// <summary>
        /// Changes the saturation of a specified image
        /// </summary>
        /// <param name="pImage"> Image to be changed </param>
        /// <param name="pSat"> Saturation value </param>
        Image ImgSaturation(Image pImage, int pSat);

        #endregion


        #region FILTERS

        /// <summary>
        /// Applies first filter to specified image
        /// </summary>
        /// <param name="pImage"> Image to be modified </param>
        /// <returns> Modified image </returns>
        Image ImgFilterOne(Image pImage);

        /// <summary>
        /// Applies second filter to specified image
        /// </summary>
        /// <param name="pImage"> Image to be modified </param>
        /// <returns> Modified image </returns>
        Image ImgFilterTwo(Image pImage);

        /// <summary>
        /// Applies third filter to specified image
        /// </summary>
        /// <param name="pImage"> Image to be modified </param>
        /// <returns> Modified image </returns>
        Image ImgFilterThree(Image pImage);

        /// <summary>
        /// Applies fourth filter to specified image
        /// </summary>
        /// <param name="pImage"> Image to be modified </param>
        /// <returns> Modified image </returns>
        Image ImgFilterFour(Image pImage);

        #endregion

        #endregion
    }
}
