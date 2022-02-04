﻿using System.Drawing;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to edit Images
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public interface IEditImg : IService
    {
        #region METHODS

        /// <summary>
        /// Rotates Image 90 degrees clockwise
        /// </summary>
        /// <param name="pImage"> Image to be rotated clockwise </param>=
        void ImgRotateClockwise(Image pImage);

        /// <summary>
        /// Rotates Image 90 degrees anticlockwise
        /// </summary>
        /// <param name="pImage"> Image to be rotated anticlockwise </param>=
        void ImgRotateAntiClockwise(Image pImage);

        /// <summary>
        /// Flips Image on the X axis
        /// </summary>
        /// <param name="pImage"> Image to be flipped on the X axis </param>=
        void ImgFlipXAxis(Image pImage);

        /// <summary>
        /// Flips Image on the Y axis
        /// </summary>
        /// <param name="pImage"> Image to be flipped on the Y axis </param>=
        void ImgFlipYAxis(Image pImage);

        /// <summary>
        /// Crop the image
        /// </summary>
        /// <param name="pImage"></param> image to be cropped
        /// <returns> returns the cropped image </returns>
        Image CropImg(Image pImage);





        #endregion
    }
}
