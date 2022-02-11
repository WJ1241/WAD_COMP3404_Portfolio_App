using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using GUI.Logic;
using Server.Commands;
using Server.Delegates;
using Server.Exceptions;
using Server.InitialisingInterfaces;

namespace GUI
{
    /// <summary>
    /// Partial Class which creates a 'FishyEdit' for the user to edit Images with.
    /// Author: Declan Kerby-Collins, William Eardley, William Smith & Marc Price
    /// Date: 02/02/2022
    /// </summary>
    /// <REFERENCE> Price, M. (2007) 'Moveable Form Code Snippet'. Available at: https://worcesterbb.blackboard.com/. (Accessed: 5 November 2021). </REFERENCE>
    /// <REFERENCE> jay_t55 (2014) Make a borderless form movable? Available at: https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable/24561946#24561946. (Accessed 5 November 2021). </REFERENCE>
    public partial class FishyHome : Form, IInitialiseParam<IOpenImage>, IInitialiseParam<GetImageDelegate>, IInitialiseParam<LoadDelegate>
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<int, string>, name it 'imgFPDict':
        private IDictionary<int, string> _imgFPDict;

        // DECLARE an IOpenImage, name it '_imgOpen':
        private IOpenImage _imgOpen;

        // DECLARE an ISaveImage, name it '_imgSave':
        private ISaveImage _imgSave;

        // DECLARE an IDictionary<string, ICommand>, name it '_commandDict':
        private IDictionary<string, ICommand> _commandDict;

        // DECLARE an Action<ICommand>, name it '_invokeCommand':
        private Action<ICommand> _invokeCommand;

        // DECLARE a GetImageDelegate, name it '_getImg':
        private GetImageDelegate _getImg;

        // DECLARE a LoadDelegate, name it '_load':
        private LoadDelegate _load;

        // DECLARE an int, name it '_dictIndex':
        private int _dictIndex;

        // DECLARE an int, name it '_dictCount':
        private int _dictCount;

        #endregion 

        /// <summary>
        /// Constructor for objects of FishyHome
        /// </summary>
        public FishyHome()
        {
            // CALL InitializeComponent():
            InitializeComponent();

            // INSTANTIATE _imgFPDict as new Dictionary<int, string>():
            _imgFPDict = new Dictionary<int, string>();

            // INSTANTIATE _commandDict as a new Dictionary<string, ICommand>():
            _commandDict = new Dictionary<string, ICommand>();

            // INITIALISE _dictIndex with value of 0:
            _dictIndex = 0;

            // INITIALISE _dictCount with value of 0:
            _dictCount = 0;
        }





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


        #region IMPLEMENTATION OF IINITIALISEPARAM<IOPENIMAGE>

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


        #region IMPLEMENTATION OF IINITIALISEPARAM<GETIMAGEDELEGATE>

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


        #region IMPLEMENTATION OF IINITIALISEPARAM<LOADDELEGATE>

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


        /// <summary>
        /// Method which displays previous image in local dictionary
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void NextBttn_Click(object sender, EventArgs e)
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
        /// Method which opens the FishyEdit window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditBttn_Click(object sender, EventArgs e)
        {







            //IF fishyedit is NULL then open fishy edit
            FishyEdit _fEdit = new FishyEdit();


            //open the FishyEdit
            if (_fEdit != null)
            {
                _fEdit.Show();
            }
        }


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

        private void Home_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Method for notification icon in system tray - Not called but required
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }
    }
}
