using System.Drawing;
using Server.Exceptions;
using Server.GeneralInterfaces;

namespace Server
{
    /// <summary>
    /// Class which edits Images, e.g. Rotation, H/V Flip, Scaling, Cropping, Filtering
    /// Author: William Eardley, William Smith
    /// Date: 11/02/22
    /// </summary>
    public class ImageEditor : IEditImg
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of ImageEditor
        /// </summary>
        public ImageEditor()
        {

        }

        #endregion


        #region IMPLEMENTATION OF IEDITIMG

        #region Orientation
        /// <summary>
        /// Rotates Image 90 degrees clockwise
        /// </summary>
        /// <param name="pImage"> Image to be rotated clockwise </param>
        public void ImgRotateClockwise(Image pImage)
        {
            // IF pImage DOES HAVE a valid Image instance:
            if (pImage != null)
            {
                // ROTATE pImage 90 degrees clockwise:
                pImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            //IF pImage DOES NOT HAVE a valid Image instance:
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: No Image to be rotated!");
            }
        }

        /// <summary>
        /// Rotates Image 90 degrees anticlockwise
        /// </summary>
        /// <param name="pImage"> Image to be rotated anticlockwise </param>
        public void ImgRotateAntiClockwise(Image pImage)
        {
            // IF pImage DOES HAVE a valid Image instance:
            if (pImage != null)
            {
                // ROTATE pImage 90 degrees anticlockwise:
                pImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            }
            //IF pImage DOES NOT HAVE a valid Image instance:
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: No Image to be rotated!");
            }
        }

        /// <summary>
        /// Flips Image on the X axis
        /// </summary>
        /// <param name="pImage"> Image to be flipped on the X axis </param>
        public void ImgFlipXAxis(Image pImage)
        {
            // IF pImage DOES HAVE a valid Image instance:
            if (pImage != null)
            {
                // ROTATE pImage on the X axis:
                pImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            //IF pImage DOES NOT HAVE a valid Image instance:
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: No Image to be flipped on the X axis!");
            }
        }

        /// <summary>
        /// Flips Image on the Y axis
        /// </summary>
        /// <param name="pImage"> Image to be flipped on the Y axis </param>
        public void ImgFlipYAxis(Image pImage)
        {
            // IF pImage DOES HAVE a valid Image instance:
            if (pImage != null)
            {
                // ROTATE pImage on the Y axis:
                pImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }
            //IF pImage DOES NOT HAVE a valid Image instance:
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: No Image to be flipped on the Y axis!");
            }
        }
        #endregion


        #region Scale/Crop
        /// <summary>
        /// METHOD 'ScaleImg' - for scaling image
        /// </summary>
        /// <param name="pImage"></param>
        public void ScaleImg(Image pImage)
        {
            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
                // CALL Scale method for image
                // pImage.Scale()
            }
            else
            {
                // THROW NEW NullInstanceException with apprpriate message
                throw new NullInstanceException("ERROR: No Image to be scaled!");
            }
        }

        /// <summary>
        /// Crops image 
        /// </summary>
        /// <param name="pImage"></param>
        /// <returns></returns>
        public Image CropImg(Image pImage)
        {
            // IF pImage DOESNT HAVE a valid Image instance:
            if (pImage != null)
            {
                //new temp bitmap name it _bitmap
                Bitmap _bitmap = new Bitmap(pImage.Width, pImage.Height);

                //new temp rectangle name it _rect
                Rectangle _retc = new Rectangle();

                //using Graphics from image take set the value of _bitmap to the size of the rectangle set by the user
                using (Graphics _graphics = Graphics.FromImage(_bitmap))
                {
                    _graphics.DrawImage(pImage, -_retc.X, -_retc.Y);

                    //return the edited _bitmap 
                    return _bitmap;
                }
            }
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: No Image to be cropped!");
            }
        }
        #endregion


        #region Brightness/Contrast/Saturation
        /// <summary>
        /// METHOD 'BrightnessImg' - for controlling brightness
        /// </summary>
        /// <param name="pImage"></param>
        public void BrightnessImg(Image pImage)
        {
            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
                // CALL Brightness method for image
            }
            else
            {
                // THROW NEW NullInstanceException with appropriate message
                throw new NullInstanceException("ERROR: No Image to increase brightness of!");
            }
        }

        /// <summary>
        /// METHOD 'ContrastImg' - for controlling contrast
        /// </summary>
        /// <param name="pImage"></param>
        public void ContrastImg(Image pImage)
        {
            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
                // CALL Contrast method for image

            }
            else
            {
                // THROW NEW NullInstanceException with appropriate message
                throw new NullInstanceException("ERROR: No Image to increase contrast of!");
            }
        }

        /// <summary>
        /// METHOD 'SaturationImg' - for controlling saturation
        /// </summary>
        /// <param name="pImage"></param>
        public void SaturationImg(Image pImage)
        {
            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
                // CALL Saturation method for image
            }
            else
            {
                // THROW NEW NullInstanceException with appropriate message
                throw new NullInstanceException("ERROR: No Image to increase saturation of!");
            }
         }
        #endregion


        #region Filters
        /// <summary>
        /// METHOD 'FilterOneImg' - for applying first filter
        /// </summary>
        /// <param name="pImage"></param>
        public void FilterOneImg(Image pImage)
        {
            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
                // CALL Filter One method for image
            }
            else
            {
                // THROW NEW NullInstanceException with appropriate message
                throw new NullInstanceException("ERROR: No Image to apply filter to!");
            }
        }

        /// <summary>
        /// METHOD 'FilterTwoImg' - for applying second filter
        /// </summary>
        /// <param name="pImage"></param>
        public void FilterTwoImg(Image pImage)
        {
            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
                // CALL Filter Two method for image
            }
            else
            {
                // THROW NEW NullInstanceException with appropriate message
                throw new NullInstanceException("ERROR: No Image to apply filter to!");
            }
        }

        /// <summary>
        /// METHOD 'FilterThreeImg' - for applying third filter
        /// </summary>
        /// <param name="pImage"></param>
        public void FilterThreeImg(Image pImage)
        {
            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
                // CALL Filter Three method for image
            }
            else
            {
                // THROW NEW NullInstanceException with appropriate message
                throw new NullInstanceException("ERROR: No Image to apply filter to!");
            }
         }

        /// <summary>
        /// METHOD 'FilterFourImg' - for applying fourth filter
        /// </summary>
        /// <param name="pImage"></param>
        public void FilterFourImg(Image pImage)
        {
            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
                // CALL Filter Four method for image
            }
            else
            {
                // THROW NEW NullInstanceException with appropriate message
                throw new NullInstanceException("ERROR: No Image to apply filter to!");
            }
        }
        #endregion

       
        #endregion
    }
}
