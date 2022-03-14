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

        #region FIELDS

        // DECLARE an int name it '_red1':
        private int _red1;

        // DECLARE an int name it '_green1':
        private int _green1;

        // DECLARE an int name it '_blue1':
        private int _blue1;

        // DECLARE an int name it '_red2':
        private int _red2;

        // DECLARE an int name it '_green2':
        private int _green2;

        // DECLARE an int name it '_blue2':
        private int _blue2;

        // DECLARE a Bitmap name it '_newMap':
        private Bitmap _newMap;

        // DECLARE an Image name it '_tempImage':
        private Image _tempImage;

        #endregion


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
        public void ContrastImg(Image pImage, int pSat)
        {
            // ASSIGNMENT _newMap is set to the value of pImage
            _newMap = new Bitmap(pImage);

            // FOR every pixle wide _newMap is incriment x:
            for (int x = 0; x < _newMap.Width; x++)
            {
                // FOR every pixle deep _newMap is incriment y:
                for (int y = 0; y < _newMap.Height; y++)
                {
                    // DECLARE Color name it '_oldColour':
                    Color _oldColur = _newMap.GetPixel(x, y);

                    // DECLARE and ASSIGN int name it '_red1', it becomes _oldColour's R value:
                    _red1 = _oldColur.R;
                    // DECLARE and ASSIGN int name it '_green1', it becomes _oldColour's G value:
                    _green1 = _oldColur.G;
                    // DECLARE and ASSIGN int name it '_blue1', it becomes _oldColour's B value:
                    _blue1 = _oldColur.B;

                    // ASSIGNMENT _red2 is set to the value of red1 multiplied by pSat:
                    _red2 = (byte)(_red1 * pSat);

                    // ASSIGNMENT _green2 is set to the value of _green1 multiplied by pSat:
                    _green2 = (byte)(_green1 * pSat);

                    // ASSIGNMENT _blue2 is set to the value of _blue1 multiplied by pSat:
                    _blue2 = (byte)(_blue1 * pSat);


                    if (_red2 <= 1)
                    {
                        _red2 = 1;
                    }
                    if (_red2 >= 255)
                    {
                        _red2 = 255;
                    }

                    //_red2 = (byte)_red1 * _sat;

                    if (_green2 <= 1)
                    {
                        _green2 = 1;
                    }
                    if (_green2 >= 255)
                    {
                        _green2 = 255;
                    }


                    //_green2 = (byte)_green2 * _sat;

                    if (_blue2 <= 1)
                    {
                        _blue2 = 1;
                    }
                    if (_blue2 >= 255)
                    {
                        _blue2 = 255;
                    }

                    // SET the pixels of _newMap to the new argb values:
                    _newMap.SetPixel(x, y, Color.FromArgb(_red2, _green2, _blue2));


                }
            }

            _tempImage = _newMap;
        }


        /// <summary>
        /// METHOD 'SaturationImg' - for controlling saturation
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pSat"></param>
        public void SaturationImg(Image pImage, int pSat)
        {
            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
                

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
