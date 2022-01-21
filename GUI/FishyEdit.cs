using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GUI.InitialisingInterfaces;
using GUI.Logic;
using Server.Delegates;
using Server.Exceptions;

namespace GUI
{
    /// <summary>
    /// Partial Class which creates a 'FishyEdit' for the user to edit Images with.
    /// Author: William Eardley, William Smith & Marc Price, Declan Kerby-Collins
    /// Date: 21/01/22
    /// </summary>
    /// <REFERENCE> Price, M. (2007) 'Moveable Form Code Snippet'. Available at: https://worcesterbb.blackboard.com/. (Accessed: 5 November 2021). </REFERENCE>
    /// <REFERENCE> jay_t55 (2014) Make a borderless form movable? Available at: https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable/24561946#24561946. (Accessed 5 November 2021). </REFERENCE>
    public partial class FishyEdit : Form, IInitialiseIOpenImage, IInitialiseGetImageDel, IInitialiseLoadDel, IInitialiseDeleteDel, IInitialiseRotationDel, IInitialiseACRotationDel, IInitialiseHFlipImgDel, IInitialiseVFlipImgDel
    {
        #region FIELD VARIABLES

        // DECLARE an int, name it '_dictIndex':
        private int _dictIndex;

        // DECLARE an int, name it '_dictCount':
        private int _dictCount;

        // DECLARE an IDictionary<int, String>, name it 'imgFPDict':
        private IDictionary<int, String> _imgFPDict;

        // DECLARE an IOpenImage, name it '_imgOpen':
        private IOpenImage _imgOpen;

        // DECLARE an ISaveImage, name it '_imgSave':
        private ISaveImage _imgSave;

        // DECLARE a GetImageDelegate, name it '_getImg':
        private GetImageDelegate _getImg;

        // DECLARE a LoadDelegate, name it '_load':
        private LoadDelegate _load;

        // DECLARE a DeleteDelegate, name it '_remove':
        private DeleteDelegate _remove;

        // DECLARE a RotationDelegate, name it '_rotate':
        private RotationDelegate _rotate;

        // DECLARE a ACRotationDelegate, name it 'acRotate':
        private ACRotationDelegate _acRotate;

        // DECLARE a HFlipImageDelegate, name it '_hFlip':
        private HFlipImageDelegate _hFlip;

        // DECLARE a VFlipImageDelegate, name it '_vFlip':
        private VFlipImageDelegate _vFlip;

        // DECLARE a CropDelegate, name it '_crop':
        private CropDelegate _crop;

        // DECLARE a ScaleDelegate, name it '_scale':
        private ScaleDelegate _scale;

        // DECLARE a BrightnessDelegate, name it '_brightness':
        private BrightnessDelegate _brightness;

        // DECLARE a ContrastDelegate, name it '_contrast':
        private ContrastDelegate _contrast;

        // DECLARE a SaturationDelegate, name it '_saturation':
        private SaturationDelegate _saturation;

        // DECLARE a FilterOneDelegate, name it '_filterOne':
        private FilterOneDelegate _filterOne;

        // DECLARE a FilterTwoDelegate, name it '_filterTwo':
        private FilterTwoDelegate _filterTwo;

        // DECLARE a FilterThreeDelegate, name it '_filterThree':
        private FilterThreeDelegate _filterThree;

        // DECLARE a FilterFourDelegate, name it '_filterFour':
        private FilterFourDelegate _filterFour;

        // DECLARE a FilterRemoveDelegate, name it '_filterRemove':
        private FilterRemoveDelegate _filterRemove;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of FishyEdit
        /// </summary>
        public FishyEdit()
        {
            // CALL InitializeComponent():
            InitializeComponent();

            // INSTANTIATE _imgFPDict as new Dictionary<int,String>():
            _imgFPDict = new Dictionary<int,String>();

            // INITIALISE _dictIndex with value of 0:
            _dictIndex = 0;

            // INITIALISE _dictCount with value of 0:
            _dictCount = 0;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEIOPENIMAGE

        /// <summary>
        /// Initialises an object with an 'IOpenImage' instance
        /// </summary>
        /// <param name="pOpenImage"> Instance of IOpenImage </param>
        public void Initialise(IOpenImage pOpenImage)
        {
            // IF pOpenImage IS NOT null:
            if (pOpenImage != null)
            {
                // ASSIGN instance of pOpenImage to _imgOpen:
                _imgOpen = pOpenImage;

                // IF pOpenImage is also ISaveImage:
                // FIXES ISSUE WHERE IOPENIMAGE OBJECT MAY NOT IMPLEMENT ISAVEIMAGE OBJECT
                if (pOpenImage is ISaveImage)
                {
                    // ASSIGN instance of pOpenImage to _imgSave as an ISaveImage:
                    _imgSave = pOpenImage as ISaveImage;
                }
            }
            // IF pOpenImage IS null:
            else
            {
                // THROW NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: FishyEdit Initialised with a null instance of IOpenImage!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEGETIMAGEDEL

        /// <summary>
        /// Initialises an object with a 'GetImage' Delegate
        /// </summary>
        /// <param name="pGetImageDelegate"> Delegate used for getting object(s) </param>
        public void Initialise(GetImageDelegate pGetImageDelegate)
        {
            // ASSIGN method of pGetImageDelegate to _getImg:
            _getImg = pGetImageDelegate;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISELOADDEL

        /// <summary>
        /// Initialises an object with a 'Load' Delegate
        /// </summary>
        /// <param name="pLoadDelegate"> Delegate used for loading object(s) </param>
        public void Initialise(LoadDelegate pLoadDelegate)
        {
            // ASSIGN method of pDeleteDelegate to _remove:
            _load = pLoadDelegate;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEDELETEDEL

        /// <summary>
        /// Initialises an object with a 'Delete' Delegate
        /// </summary>
        /// <param name="pDeleteDelegate"> Delegate used for deleting object(s) </param>
        public void Initialise(DeleteDelegate pDeleteDelegate)
        {
            // ASSIGN method of pDeleteDelegate to _remove:
            _remove = pDeleteDelegate;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEROTATIONEDEL

        /// <summary>
        /// Initialises an object with a 'Rotation' Delegate
        /// </summary>
        /// <param name="pRotationDelegate"> Delegate used for rotating object(s) </param>
        public void Initialise(RotationDelegate pRotationDelegate)
        {
            // ASSIGN method of pRotationDelegate to _rotate:
            _rotate = pRotationDelegate;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEACROTATIONEDEL

        /// <summary>
        /// Initialises an object with a 'ACRotation' Delegate
        /// </summary>
        /// <param name="pACRotationDelegate"> Delegate used for rotating object(s) </param>
        public void Initialise(ACRotationDelegate pACRotationDelegate)
        {
            // ASSIGN method of pACRotationDelegate to _acRotate:
            _acRotate = pACRotationDelegate;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEHFLIPIMGDEL

        /// <summary>
        /// Method which initialises an object with a 'HFlipImage' Delegate
        /// </summary>
        /// <param name="pHFlipImageDelegate"> Delegate used for Horizontally flipping object(s) </param>
        public void Initialise(HFlipImageDelegate pHFlipImageDelegate)
        {
            // ASSIGN method of pRotationDelegate to _hFlip:
            _hFlip = pHFlipImageDelegate;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEVFLIPIMGDEL

        /// <summary>
        /// Method which initialises an object with a 'VFlipImage' Delegate
        /// </summary>
        /// <param name="pVFlipImageDelegate"> Delegate used for Vertically flipping object(s) </param>
        public void Initialise(VFlipImageDelegate pVFlipImageDelegate)
        {
            // ASSIGN method of pRotationDelegate to _vFlip:
            _vFlip = pVFlipImageDelegate;
        }

        #endregion


        #region BUTTON METHODS

        /// <summary>
        /// Method which closes currently displayed 'FishyEdit' window
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void CloseBttn_Click(object sender, EventArgs e)
        {
            // TRY checking if Image has active instance:
            try
            {
                // IF Image in ImgDisplay is an active instance:
                if (ImgDisplay.Image != null)
                {
                    // CALL _remove, passing ImgDisplay.Image as a parameter:
                    _remove(ImgDisplay.Image);
                }

                // CALL Dispose() on this to CLOSE PROGRAM:
                _remove(this);
            }
            // CATCH NullInstanceException from _remove delegate:
            catch (NullInstanceException pException)
            {
                // WRITE 
                Debug.WriteLine(pException);
            }
        }

        /// <summary>
        /// Method which loads a list of images, and adds them to a local dictionary
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void LoadBttn_Click(object sender, EventArgs e)
        {
            // SET value of _dictIndex to _dictCount, prevents dictionary ID problems:
            _dictIndex = _dictCount;

            try
            {
                // FOREACH String in returned IList<String> from _load:
                foreach (String pString in _load(_imgOpen.OpenImage()))
                {
                    // INCREMENT _dictIndex by 1:
                    _dictIndex++;

                    // ADD _dictIndex as a key, and pString as a value to _imgFPDict:
                    _imgFPDict.Add(_dictIndex, pString);
                }
            }
            // CATCH FileAlreadyStoredException from _imgOpenSave.OpenImage():
            catch (FileAlreadyStoredException pException)
            {
                // WRITE error message to debug console:
                Debug.WriteLine(pException.Message);

                // SHOW MessageBox detailing error to the user, store result in _mBox:
                MessageBox.Show(pException.Message + "\n\n Do not select already loaded images in multiselect!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // TRY checking if ChngImg throws a NullInstanceException:
            try
            {
                // SET value of _dictCount to _dictIndex:
                _dictCount = _dictIndex;

                // CALL ChngImg():
                ChngImg();
            }
            // CATCH NullInstanceException from ChngImg():
            catch (NullInstanceException pException)
            {
                // WRITE exception message to debug console:
                Debug.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Method which saves currently displayed image in FishyEdit
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void SaveBttn_Click(object sender, EventArgs e)
        {
            // TRY checking if SaveImage() throws an exception
            try
            {
                // CALL SaveImage() on _imgOpenSave, passing ImgDisplay.Image as a parameter:
                _imgSave.SaveImage(ImgDisplay.Image);
            }
            // CATCH FileNotSavedException from SaveImage method:
            catch (FileNotSavedException pException)
            {
                // WRITE exception message to debug console:
                Debug.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Method which rotates currently displayed image clockwise
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void Rot90Bttn_Click(object sender, EventArgs e)
        {
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _rotate() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _rotate passing current index in _imgFPDict as a parameter:
                    _rotate(_imgFPDict[_dictIndex]);

                    // CALL ChngImg():
                    ChngImg();
                }
                // CATCH NullInstanceException from ChngImg():
                catch (NullInstanceException pException)
                {
                    // WRITE exception message to debug console:
                    Debug.WriteLine(pException.Message);
                }
            }
            // IF _imgFPDict DOES NOT contain a key of the current _dictIndex value:
            else
            {
                // WRITE to debug console, with error message:
                Debug.WriteLine("ERROR: No Image at current index, cannot rotate 90 degrees clockwise!");
            }
        }

        /// <summary>
        /// Method which rotates currently displayed image anticlockwise
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void ACRot90Bttn_Click(object sender, EventArgs e)
        {
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _acRotate() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _acRotate passing current index in _imgFPDict as a parameter:
                    _acRotate(_imgFPDict[_dictIndex]);

                    // CALL ChngImg():
                    ChngImg();
                }
                // CATCH NullInstanceException from ChngImg():
                catch (NullInstanceException pException)
                {
                    // WRITE exception message to debug console:
                    Debug.WriteLine(pException.Message);
                }
            }
            // IF _imgFPDict DOES NOT contain a key of the current _dictIndex value:
            else
            {
                // WRITE to debug console, with error message:
                Debug.WriteLine("ERROR: No Image at current index, cannot rotate 90 degrees anticlockwise!");
            }
        }

        /// <summary>
        /// Method which flips currently displayed image on the X axis
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void FlipXBttn_Click(object sender, EventArgs e)
        {
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _hFlip and ChngImg throws a NullInstanceException:
                try
                {
                    // CALL _hFlip passing current index in _imgFPDict as a parameter:
                    _hFlip(_imgFPDict[_dictIndex]);

                    // CALL ChngImg():
                    ChngImg();
                }
                // CATCH NullInstanceException from ChngImg():
                catch (NullInstanceException pException)
                {
                    // WRITE exception message to debug console:
                    Debug.WriteLine(pException.Message);
                }
            }
            // IF _imgFPDict DOES NOT contain a key of the current _dictIndex value:
            else
            {
                // WRITE to debug console, with error message:
                Debug.WriteLine("ERROR: No Image at current index, cannot horizontally flip!");
            }
        }

        /// <summary>
        /// Method which rotates currently displayed image on the Y axis
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void FlipYBttn_Click(object sender, EventArgs e)
        {
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _vFlip and ChngImg throws a NullInstanceException:
                try
                {
                    // CALL _vFlip passing current index in _imgFPDict as a parameter:
                    _vFlip(_imgFPDict[_dictIndex]);

                    // CALL ChngImg():
                    ChngImg();
                }
                // CATCH NullInstanceException from ChngImg():
                catch (NullInstanceException pException)
                {
                    // WRITE exception message to debug console:
                    Debug.WriteLine(pException.Message);
                }
            }
            // IF _imgFPDict DOES NOT contain a key of the current _dictIndex value:
            else
            {
                // WRITE to debug console, with error message:
                Debug.WriteLine("ERROR: No Image at current index, cannot vertically flip!");
            }
        }

        /// <summary>
        /// Method which displays previous image in local dictionary
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void PrevImgBttn_Click(object sender, EventArgs e)
        {
            // TRY checking if GoToPrevImg throws a NullValueException:
            try
            {
                // CALL GoToPrevImg():
                GoToPrevImg();
            }
            // CATCH NullValueException from GoToPrevImg method:
            catch (NullValueException pException)
            {
                // WRITE exception message to debug console:
                Debug.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Method which displays previous image in local dictionary
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void NextImgBttn_Click(object sender, EventArgs e)
        {
            // TRY checking if GoToNextImg throws a NullValueException:
            try
            {
                // CALL GoToNextImg():
                GoToNextImg();
            }
            // CATCH NullValueException from GoToNextImg method:
            catch (NullValueException pException)
            {
                // WRITE exception message to debug console:
                Debug.WriteLine(pException.Message);
            }
        }

        #endregion


        #region PRIVATE METHODS

        /// <summary>
        /// Changes currently displayed image with a local dictionary using the current index as the key for an image
        /// </summary>
        private void ChngImg()
        {
            // IF _imgFPDict contains a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // IF _getImg(_imgFPDict[_dictIndex] IS NOT null:
                if (_getImg(_imgFPDict[_dictIndex], ImgDisplay.Width, ImgDisplay.Height) != null)
                {
                    // SET displayed image to image stored in _imgFPDict at current _dictIndex value:
                    ImgDisplay.Image = _getImg(_imgFPDict[_dictIndex], ImgDisplay.Width, ImgDisplay.Height);
                }
                // IF _getImg(_imgFPDict[_dictIndex] IS null:
                else
                {
                    // THROW NullInstanceException, with corresponding message:
                    throw new NullInstanceException("ERROR: No Image stored in local dictionary at current image index!");
                }
            }

        }

        /// <summary>
        /// Changes currently displayed image to previous image stored in local dictionary
        /// </summary>
        private void GoToPrevImg()
        {
            // IF _imgFPDict DOES contain current index minus 1 as a key:
            if (_imgFPDict.ContainsKey(_dictIndex - 1))
            {
                // DECREMENT _dictIndex by 1:
                _dictIndex--;

                // TRY checking if ChngImg throws a NullInstanceException:
                try
                {
                    // CALL ChngImg():
                    ChngImg();
                }
                // CATCH NullInstanceException from ChngImg():
                catch (NullInstanceException pException)
                {
                    // WRITE exception message to debug console:
                    Debug.WriteLine(pException.Message);
                }
            }
            // IF _imgFPDict DOES NOT contain current index minus 1 as a key:
            else
            {
                // THROW new NullValueException, with corresponding message:
                throw new NullValueException("ERROR: There is no previous image to go back to!");
            }
        }

        /// <summary>
        /// Changes currently displayed image to next image stored in local dictionary
        /// </summary>
        private void GoToNextImg()
        {
            // IF _imgFPDict DOES contain current index plus 1 as a key:
            if (_imgFPDict.ContainsKey(_dictIndex + 1))
            {
                // INCREMENT _dictIndex by 1:
                _dictIndex++;

                // TRY checking if ChngImg throws a NullInstanceException:
                try
                {
                    // CALL ChngImg():
                    ChngImg();
                }
                // CATCH NullInstanceException from ChngImg():
                catch (NullInstanceException pException)
                {
                    // WRITE exception message to debug console:
                    Debug.WriteLine(pException.Message);
                }
            }
            // IF _imgFPDict DOES NOT contain current index plus 1 as a key:
            else
            {
                // THROW new NullValueException, with corresponding message:
                throw new NullValueException("ERROR: There is no next image to go to!");
            }
        }

        #endregion


        #region MOVEABLE BORDERLESS WINDOW (Price, 2007)

        // Modified from https://stackoverflow.com/a/24561946 and attributed to user jay_t55

        // DECLARE a boolean that is set to true when a mouse down event is detected, name it _mouseDown:
        private bool _mouseDown = false;

        // DECLARE a Point object to store the last location of the window origin (ie memory), name it _lastLocation:
        private Point _lastLocation;

        /// <summary>
        /// Mouse down event handler
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void FishyEdit_MouseDown(object sender, MouseEventArgs e)
        {
            // SET _mouseDown to true:
            _mouseDown = true;

            // STORE current location to _lastLocation:
            _lastLocation = e.Location;
        }


        /// <summary>
        /// Mouse move event handler
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void FishyEdit_MouseMove(object sender, MouseEventArgs e)
        {
            // Only act if mouse button is down...
            if (_mouseDown)
            {
                // SET new location according to mouse movement from _lastLocation:
                this.Location = new Point(
                    (this.Location.X - _lastLocation.X) + e.X, (this.Location.Y - _lastLocation.Y) + e.Y);

                // UPDATE this window:
                this.Update();
            }
        }

        /// <summary>
        /// Mouse up event handler
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void FishyEdit_MouseUp(object sender, MouseEventArgs e)
        {
            // RESET _mouseDown to false:
            _mouseDown = false;
        }

        #endregion

        /// <summary>
        /// Filter 1 radio button - for first filter 
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e">Value</param>
        private void radioFilter1_CheckedChanged(object sender, EventArgs e)
        {
            // ON Checked
        }

        /// <summary>
        /// Filter 2 radio button - for second filter
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value </param>
        private void radioFilter2_CheckedChanged(object sender, EventArgs e)
        {
            // ON Checked
        }

        /// <summary>
        /// Filter 3 radio button - for third button
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value </param>
        private void radioFilter3_CheckedChanged(object sender, EventArgs e)
        {
            // ON Checked
        }

        /// <summary>
        /// Filter 4 radio button - for fourth filter
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value </param>
        private void radioFilter4_CheckedChanged(object sender, EventArgs e)
        {
            // ON Checked
        }

        /// <summary>
        /// Filter remove radio button - for removing filters applied
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value </param>
        private void radialFilterRemove_CheckedChanged(object sender, EventArgs e)
        {
            // ON Checked
        }

        /// <summary>
        /// Brightness control button - for controlling brightness
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value </param>
        private void BrightnessControl_ValueChanged(object sender, EventArgs e)
        {
            // ON INPUT
        }

        /// <summary>
        /// Contrast control button - for controlling contrast
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value </param>
        private void ContrastControl_ValueChanged(object sender, EventArgs e)
        {
            // ON INPUT
        }

        /// <summary>
        /// Saturation control button - for controlling saturation
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value </param>
        private void SaturationControl_ValueChanged(object sender, EventArgs e)
        {
            // ON INPUT
        }

      
    }
}
