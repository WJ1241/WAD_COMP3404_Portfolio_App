using System.Drawing;
using Server.Exceptions;
using Server.GeneralInterfaces;

namespace Server
{
    /// <summary>
    /// Class which edits Images, e.g. Rotation, H/V Flip, Scaling, Cropping, Filtering
    /// Author: Declan Kerby-Collins, William Smith & William Eardley
    /// Date: 23/03/22
    /// </summary>
    /// <REFERENCE> Ricky's Tutorials (2017) C# TUTORIAL : Create an image filter and apply it to an image in 6 minutes. Available at: https://www.youtube.com/watch?v=SCSI8xEi4f4. (Accessed: 09 March 2022). </REFERENCE> 
    public class ImageEditor : IEditImg
    {
        #region FIELD VARIABLES

        // DECLARE TWO ints, name them '_red1' & '_red2':
        private int _red1, _red2;

        // DECLARE TWO ints, name them '_green1' & '_green2':
        private int _green1, _green2;

        // DECLARE TWO ints, name them '_blue1' & '_blue2':
        private int _blue1, _blue2;

        // DECLARE a Bitmap, name it '_newMap':
        private Bitmap _newMap;

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
        /// <param name="pImage"> Image to be changed </param>
        /// <returns> Returns newly cropped image </returns>
        public Image ImgCrop(Image pImage)
        {
            // IF pImage DOES NOT HAVE a valid Image instance:
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

        /// <summary>
        /// Resizes an image to what user specifies
        /// </summary>
        /// <param name="pImage"> Image to be changed </param>
        /// <returns> Returns newly scaled image </returns>
        public Image ImgScale(Image pImage)
        {
            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
               _newMap = new Bitmap(pImage);

                for (int x = 0; x < _newMap.Width; x++)
                {
                    for (int y = 0; y < _newMap.Height; y++)
                    {
                        //_newMap.Width = _newMap.Width * 2;
                       // _newMap.Height = _newMap.Height * 2;

                        _newMap.SetResolution(500, 500);
       
                    }
                }

                // SET '_tempImage' as '_newMap' value
                _tempImage = _newMap;

            }
            else
            {
                // THROW NEW NullInstanceException with apprpriate message
                throw new NullInstanceException("ERROR: No Image to be scaled!");
            }

            return _newMap;
        }

        #endregion


        #region COLOUR MANAGEMENT 

        /// <summary>
        /// METHOD 'BrightnessImg' - for controlling brightness
        /// </summary>
        /// <param name="pImage"></param>
        public Image ImgBrightness(Image pImage, float pBrt)
        {
            return null;

            // IF pImage is NOT NULL then call method
            if (pImage != null)
            {
                // DECLARE BitMap name it '_newMap':
                _newMap = new Bitmap(pImage);
                

                // FOR every pixle wide _newMap is incriment x:
                for (int x = 0; x < _newMap.Width; x++)
                {
                    // FOR every pixle deep _newMap is incriment y:
                    for (int y = 0; y < _newMap.Height; y++)
                    {
                        // DECLARE Color name it '_oldColour':
                        Color _oldColur = _newMap.GetPixel(x, y);

                        #region ASSIGN VAR COLORS
                        // DECLARE and ASSIGN int name it '_red1', it becomes _oldColour's R value:
                        _red1 = _oldColur.R;
                        
                        // DECLARE and ASSIGN int name it '_green1', it becomes _oldColour's G value:
                        _green1 = _oldColur.G;
                        
                        // DECLARE and ASSIGN int name it '_blue1', it becomes _oldColour's B value:
                        _blue1 = _oldColur.B;
                        #endregion


                        #region SET RGB COLOURS

                        // ASSIGNMENT _red2 is set to the value of _red1 * pBrt:
                        _red2 = (byte)(_red1 * pBrt);

                        // ASSIGNMENT _green2 is set to the value of _green1 * pBrt:
                        _green2 = (byte)(_green1 * pBrt);

                        // ASSIGNMENT _blue2 is set to the value of _blue2 * pBrt:
                        _blue2 = (byte)(_blue1 * pBrt);

                        #endregion 


                        #region KEEP COLORS BETWEEN 1 & 255
                        // IF _red2 less than or equel to 1 set value to 1:
                        if (_red2 <= 1)
                        {
                            // ASSIGNMENT _red2 is set to the value of 1
                            _red2 = 1;
                        }
                        // IF _red2 greater than or equel to 255 set value to 255:
                        if (_red2 >= 255)
                        {
                            // ASSIGNMENT _red2 is set to the value of 255
                            _red2 = 255;
                        }


                        // IF _green2 less than or equel to 1 set value to 1:
                        if (_green2 <= 1)
                        {
                            // ASSIGNMENT _green2 is set to the value of 1
                            _green2 = 1;
                        }
                        // IF _green2 greater than or equel to 255 set value to 255:
                        if (_green2 >= 255)
                        {
                            // ASSIGNMENT _green2 is set to the value of 255
                            _green2 = 255;
                        }


                        // IF _blue2 less than or equel to 1 set value to 1:
                        if (_blue2 <= 1)
                        {
                            // ASSIGNMENT _blue2 is set to the value of 1
                            _blue2 = 1;
                        }
                        // IF _blue2 greater than or equel to 255 set value to 255:
                        if (_blue2 >= 255)
                        {
                            // ASSIGNMENT _blue2 is set to the value of 255
                            _blue2 = 255;
                        }
                        #endregion


                        // SET the pixels of _newMap to the new argb values:
                        _newMap.SetPixel(x, y, Color.FromArgb(_red2, _green2, _blue2));


                    }
                }
                // ASSIGNMENT _tempImage is given the value of the _newMap:
                _tempImage = _newMap;
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
        public Image ImgContrast(Image pImage, int pSat)
        {
            return null;

            _newMap = new Bitmap(pImage);

            // FOR every pixle wide _newMap is incriment x:
            for (int x = 0; x < _newMap.Width; x++)
            {
                // FOR every pixle deep _newMap is incriment y:
                for (int y = 0; y < _newMap.Height; y++)
                {
                    // DECLARE Color name it '_oldColour':
                    Color _oldColur = _newMap.GetPixel(x, y);

                    #region VAR ASSIGNED RGB COLOURS
                    // DECLARE and ASSIGN int name it '_red1', it becomes _oldColour's R value:
                    int _red1 = _oldColur.R;
                    // DECLARE and ASSIGN int name it '_green1', it becomes _oldColour's G value:
                    int _green1 = _oldColur.G;
                    // DECLARE and ASSIGN int name it '_blue1', it becomes _oldColour's B value:
                    int _blue1 = _oldColur.B;
                    #endregion

                    #region ADJUSTING GREY LEVEL OF RGB
                    //test if brightness if over grey increase, if under grey decrease:

                    // IF _red1 is more than 128:
                    if (_red1 > 128)
                    {
                        // ASSIGNMENT _red2 is set to the value of _red1 plus pSat:
                        _red2 = _red1 + pSat;
                    }
                    else
                    {
                        // ASSIGNMENT _red2 is set to the value of _red1 minus pSat:
                        _red2 = _red1 - pSat;
                    }


                    // IF _green1 is less than 128:
                    if (_green1 > 128)
                    {
                        // ASSIGNMENT _green2 is set to the value of _green1 plus pSat:
                        _green2 = _green1 + pSat;
                    }
                    else
                    {
                        // ASSIGNMENT _green2 is set to the value of _green1 minus pSat:
                        _green2 = _green1 - pSat;
                    }


                    // IF _blue1 is more than 128:
                    if (_blue1 > 128)
                    {
                        // ASSIGNMENT _blue2 is set to the value of _blue1 plus pSat:
                        _blue2 = _blue1 + pSat;
                    }
                    else
                    {
                        // ASSIGNMENT _blue2 is set to the value of _blue1 plus pSat:
                        _blue2 = _blue1 - pSat;
                    }
                    #endregion

                    #region KEEP COLORS BETWEEN 1 & 255

                    // IF _red2 less than or equel to 1 set value to 1:
                    if (_red2 <= 1)
                    {
                        // ASSIGNMENT _red2 is set to the value of 1
                        _red2 = 1;
                    }
                    // IF _red2 greater than or equel to 255 set value to 255:
                    if (_red2 >= 255)
                    {
                        // ASSIGNMENT _red2 is set to the value of 255
                        _red2 = 255;
                    }


                    // IF _green2 less than or equel to 1 set value to 1:
                    if (_green2 <= 1)
                    {
                        // ASSIGNMENT _green2 is set to the value of 1
                        _green2 = 1;
                    }
                    // IF _green2 greater than or equel to 255 set value to 255:
                    if (_green2 >= 255)
                    {
                        // ASSIGNMENT _green2 is set to the value of 255
                        _green2 = 255;
                    }


                    // IF _blue2 less than or equel to 1 set value to 1:
                    if (_blue2 <= 1)
                    {
                        // ASSIGNMENT _blue2 is set to the value of 1
                        _blue2 = 1;
                    }
                    // IF _blue2 greater than or equel to 255 set value to 255:
                    if (_blue2 >= 255)
                    {
                        // ASSIGNMENT _blue2 is set to the value of 255
                        _blue2 = 255;
                    }
                    #endregion

                    // SET the pixels of _newMap to the new argb values:
                    Color _newColor = Color.FromArgb((int)_red2, (int)_green2, (int)_blue2);

                    // SET the pixels of _newMap to the new argb values:
                    _newMap.SetPixel(x, y, _newColor);


                }
            }

            // ASSIGNMENT _tempImage is given the value of the _newMap:
            _tempImage = _newMap;



        }

        /// <summary>
        /// METHOD 'SaturationImg' - for controlling saturation
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pSat"></param>
        public Image ImgSaturation(Image pImage, int pSat)
        {
            return null;

            // IF pImage is NOT NULL then call method:
            if (pImage != null)
            {
                // ASSIGNMENT _newMap is set to the value of pImage:
                _newMap = new Bitmap(pImage);

                // ASSISGNMENT pSat has its value inverted:
                pSat = pSat *= -1;


                #region GET &  SET  PIXLE COLOURS
                // FOR every pixle wide _newMap is incriment x:
                for (int x = 0; x < _newMap.Width; x++)
                {
                    // FOR every pixle deep _newMap is incriment y:
                    for (int y = 0; y < _newMap.Height; y++)
                    {
                        // DECLARE Color name it '_oldColour':
                        Color _oldColur = _newMap.GetPixel(x, y);


                        #region ASSIGN VAR COLORS
                        // DECLARE and ASSIGN int name it '_red1', it becomes _oldColour's R value:
                        _red1 = _oldColur.R;
                        // DECLARE and ASSIGN int name it '_green1', it becomes _oldColour's G value:
                        _green1 = _oldColur.G;
                        // DECLARE and ASSIGN int name it '_blue1', it becomes _oldColour's B value:
                        _blue1 = _oldColur.B;
                        #endregion

                        #region FIND COLOR GAPS
                        // DECLARE calculate the gap between _red1 and _blue1 and name that gap '_rBGap':
                        int _rBGap = _red1 - _blue1;
                        // DECLARE calculate the gap between _red1 and _green1 and name that gap '_rGGap':
                        int _rGGap = _red1 - _green1;

                        // DECLARE calculate the gap between _green1 and _red1 and name that gap '_gRGap':
                        int _gRGap = _green1 - _red1;
                        // DECLARE calculate the gap between _green1 and _blue1 and name that gap '_gBGap':
                        int _gBGap = _green1 - _blue1;

                        // DECLARE calculate the gap between _blue1 and _green1 and name that gap '_bGGap':
                        int _bGGap = _blue1 - _green1;
                        // DECLARE calculate the gap between _blue1 and _red1 and name that gap '_bRGap':
                        int _bRGap = _blue1 - _red1;
                        #endregion

                        #region ASSIGN RED
                        // IF _red1 is greater than _blue1 & _green1:
                        if (_red1 > _blue1 && _red1 > _green1)
                        {
                            // ASSIGNMENT _red2 is given the value of _red1:
                            _red2 = _red1;

                            // ASSIGNMENT _blue2 to the value of _blue1 plus  the gap between red and blue and multiply that by the pSat:
                            _blue2 = _blue1 + (_rBGap * pSat);

                            // ASSIGNMENT _green2 to the value of _green1 plus  the gap between red and green and multiply that by the pSat:
                            _green2 = _green1 + (_rGGap * pSat);
                        }
                        // ELSE IF _red1 is equel to _blue1
                        else if (_red1 == _blue1)
                        {
                            // ASSIGNMENT _red2 is given the value of _red1:
                            _red2 = _red1;

                            // ASSIGNMENT _blue2 is given the value of _blue1:
                            _blue2 = _blue1;

                            // ASSIGNMENT _green2 to the value of _green1 plus  the gap between red and green and multiply that by the pSat:
                            _green2 = _green1 + (_rGGap * pSat);
                        }
                        // ELSE IF _red1 is equel to _green1
                        else if (_red1 == _green1)
                        {
                            // ASSIGNMENT _red2 is given the value of _red1:
                            _red2 = _red1;

                            // ASSIGNMENT _green2 is given the value of _green1:
                            _green2 = _green1;

                            // ASSIGNMENT _blue2 to the value of _blue1 plus  the gap between red and blue and multiply that by the pSat:
                            _blue2 = _blue1 + (_rBGap * pSat);
                        }
                        // ELSE IF _red1 is equel to _green1 and _green1
                        else if (_red1 == _blue1 && _red1 == _green1)
                        {
                            // ASSIGNMENT _red2 is given the value of _red1:
                            _red2 = _red1;

                            // ASSIGNMENT _blue2 is given the value of _blue1:
                            _blue2 = _blue1;

                            // ASSIGNMENT _green2 is given the value of _green1:
                            _green2 = _green1;
                        }
                        #endregion

                        #region ASSIGN GREEN
                        // IF _green1 is greater than _blue1 & _red1:
                        if (_green1 > _blue1 && _green1 > _red1)
                        {
                            // ASSIGNMENT _green2 is given the value of _green1:
                            _green2 = _green1;

                            // ASSIGNMENT _red2 to the value of _red1 plus  the gap between red and green and multiply that by the pSat:
                            _red2 = _red1 + (_gRGap * pSat);

                            // ASSIGNMENT _blue2 to the value of _blue1 plus  the gap between green and blue and multiply that by the pSat:
                            _blue2 = _blue1 + (_gBGap * pSat);
                        }
                        // ELSE IF _green1 is equel to _blue1:
                        else if (_green1 == _blue1)
                        {
                            // ASSIGNMENT _red2 to the value of _red1 plus  the gap between red and green and multiply that by the pSat:
                            _red2 = _red1 + (_gRGap * pSat);

                            // ASSIGNMENT _green2 is given the value of _green1:
                            _green2 = _green1;

                            // ASSIGNMENT _blue2 is given the value of _blue1:
                            _blue2 = _blue1;
                        }
                        // ELSE IF _green1 is equel to _red1:
                        else if (_green1 == _red1)
                        {
                            // ASSIGNMENT _red2 is given the value of _red1:
                            _red2 = _red1;

                            // ASSIGNMENT _green2 is given the value of _green1:
                            _green2 = _green1;

                            // ASSIGNMENT _blue2 to the value of _blue1 plus  the gap between green and blue and multiply that by the pSat:
                            _blue2 = _blue1 + (_gBGap * pSat);
                        }
                        // ELSE IF _green1 is equel to _red1 & _blue1:
                        else if (_green1 == _blue1 && _green1 == _red1)
                        {
                            // ASSIGNMENT _red2 is given the value of _red1:
                            _red2 = _red1;

                            // ASSIGNMENT _blue2 is given the value of _blue1:
                            _blue2 = _blue1;

                            // ASSIGNMENT _green2 is given the value of _green1:
                            _green2 = _green1;
                        }
                        #endregion

                        #region ASSIGN BLUE
                        // IF _blue1 is greater than _green1 & _red1:
                        if (_blue1 > _red1 && _blue1 > _green1)
                        {
                            // ASSIGNMENT _blue2 is given the value of _blue1:
                            _blue2 = _blue1;

                            // ASSIGNMENT _red2 to the value of _red1 plus  the gap between red and blue and multiply that by the pSat:
                            _red2 = _red1 + (_bRGap * pSat);

                            // ASSIGNMENT _green2 to the value of _green1 plus  the gap between blue and green and multiply that by the pSat:
                            _green2 = _green1 + (_bGGap * pSat);

                        }
                        // ELSE IF _blue1 is equel to _red1:
                        else if (_blue1 == _red1)
                        {
                            // ASSIGNMENT _red2 is given the value of _red1:
                            _red2 = _red1;

                            // ASSIGNMENT _blue2 is given the value of _blue1:
                            _blue2 = _blue1;

                            // ASSIGNMENT _green2 to the value of _green1 plus  the gap between blue and green and multiply that by the pSat:
                            _green2 = _green1 + (_bGGap * pSat);

                        }
                        // ELSE IF _blue1 is equel to _green1:
                        else if (_blue1 == _green1)
                        {
                            // ASSIGNMENT _red2 to the value of _red1 plus  the gap between red and blue and multiply that by the pSat:
                            _red2 = _red1 + (_bRGap * pSat);

                            // ASSIGNMENT _green2 is given the value of _green1:
                            _green2 = _green1;

                            // ASSIGNMENT _blue2 is given the value of _blue1:
                            _blue2 = _blue1;
                        }
                        // ELSE IF _blue1 is equel to _green1 & _blue1:
                        else if (_blue1 == _red1 && _blue1 == _green1)
                        {
                            // ASSIGNMENT _red2 is given the value of _red1:
                            _red2 = _red1;

                            // ASSIGNMENT _blue2 is given the value of _blue1:
                            _blue2 = _blue1;

                            // ASSIGNMENT _green2 is given the value of _green1:
                            _green2 = _green1;
                        }
                        #endregion

                        #region KEEP COLORS BETWEEN 1 & 255

                        // IF _red2 less than or equel to 1 set value to 1:
                        if (_red2 <= 1)
                        {
                            // ASSIGNMENT _red2 is set to the value of 1
                            _red2 = 1;
                        }
                        // IF _red2 greater than or equel to 255 set value to 255:
                        if (_red2 >= 255)
                        {
                            // ASSIGNMENT _red2 is set to the value of 255
                            _red2 = 255;
                        }


                        // IF _green2 less than or equel to 1 set value to 1:
                        if (_green2 <= 1)
                        {
                            // ASSIGNMENT _green2 is set to the value of 1
                            _green2 = 1;
                        }
                        // IF _green2 greater than or equel to 255 set value to 255:
                        if (_green2 >= 255)
                        {
                            // ASSIGNMENT _green2 is set to the value of 255
                            _green2 = 255;
                        }


                        // IF _blue2 less than or equel to 1 set value to 1:
                        if (_blue2 <= 1)
                        {
                            // ASSIGNMENT _blue2 is set to the value of 1
                            _blue2 = 1;
                        }
                        // IF _blue2 greater than or equel to 255 set value to 255:
                        if (_blue2 >= 255)
                        {
                            // ASSIGNMENT _blue2 is set to the value of 255
                            _blue2 = 255;
                        }
                        #endregion


                        // SET the pixels of _newMap to the new argb values:
                        _newMap.SetPixel(x, y, Color.FromArgb(_red2, _green2, _blue2));
                    }
                }
                #endregion

                // ASSIGNMENT _tempImage is given the value of the _newMap:
                _tempImage = _newMap;
            }
            else
            {
                // THROW NEW NullInstanceException with appropriate message
                throw new NullInstanceException("ERROR: No Image to increase saturation of!");
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
                // CALL SetupFilterGraphics(), passing pImage as a parameter:
                SetupFilterGraphics(pImage);

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
                // CALL SetupFilterGraphics(), passing pImage as a parameter:
                SetupFilterGraphics(pImage);

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
                // CALL SetupFilterGraphics(), passing pImage as a parameter:
                SetupFilterGraphics(pImage);

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
                // CALL SetupFilterGraphics(), passing pImage as a parameter:
                SetupFilterGraphics(pImage);

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


        #region PRIVATE METHODS

        /// <summary>
        /// Setups Image graphics for filter change
        /// </summary>
        /// <param name="pImage"> Image to be modified </param>
        private void SetupFilterGraphics(Image pImage)
        {
            // IF _tempImage DOES HAVE an active instance:
            if (_tempImage != null)
            {
                // DISPOSE of _tempImage, freeing resources:
                _tempImage.Dispose();
            }

            // IF _tempGraphics DOES HAVE an active instance:
            if (_tempGraphics != null)
            {
                // DISPOSE of _tempGraphics, freeing resources:
                _tempGraphics.Dispose();
            }

            // INSTANTIATE _tempImage as a new Bitmap(), passing pImage dimensions as parameters:
            _tempImage = new Bitmap(pImage);

            // INITIALISE _tempGraphics with return value of Graphics.FromImage(), passing _tempImage as a parameter:
            _tempGraphics = Graphics.FromImage(_tempImage);
        }

        #endregion
    }
}
