using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GUI.Forms.Interfaces;
using GUI.Logic.Interfaces;
using Server.Commands.Interfaces;
using Server.CustomEventArgs;
using Server.Exceptions;
using Server.GeneralInterfaces;
using Server.InitialisingInterfaces;

namespace GUI
{
    /// <summary>
    /// Partial Class which creates a 'FishyEdit' for the user to edit Images with.
    /// Author: William Eardley, Declan Kerby-Collins, William Smith & Marc Price
    /// Date: 23/03/22
    /// </summary>
    /// <REFERENCE> Price, M. (2007) 'Moveable Form Code Snippet'. Available at: https://worcesterbb.blackboard.com/. (Accessed: 5 November 2021). </REFERENCE>
    /// <REFERENCE> jay_t55 (2014) Make a borderless form movable? Available at: https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable/24561946#24561946. (Accessed 5 November 2021). </REFERENCE>
    public partial class FishyHome : Form, IChangeImg, ICommandSender, IEventListener<ImageEventArgs>, IEventListener<StringListEventArgs>, IInitialiseParam<ICommand>,
        IInitialiseParam<IDictionary<int, string>>, IInitialiseParam<IDictionary<string, ICommand>>, IInitialiseParam<IOpenImage>
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<int, string>, name it 'imgFPDict':
        private IDictionary<int, string> _imgFPDict;

        // DECLARE an IDictionary<string, ICommand>, name it '_commandDict':
        private IDictionary<string, ICommand> _commandDict;

        // DECLARE an IOpenImage, name it '_imgOpen':
        private IOpenImage _imgOpen;

        // DECLARE an Action<ICommand>, name it '_invokeCommand':
        private Action<ICommand> _invokeCommand;

        // DECLARE an int, name it '_dictCount':
        private int _dictCount;

        // DECLARE an int, name it '_dictIndex':
        private int _dictIndex;

        #endregion 

        /// <summary>
        /// Constructor for objects of FishyHome
        /// </summary>
        public FishyHome()
        {
            // CALL InitializeComponent():
            InitializeComponent();

            // INITIALISE _dictCount with value of 0:
            _dictCount = 0;

            // INITIALISE _dictIndex with value of 0:
            _dictIndex = 0;
        }


        #region IMPLEMENTATION OF ICHANGEIMG

        /// <summary>
        /// Changes currently displayed image to a desired image
        /// </summary>
        public void ChangeImg()
        {
            // IF _imgFPDict DOES contain _dictIndex as a key:
            if (_imgFPDict.ContainsKey(_dictIndex))
            {
                // TRY checking if invoking _commandDict["GetImage"] throws an exception
                try
                {
                    // SET value of _commandDict["GetImage"]'s FirstParam property to string value stored at _imgFPDict[_dictIndex]):
                    (_commandDict["GetImage"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FirstParam = _imgFPDict[_dictIndex];

                    // SET value of _commandDict["GetImage"]'s SecondParam property to value of ImgDisplay.Width:
                    (_commandDict["GetImage"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).SecondParam = ImgDisplay.Width;

                     // SET value of _commandDict["GetImage"]'s ThirdParam property to value of ImgDisplay.Height:
                    (_commandDict["GetImage"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).ThirdParam = ImgDisplay.Height;

                    // SET value of _commandDict["GetImage"]'s FourthParam property to reference to OnEvent() (ImageEventArgs):
                    (_commandDict["GetImage"] as ICommandParam<string, int, int, EventHandler<ImageEventArgs>>).FourthParam = OnEvent;

                    // INVOKE _commandDict["GetImage"]'s ExecuteMethod():
                    _invokeCommand(_commandDict["GetImage"]);
                }
                // CATCH InvalidStringException from invoking _commandDict["GetImage"]:
                catch (InvalidStringException pException)
                {
                    // WRITE exception message to console:
                    Console.WriteLine(pException.Message);
                }
                // CATCH InvalidStringException addressing Dictionary keys:
                catch (NullReferenceException pException)
                {
                    // WRITE exception message to console:
                    Console.WriteLine(pException.Message);
                }
            }
            // IF _imgFPDict DOES NOT contain _dictIndex as a key:
            else
            {
                // THROW a new NullValueException(), with corresponding message:
                throw new NullValueException("ERROR: _imgFPDict does not contain _dictIndex as a key!");
            }
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


        #region IMPLEMENTATION OF IEVENTLISTENER<IMAGEEVENTARGS>

        /// <summary>
        /// Event Handler to update currently displayed image
        /// </summary>
        /// <param name="pSource"> Object calling this method </param>
        /// <param name="pArgs"> Necessary arguments to complete behaviour </param>
        public void OnEvent(object pSource, ImageEventArgs pArgs)
        {
            // IF pArgs.Img DOES HAVE an active instance:
            if (pArgs.Img != null)
            {
                // SET value of ImgDisplay.Image Property to value of pArgs.Img:
                ImgDisplay.Image = pArgs.Img;
            }
            // IF pArgs.Img DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pArgs.Img does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IEVENTLISTENER<STRINGLISTEVENTARGS>

        /// <summary>
        /// Event Handler to update list of images loaded into program
        /// </summary>
        /// <param name="pSource"> Object calling this method </param>
        /// <param name="pArgs"> Necessary arguments to complete behaviour </param>
        public void OnEvent(object pSource, StringListEventArgs pArgs)
        {
            // IF pArgs.List DOES HAVE an active instance:
            if (pArgs.List != null)
            {
                // FOREACH string value in pArgs.List:
                foreach (string pString in pArgs.List)
                {
                    // INCREMENT _dictIndex by '1':
                    _dictIndex++;

                    // ADD current _dictIndex value as a key, and pString as a value to _imgFPDict:
                    _imgFPDict.Add(_dictIndex, pString);
                }
            }
            // IF pArgs.List DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pArgs.List does not have an active instance!");
            }

            // SET value of _dictCount to same value as _dictIndex:
            _dictCount = _dictIndex;

            // TRY checking if ChangeImg() throws a NullReferenceException:
            try
            {
                // CALL ChangeImg():
                 ChangeImg();
            }
            // CATCH NullValueException from ChangeImg method:
            catch (NullValueException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
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


        #region IMPLEMENTATION OF IINITIALISEPARAM<IDICTIONARY<STRING, ICOMMAND>>

        /// <summary>
        /// Initialises an object with an IDictionary<string, ICommand> object
        /// </summary>
        /// <param name="pCommandDict"> IDictionary<string, ICommand> object </param>
        public void Initialise(IDictionary<string, ICommand> pCommandDict)
        {
            // IF pCommandDict DOES HAVE an active instance:
            if (pCommandDict != null)
            {
                // INITIALISE _commandDict with reference to pCommandDict:
                _commandDict = pCommandDict;
            }
            // IF pCommandDict DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pCommandDict does not have an active instance, requires instantiation!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IDICTIONARY<INT, STRING>>

        /// <summary>
        /// Initialises an object with an IDictionary<int, string> object
        /// </summary>
        /// <param name="pStringDict"> IDictionary<string, ICommand> object </param>
        public void Initialise(IDictionary<int, string> pStringDict)
        {
            // IF pStringDict DOES HAVE an active instance:
            if (pStringDict != null)
            {
                // INITIALISE _imgFPDict with reference to pStringDict:
                _imgFPDict = pStringDict;
            }
            // IF pCommandDict DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pStringDict does not have an active instance, requires instantiation!");
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
                // INITIALISE _imgOpen with reference to pOpenImage:
                _imgOpen = pOpenImage;
            }
            // IF pOpenImage IS null:
            else
            {
                // THROW NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: FishyEdit Initialised with a null instance of IOpenImage!");
            }
        }

        #endregion


        #region BUTTON METHODS

        #region PREVIOUS IMAGE METHODS

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
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        /// <summary>
        /// Changes currently displayed image to previous image stored in local dictionary
        /// </summary>
        private void GoToPrevImg()
        {
            // IF _imgFPDict DOES contain _dictIndex minus 1 as a key:
            if (_imgFPDict.ContainsKey(_dictIndex - 1))
            {
                // DECREMENT _dictIndex by '1':
                _dictIndex--;

                // TRY checking if ChangeImg throws a NullInstanceException:
                try
                {
                    // CALL ChangeImg():
                    ChangeImg();
                }
                // CATCH NullValueException from ChangeImg():
                catch (NullValueException pException)
                {
                    // WRITE exception message to console:
                    Console.WriteLine(pException.Message);
                }
            }
            // IF _imgFPDict DOES NOT contain current index minus 1 as a key:
            else
            {
                // THROW new NullValueException, with corresponding message:
                throw new NullValueException("ERROR: There is no previous image to go back to!");
            }
        }

        #endregion


        #region NEXT IMAGE METHODS

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
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
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

                // TRY checking if ChangeImg throws a NullInstanceException:
                try
                {
                    // CALL ChangeImg():
                    ChangeImg();
                }
                // CATCH NullValueException from ChangeImg():
                catch (NullValueException pException)
                {
                    // WRITE exception message to console:
                    Console.WriteLine(pException.Message);
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


        #region LOAD METHODS

        /// <summary>
        /// Method which loads a list of images, and adds them to a local dictionary
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void LoadBttn_Click(object sender, EventArgs e)
        {
            // TRY checking if _imgOpen.OpenImage() and invoking _commandDict["Load"] throws an exception:
            try
            {
                // SET value of _dictIndex to value of _dictCount, prevents dictionary ID problems:
                _dictIndex = _dictCount;

                // SET value of _commandDict["Load"]'s FirstParam property to value of return value of _imgOpen.OpenImage():
                (_commandDict["Load"] as ICommandParam<IList<string>, EventHandler<StringListEventArgs>>).FirstParam = _imgOpen.OpenImage();

                // SET value of _commandDict["Load"]'s SecondParam property to reference to OnEvent() (StringListEventArgs):
                (_commandDict["Load"] as ICommandParam<IList<string>, EventHandler<StringListEventArgs>>).SecondParam = OnEvent;

                // INVOKE _commandDict["Load"]'s ExecuteMethod():
                _invokeCommand(_commandDict["Load"]);
            }
            // CATCH FileAlreadyStoredException from _imgOpen.OpenImage() and from invoking _commandDict["Load"]:
            catch (FileAlreadyStoredException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);

                // SHOW MessageBox detailing error to the user, store result in MessageBox:
                MessageBox.Show(pException.Message + "\n\n Do not select already loaded images in multiselect!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // CATCH InvalidStringException addressing Dictionary keys:
            catch (NullReferenceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        #endregion


        #region EDIT METHODS

        /// <summary>
        /// Method which opens the FishyEdit window
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void EditBttn_Click(object sender, EventArgs e)
        {
            // IF ImgDisplay.Image DOES HAVE an active instance:
            if (ImgDisplay.Image != null)
            {
                // TRY checking if invoking _commandDict["CreateEditScrn"] throws an exception:
                try
                {
                    // SET FirstParam Property value of _commandDict["CreateEditScrn"] to value of _imgFPDict[_dictIndex]:
                    (_commandDict["CreateEditScrn"] as ICommandParam<string>).FirstParam = _imgFPDict[_dictIndex];

                    // INVOKE _commandDict["CreateEditScrn"]'s ExecuteMethod():
                    _invokeCommand(_commandDict["CreateEditScrn"]);
                }
                // CATCH InvalidStringException from invoking _commandDict["CreateEditScrn"]:
                catch (InvalidStringException pException)
                {
                    // WRITE exception message to console:
                    Console.WriteLine(pException);
                }
                // CATCH InvalidStringException addressing Dictionary keys:
                catch (NullReferenceException pException)
                {
                    // WRITE exception message to console:
                    Console.WriteLine(pException.Message);
                }
            }
            // IF ImgDisplay.Image DOES NOT HAVE an active instance:
            else
            {
                // WRITE to console, with corresponding error message:
                Console.WriteLine("ERROR: There is currently no image selected to be edited!");
            }
        }

        #endregion


        #region CLOSE METHODS

        /// <summary>
        /// Method which closes an instance of this class and removes any other disposable objects
        /// </summary>
        /// <param name="sender"> Form Object </param>
        /// <param name="e"> Value for classes without event data </param>
        private void CloseBttn_Click(object sender, EventArgs e)
        {
            // TRY checking if NullInstanceException or NullValueException are thrown:
            try
            {
                // IF ImgDisplay.Image DOES HAVE an active image:
                if (ImgDisplay.Image != null)
                {
                    // SET FirstParam Property value of _commandDict["DisposableRemoval"] to reference to ImgDisplay.Image:
                    (_commandDict["DisposableRemoval"] as ICommandParam<IDisposable>).FirstParam = ImgDisplay.Image;

                    // INVOKE _commandDict["RemoveMe"]'s ExecuteMethod():
                    _invokeCommand(_commandDict["DisposableRemoval"]);
                }

                // INVOKE _commandDict["RemoveMe"]'s ExecuteMethod():
                _invokeCommand(_commandDict["RemoveMe"]);
            }
            // CATCH NullInstanceException from invoking _commandDict["RemoveMe"] or _commandDict["DisposableRemoval"]:
            catch (NullInstanceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH InvalidStringException addressing Dictionary keys:
            catch (NullReferenceException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
            // CATCH NullInstanceException from invoking _commandDict["RemoveMe"]:
            catch (NullValueException pException)
            {
                // WRITE exception message to console:
                Console.WriteLine(pException.Message);
            }
        }

        #endregion

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
        private void FishyHome_MouseDown(object sender, MouseEventArgs e)
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
        private void FishyHome_MouseMove(object sender, MouseEventArgs e)
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
        private void FishyHome_MouseUp(object sender, MouseEventArgs e)
        {
            // RESET _mouseDown to false:
            _mouseDown = false;
        }

        #endregion
    }
}
