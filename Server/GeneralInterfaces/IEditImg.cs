using System.Drawing;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to edit Images
    /// Author: William Smith
    /// Date: 26/11/21
    /// </summary>
    public interface IEditImg : IMarker
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

        #endregion
    }
}
