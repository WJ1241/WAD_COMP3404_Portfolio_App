using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GUI.Logic;
using Server.Commands;
using Server.Exceptions;
using Server.InitialisingInterfaces;

namespace GUI
{
    /// <summary>
    /// Partial Class which creates a 'FishyEdit' for the user to edit Images with.
    /// Author: William Smith, William Eardley, Declan Kerby-Collins, Marc Price
    /// Date: 11/02/22
    /// </summary>
    /// <REFERENCE> Price, M. (2007) 'Moveable Form Code Snippet'. Available at: https://worcesterbb.blackboard.com/. (Accessed: 5 November 2021). </REFERENCE>
    /// <REFERENCE> jay_t55 (2014) Make a borderless form movable? Available at: https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable/24561946#24561946. (Accessed 5 November 2021). </REFERENCE>
    public partial class FishyEdit : Form, ICommandSender, IInitialiseParam<ICommand>, IInitialiseParam<ISaveImage>
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<int, string>, name it '_imgFPDict':
        private IDictionary<int, string> _imgFPDict;

        // DECLARE an IDictionary<string, ICommand>, name it '_commandDict':
        private IDictionary<string, ICommand> _commandDict;

        // DECLARE an ISaveImage, name it '_imgSave':
        private ISaveImage _imgSave;

        // DECLARE an Action<ICommand>, name it '_invokeCommand':
        private Action<ICommand> _invokeCommand;

        // DECLARE an int, name it '_dictIndex':
        private int _dictIndex;

        // DECLARE an int, name it '_dictCount':
        private int _dictCount;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of FishyEdit
        /// </summary>
        public FishyEdit()
        {
            // CALL InitializeComponent():
            InitializeComponent();

            // INSTANTIATE _imgFPDict as a new Dictionary<int,string>():
            _imgFPDict = new Dictionary<int,string>();

            // INSTANTIATE _commandDict as a new Dictionary<string, ICommand>();
            _commandDict = new Dictionary<string, ICommand>();

            // INITIALISE _dictIndex with value of 0:
            _dictIndex = 0;

            // INITIALISE _dictCount with value of 0:
            _dictCount = 0;
        }

        #endregion


        #region IMPLEMENTATION OF ICOMMANDSENDER

        /// <summary>
        /// Property which allows write access to a command invoking Action
        /// </summary>
        public Action<ICommand> InvokeCommand
        {
            set
            {
                // SET value of _invokeCommand to incoming value:
                _invokeCommand = value;
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<ICOMMAND>

        /// <summary>
        /// Initialises an object with an ICommand object
        /// </summary>
        /// <param name="pCommand"> ICommand object with an executable method and possible parameter(s) </param>
        public void Initialise(ICommand pCommand)
        {
            // IF pCommand DOES HAVE an active instance:
            if (pCommand != null)
            {
                // ADD pCommand.Name as a key, and pCommand as a value to _commandDict:
                _commandDict.Add((pCommand as IName).Name, pCommand);
            }
            // IF pCommand DOES NOT HAVE an active instance:
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: pCommand does not have an active instance, requires instantiation!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<ISAVEIMAGE>

        /// <summary>
        /// Initialises an object with an ISaveImage instance
        /// </summary>
        /// <param name="pSaveImage"> Instance of ISaveImage </param>
        public void Initialise(ISaveImage pSaveImage)
        {
            // IF pSaveImage DOES HAVE an active instance:
            // FIXES ISSUE WHERE IOPENIMAGE OBJECT MAY NOT IMPLEMENT ISAVEIMAGE OBJECT
            if (pSaveImage != null)
            {
                // INITIALISE _imgSave with instance of pSaveImage:
                _imgSave = pSaveImage;
            }
            // IF pSaveImage DOES NOT HAVE an active instance:
            else
            {
                // THROW NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: FishyEdit Initialised with a null instance of IOpenImage!");
            }
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
                    // SET value of _commandDict["Remove"]'s Data Property to currently displayed image:
                    (_commandDict["Remove"] as ICommandOneParam<IDisposable>).Data = ImgDisplay.Image;

                    // INVOKE _commandDict["Remove"]:
                    _invokeCommand(_commandDict["Remove"]);
                }

                // SET value of _commandDict["Remove"]'s Data Property to this instance:
                // CLOSES PROGRAM
                (_commandDict["Remove"] as ICommandOneParam<IDisposable>).Data = this;

                // INVOKE _commandDict["Remove"]:
                _invokeCommand(_commandDict["Remove"]);
            }
            // CATCH NullInstanceException from _remove delegate:
            catch (NullInstanceException pException)
            {
                // WRITE exception message to debug console:
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
            /*
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
            }*/

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
                    //_rotate(_imgFPDict[_dictIndex]);

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
                    //_acRotate(_imgFPDict[_dictIndex]);

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
                    //_hFlip(_imgFPDict[_dictIndex]);

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
                    //_vFlip(_imgFPDict[_dictIndex]);

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
                /*
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
                }*/
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


        #region radio filters
        /// <summary>
        /// Filter 1 radio button - for first filter 
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void radioFilter1_CheckedChanged(object sender, EventArgs e)
        {
            // ON Checked
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _filterOne() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _filterOne passing current index in _imgFPDict as a parameter:
                    //_filterOne(_imgFPDict[_dictIndex]);

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
                Debug.WriteLine("ERROR: No Image at current index, cannot activate filter!");
            }
        }

        /// <summary>
        /// Filter 2 radio button - for second filter
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void radioFilter2_CheckedChanged(object sender, EventArgs e)
        {
            // ON Checked
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _filterTwo() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _filterTwo passing current index in _imgFPDict as a parameter:
                    //_filterTwo(_imgFPDict[_dictIndex]);

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
                Debug.WriteLine("ERROR: No Image at current index, cannot activate filter!");
            }
        }

        /// <summary>
        /// Filter 3 radio button - for third button
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void radioFilter3_CheckedChanged(object sender, EventArgs e)
        {
            // ON Checked
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _filterThree() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _filterThree passing current index in _imgFPDict as a parameter:
                    //_filterThree(_imgFPDict[_dictIndex]);

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
                Debug.WriteLine("ERROR: No Image at current index, cannot activate filter!");
            }
        }

        /// <summary>
        /// Filter 4 radio button - for fourth filter
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void radioFilter4_CheckedChanged(object sender, EventArgs e)
        {
            // ON Checked
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _filterFour() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _filterFour passing current index in _imgFPDict as a parameter:
                    //_filterFour(_imgFPDict[_dictIndex]);

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
                Debug.WriteLine("ERROR: No Image at current index, cannot activate filter!");
            }
        }

        /// <summary>
        /// Filter remove radio button - for removing filters applied
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void radialFilterRemove_CheckedChanged(object sender, EventArgs e)
        {
            // ON Checked
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _filterRemove() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _filterRemove passing current index in _imgFPDict as a parameter:
                    //_filterRemove(_imgFPDict[_dictIndex]);

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
                Debug.WriteLine("ERROR: No Image at current index, cannot activate filter!");
            }
        }
        #endregion

        #region Colouring

        /// <summary>
        /// Brightness control button - for controlling brightness
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void BrightnessControl_ValueChanged(object sender, EventArgs e)
        {
            // ON INPUT _brightness
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _brightness() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _brightness passing current index in _imgFPDict as a parameter:
                    //_brightness(_imgFPDict[_dictIndex]);

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
                Debug.WriteLine("ERROR: No Image at current index, cannot alter brightness!");
            }
        }

        /// <summary>
        /// Contrast control button - for controlling contrast
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void ContrastControl_ValueChanged(object sender, EventArgs e)
        {
            // ON INPUT
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _contrast() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _contrast passing current index in _imgFPDict as a parameter:
                    //_contrast(_imgFPDict[_dictIndex]);

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
                Debug.WriteLine("ERROR: No Image at current index, cannot alter contrast!");
            }
        }

        /// <summary>
        /// Saturation control button - for controlling saturation
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void SaturationControl_ValueChanged(object sender, EventArgs e)
        {
            // ON INPUT
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _saturation() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _saturation passing current index in _imgFPDict as a parameter:
                    //_saturation(_imgFPDict[_dictIndex]);

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
                Debug.WriteLine("ERROR: No Image at current index, cannot alter saturation!");
            }
        }

        #endregion

        /// <summary>
        /// Scale control button - for scaling the image
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void ScaleBttn_Click(object sender, EventArgs e)
        {
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _scale() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _scale passing current index in _imgFPDict as a parameter:
                    //_scale(_imgFPDict[_dictIndex]);

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
                Debug.WriteLine("ERROR: No Image at current index, cannot scale!");
            }
        }

        /// <summary>
        /// Crop control Button - for cropping the image
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Required Argument Value(s)</param>
        private void CropBttn_Click(object sender, EventArgs e)
        {
            // IF _imgFPDict DOES contain a key of the current _dictIndex value:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if _crop() OR ChngImg() throw a NullInstanceException:
                try
                {
                    // CALL _crop passing current index in _imgFPDict as a parameter:
                    //_crop(_imgFPDict[_dictIndex]);

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
                Debug.WriteLine("ERROR: No Image at current index, cannot Crop!");
            }
        }
    }
}
