using System.Drawing;
using Server.Exceptions;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;
using ImageProcessor;
using System;

namespace Server
{
    /// <summary>
    /// Class which edits Images, e.g. Rotation, H/V Flip, Scaling, Cropping, Filtering
    /// Author: Declan Kerby-Collins, William Eardley & William Smith 
    /// Date: 25/03/22
    /// </summary>
    /// <REFERENCE> Ricky's Tutorials (2017) C# TUTORIAL : Create an image filter and apply it to an image in 6 minutes. Available at: https://www.youtube.com/watch?v=SCSI8xEi4f4. (Accessed: 09 March 2022). </REFERENCE> 
    /// <REFERENCE> Sunday Notice (2019) Crop an Image: Code in C# Programming | How to make a Crop tool in a Photo Editor. Available at: https://www.youtube.com/watch?v=7IR6J8Kw8cE&t=176s. (Accessed: 31 March 2022). </REFERENCE>
    public class ImageEditor : IEditImg, IInitialiseParam<ImageFactory>
    {
        #region FIELD VARIABLES

        // DECLARE an ImageFactory, name it '_imgFactory':
        private ImageFactory _imgFactory;

        // DECLARE an Image, name it '_tempImage':
        private Image _tempImage;

        // DECLARE a Graphics, name it '_tempGraphics':
        private Graphics _tempGraphics;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of ImageEditor
        /// </summary>
        public ImageEditor()
        {
            // EMPTY CONSTRUCTOR
        }

        #endregion


        #region IMPLEMENTATION OF IEDITIMG

        #region ORIENTATION MANAGEMENT

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
        /// Flips Image horizontally
        /// </summary>
        /// <param name="pImage"> Image to be flipped horizontally </param>
        public void ImgHFlip(Image pImage)
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
        /// Flips Image vertically
        /// </summary>
        /// <param name="pImage"> Image to be flipped vertically </param>
        public void ImgVFlip(Image pImage)
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


        #region SIZE MANAGEMENT



        /// <summary>
        /// Crops the specified image and returns modification
        /// </summary>
        /// <param name="pFrame"> Frame for cropped image </param>
        /// <param name="pCropBox"> User cropped rectangle </param>
        /// <returns> Returns newly cropped image </returns>
        /// <CITATION> (Sunday Notice, 2019) </CITATION>
        public Image ImgCrop(Bitmap pFrame, Rectangle pCropBox)
        {
            // IF pFrame DOES NOT HAVE a valid instance:
            if (pFrame != null)
            {
                // TRY checking if instantiation of Bitmap() throws an ArgumentException
                try
                {
                    // DECLARE AND INSTANTIATE cropImg passing it pCropBox Width and Height:
                    Bitmap cropImg = new Bitmap(pCropBox.Width, pCropBox.Height);

                    // FOR loop iterates through the x of the drawn rectangle:
                    for (int x = 0; x < pCropBox.Width; x++)
                    {
                        // TRY checking if pFrame.GetPixel() throws an ArgumentOutOfRangeException:
                        try
                        {
                            // FOR loop iterates through the y of the drawn rectangle: 
                            for (int y = 0; y < pCropBox.Height; y++)
                            {
                                // DECLARE AND INSTANTIATE pxlColor and set it to the pFrame GetPixle passing in the pCropBox.X plus x and the pCropBox.Y plus y:
                                Color pxlColor = pFrame.GetPixel(pCropBox.X + x, pCropBox.Y + y);

                                // CALL cropImg's SetPixle passing in x, y & pxlColor:
                                cropImg.SetPixel(x, y, pxlColor);
                            }
                        }
                        // CATCH ArgumentOutOfRangeException from GetPixel():
                        catch (ArgumentOutOfRangeException e)
                        {
                            // WRITE error message to console:
                            Console.WriteLine(e.Message);
                        }
                    }

                    // RETURN instance of cropImg:
                    return cropImg;
                }
                // CATCH ArgumentException from Bitmap instantiation:
                catch (ArgumentException)
                {
                    // THROW a new ArgumentException(), explaining how to correct from error:
                    throw new ArgumentException("ERROR: You cannot crop with an axis value of '0', click 'Reset Image' to try again!");
                }
            }
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: No Image to be cropped!");
            }
        }

        #endregion


        #region COLOUR MANAGEMENT 

        /// <summary>
        /// Changes the brightness of a specified image
        /// </summary>
        /// <param name="pImage"> Image to be changed </param>
        /// <param name="pBrt"> Brightness value </param>
        public Image ImgBrightness(Image pImage, int pBrt)
        {
            // IF pImage DOES HAVE an active instance:
            if (pImage != null)
            {
                // CALL SetupImageFactory(), passing pImage as a parameter:
                SetupImageFactory(pImage);

                // SET brightness with_imgFactory using pBrt value:
                _imgFactory.Brightness(pBrt);

                // RETURN instance of _tempImage:
                return _imgFactory.Image;
            }
            // IF pImage DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: No Image to apply brightness change to!");
            }
        }

        /// <summary>
        /// Changes the contrast of a specified image
        /// </summary>
        /// <param name="pImage"> Image to be changed </param>
        /// <param name="pCon"> Contrast value </param>
        public Image ImgContrast(Image pImage, int pCon)
        {
            // IF pImage DOES HAVE an active instance:
            if (pImage != null)
            {
                // CALL SetupImageFactory(), passing pImage as a parameter:
                SetupImageFactory(pImage);

                // SET contrast with_imgFactory using pCon value:
                _imgFactory.Contrast(pCon);

                // RETURN instance of _tempImage:
                return _imgFactory.Image;
            }
            // IF pImage DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: No Image to apply contrast change to!");
            }
        }

        /// <summary>
        /// Changes the saturation of a specified image
        /// </summary>
        /// <param name="pImage"> Image to be changed </param>
        /// <param name="pSat"> Saturation value </param>
        public Image ImgSaturation(Image pImage, int pSat)
        {
            // IF pImage DOES HAVE an active instance:
            if (pImage != null)
            {
                // CALL SetupImageFactory(), passing pImage as a parameter:
                SetupImageFactory(pImage);

                // SET saturation with_imgFactory using pSat value:
                _imgFactory.Saturation(pSat);

                // RETURN instance of _tempImage:
                return _imgFactory.Image;
            }
            // IF pImage DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: No Image to apply saturation change to!");
            }
        }

        #endregion


        #region FILTERS

        /// <summary>
        /// Applies first filter to specified image
        /// </summary>
        /// <param name="pImage"> Image to be modified </param>
        /// <returns> Modified image </returns>
        /// <CITATION> (Ricky's Tutorials, 2017) </CITATION>
        public Image ImgFilterOne(Image pImage)
        {
            // IF pImage DOES HAVE an active instance:
            if (pImage != null)
            {
                // CALL SetupImage(), passing pImage as a parameter:
                SetupImage(pImage);

                // CALL SetupFilterGraphics():
                SetupFilterGraphics();

                // ADD Blue layer over _tempImage:
                _tempGraphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.DodgerBlue)), 0, 0, _tempImage.Width, _tempImage.Height);

                // RETURN instance of _tempImage:
                return _tempImage;
            }
            // IF pImage DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: No Image to apply blue filter to!");
            }
        }

        /// <summary>
        /// Applies second filter to specified image
        /// </summary>
        /// <param name="pImage"> Image to be modified </param>
        /// <returns> Modified image </returns>
        /// <CITATION> (Ricky's Tutorials, 2017) </CITATION>
        public Image ImgFilterTwo(Image pImage)
        {
            // IF pImage DOES HAVE an active instance:
            if (pImage != null)
            {
                // CALL SetupImage(), passing pImage as a parameter:
                SetupImage(pImage);

                // CALL SetupFilterGraphics():
                SetupFilterGraphics();

                // ADD Red layer over _tempImage:
                _tempGraphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)), 0, 0, _tempImage.Width, _tempImage.Height);

                // RETURN instance of _tempImage:
                return _tempImage;
            }
            // IF pImage DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: No Image to apply red filter to!");
            }
        }

        /// <summary>
        /// Applies third filter to specified image
        /// </summary>
        /// <param name="pImage"> Image to be modified </param>
        /// <returns> Modified image </returns>
        /// <CITATION> (Ricky's Tutorials, 2017) </CITATION>
        public Image ImgFilterThree(Image pImage)
        {
            // IF pImage DOES HAVE an active instance:
            if (pImage != null)
            {
                // CALL SetupImage(), passing pImage as a parameter:
                SetupImage(pImage);

                // CALL SetupFilterGraphics():
                SetupFilterGraphics();

                // ADD Purple layer over _tempImage:
                _tempGraphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.MediumPurple)), 0, 0, _tempImage.Width, _tempImage.Height);

                // RETURN instance of _tempImage:
                return _tempImage;
            }
            // IF pImage DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: No Image to apply purple filter to!");
            }
        }

        /// <summary>
        /// Applies fourth filter to specified image
        /// </summary>
        /// <param name="pImage"> Image to be modified </param>
        /// <returns> Modified image </returns>
        /// <CITATION> (Ricky's Tutorials, 2017) </CITATION>
        public Image ImgFilterFour(Image pImage)
        {
            // IF pImage DOES HAVE an active instance:
            if (pImage != null)
            {
                // CALL SetupImage(), passing pImage as a parameter:
                SetupImage(pImage);

                // CALL SetupFilterGraphics():
                SetupFilterGraphics();

                // ADD Grey layer over _tempImage:
                _tempGraphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.LightGray)), 0, 0, _tempImage.Width, _tempImage.Height);

                // RETURN instance of _tempImage:
                return _tempImage;
            }
            // IF pImage DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: No Image to apply grey filter to!");
            }
        }

        #endregion


        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IMAGEFACTORY>

        /// <summary>
        /// Initialises an object with an ImageFactory object
        /// </summary>
        /// <param name="pImgFactory"> ImageFactory object </param>
        public void Initialise(ImageFactory pImgFactory)
        {
            // IF pImgFactory DOES HAVE an active instance:
            if (pImgFactory != null)
            {
                // INITIALISE _imgFactory with reference to pImgFactory:
                _imgFactory = pImgFactory;
            }
            // IF pImgFactory DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pImgFactory does not have an active instance!");
            }
        }

        #endregion


        #region PRIVATE METHODS

        /// <summary>
        /// Sets up Image graphics for filter change
        /// </summary>
        private void SetupFilterGraphics()
        {
            // IF _tempGraphics DOES HAVE an active instance:
            if (_tempGraphics != null)
            {
                // DISPOSE of _tempGraphics, freeing resources:
                _tempGraphics.Dispose();
            }

            // INITIALISE _tempGraphics with return value of Graphics.FromImage(), passing _tempImage as a parameter:
            _tempGraphics = Graphics.FromImage(_tempImage);
        }

        /// <summary>
        /// Sets up temporary image
        /// </summary>
        /// <param name="pImage"> Image to be modified </param>
        private void SetupImage(Image pImage)
        {
            // IF _tempImage DOES HAVE an active instance:
            if (_tempImage != null)
            {
                // DISPOSE of _tempImage, freeing resources:
                _tempImage.Dispose();
            }

            // INSTANTIATE _tempImage as a new Bitmap(), passing pImage dimensions as parameters:
            _tempImage = new Bitmap(pImage);
        }

        /// <summary>
        /// Sets up ImageFactory API object
        /// </summary>
        /// <param name="pImage"> Image to be modified </param>
        private void SetupImageFactory(Image pImage)
        {
            // IF _imgFactory.Image DOES HAVE an active instance:
            if (_imgFactory.Image != null)
            {
                // DISPOSE of _imgFactory.Image:
                _imgFactory.Image.Dispose();
            }

            // LOAD pImage to be edited in _imgFactory:
            _imgFactory.Load(pImage);
        }

        #endregion
    }   
}
