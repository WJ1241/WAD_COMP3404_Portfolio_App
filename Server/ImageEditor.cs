using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Server.Exceptions;
using Server.GeneralInterfaces;

namespace Server
{
    /// <summary>
    /// Class which edits Images, e.g. Rotation, H/V Flip, Scaling, Cropping, Filtering
    /// Author: William Eardley, William Smith, Declan Kerby-Collins
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
            /*
            int _threshold = sliderPosition;
            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
                // CALL Contrast method for image
                Bitmap _tempMap = new Bitmap(pImage);

                //// coppied code do NOT FOR GET TO AMEND 
                BitmapData sourceData = _tempMap.LockBits(new Rectangle(0, 0,
                                _tempMap.Width, _tempMap.Height),
                                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


                byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];


                Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);


                _tempMap.UnlockBits(sourceData);


                double contrastLevel = Math.Pow((100.0 + threshold) / 100.0, 2);


                double blue = 0;
                double green = 0;
                double red = 0;


                for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
                {
                    blue = ((((pixelBuffer[k] / 255.0) - 0.5) *
                                contrastLevel) + 0.5) * 255.0;


                    green = ((((pixelBuffer[k + 1] / 255.0) - 0.5) *
                                contrastLevel) + 0.5) * 255.0;


                    red = ((((pixelBuffer[k + 2] / 255.0) - 0.5) *
                                contrastLevel) + 0.5) * 255.0;


                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }


                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }


                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }


                    pixelBuffer[k] = (byte)blue;
                    pixelBuffer[k + 1] = (byte)green;
                    pixelBuffer[k + 2] = (byte)red;
                }


                Bitmap resultBitmap = new Bitmap(_tempMap.Width, _tempMap.Height);


                BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                            resultBitmap.Width, resultBitmap.Height),
                                            ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


                Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
                resultBitmap.UnlockBits(resultData);
                ////END OF COPPIED CODE

            }
            else
            {
                // THROW NEW NullInstanceException with appropriate message
                throw new NullInstanceException("ERROR: No Image to increase contrast of!");
            }

            */
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
        /// <REFERENCE> Ricky's Tutorials (2017) C# TUTORIAL : Create an image filter and apply it to an image in 6 minutes. Available at: https://www.youtube.com/watch?v=SCSI8xEi4f4. (Accessed: 09 March 2022). </REFERENCE> 

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

                // DECLAR local Bitmap name it '_displayedImg'
                Bitmap _displayedImg = new Bitmap(pImage.Width, pImage.Height);

                // DECLAR local Bitmap name it '_imgGraphics'
                Graphics _imgGraphics = Graphics.FromImage(_displayedImg);

                // ASSIGNMENT sets the _imgGraphics drawImage to the pImage
                _imgGraphics.DrawImage(pImage, 0, 0);

                // ASSIGNMENT makes image light blue
                _imgGraphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.DodgerBlue)), 0, 0, _displayedImg.Width, _displayedImg.Height);


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

                // DECLAR local Bitmap name it '_displayedImg'
                Bitmap _displayedImg = new Bitmap(pImage.Width, pImage.Height);

                // DECLAR local Bitmap name it '_imgGraphics'
                Graphics _imgGraphics = Graphics.FromImage(_displayedImg);

                // ASSIGNMENT sets the _imgGraphics drawImage to the pImage
                _imgGraphics.DrawImage(pImage, 0, 0);

                // ASSIGNMENT makes image Red
                _imgGraphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)), 0, 0, _displayedImg.Width, _displayedImg.Height);
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

                // DECLAR local Bitmap name it '_displayedImg'
                Bitmap _displayedImg = new Bitmap(pImage.Width, pImage.Height);

                // DECLAR local Bitmap name it '_imgGraphics'
                Graphics _imgGraphics = Graphics.FromImage(_displayedImg);

                // ASSIGNMENT sets the _imgGraphics drawImage to the pImage
                _imgGraphics.DrawImage(pImage, 0, 0);

                // ASSIGNMENT makes image light MediumPurple
                _imgGraphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.MediumPurple)), 0, 0, _displayedImg.Width, _displayedImg.Height);
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

                // DECLAR local Bitmap name it '_displayedImg'
                Bitmap _displayedImg = new Bitmap(pImage.Width, pImage.Height);

                // DECLAR local Bitmap name it '_imgGraphics'
                Graphics _imgGraphics = Graphics.FromImage(_displayedImg);

                // ASSIGNMENT sets the _imgGraphics drawImage to the pImage
                _imgGraphics.DrawImage(pImage, 0, 0);

                // ASSIGNMENT makes image light LightGray
                _imgGraphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.LightGray)), 0, 0, _displayedImg.Width, _displayedImg.Height);
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
