using System;
using System.Collections.Generic;
using Server.CustomEventArgs;
using Server.Exceptions;
using Server.InitialisingInterfaces;
using Server.GeneralInterfaces;
using System.Drawing;

namespace Server
{
    /// <summary>
    /// Class which acts as the 'Server' for the Application
    /// Author: William Smith, William Eardley, Declan Kerby-Collins & Marc Price
    /// Date: 12/03/22
    /// </summary>
    /// <REFERENCE> Price, M (2021) 'IServer.cs'. COMP3404: Applied Software Engineering. Available at: https://worcesterbb.blackboard.com/. (Accessed: 20 November 2021). </REFERENCE>
    public class ImageServer : IServer, IACRotate, IInitialiseParam<IEditImg>, IInitialiseParam<IManageImg>, IInitialiseParam<IDictionary<string, EventArgs>>,
        IInitialiseParam<string, EventArgs>, ISubscribe<ImageEventArgs>, ISubscribe<StringListEventArgs>
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<string, EventArgs>, name it '_argDict':
        private IDictionary<string, EventArgs> _argDict;

        // DECLARE an IEditImg, name it '_imgEditor':
        private IEditImg _imgEditor;

        // DECLARE an IManageImg, name it '_imgManager':
        private IManageImg _imgManager;

        // DECLARE an EventHandler<ImageEventArgs>, name it '_changeImgEvent':
        private EventHandler<ImageEventArgs> _changeImgEvent;

        // DECLARE an EventHandler<StringListEventArgs>, name it '_changeStringListEvent':
        private EventHandler<StringListEventArgs> _changeStringListEvent;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of ImageServer
        /// </summary>
        public ImageServer()
        {
            // EMPTY CONSTRUCTOR
        }

        #endregion


        #region IMPLEMENTATION OF ISERVER

        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the Server's data store.
        /// The strings in the collection act as unique identifiers for images in the Server's data store.
        /// </summary>
        /// <param name="pPathfilenames">a collection of one or more strings; each string containing path/filename for an image file to be loaded</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        public void Load(IList<string> pPathfilenames)
        {
            // TRY checking if ReturnFilteredList throws an exception:
            try
            {
                // SET value of List property to return value of _imgManager.ReturnFilteredList():
                (_argDict["StringList"] as StringListEventArgs).List = _imgManager.ReturnFilteredList(pPathfilenames);

                // INVOKE _changeStringListEvent(), passing this class and _argDict["StringList"] as parameters:
                _changeStringListEvent.Invoke(this, _argDict["StringList"] as StringListEventArgs);
            }
            // CATCH FileAlreadyStoredException from ReturnFilteredList:
            catch (FileAlreadyStoredException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW a new FileAlreadyStoredException(), with corresponding message:
                throw new FileAlreadyStoredException(pException.Message);
            }
        }

        /// <summary>
        /// Request a copy of the image specified by 'pUid', scaled according to the dimensions given by pFrameWidth and pFrameHeight.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image requested</param>
        /// <param name="pFrameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pFrameHeight">the height (in pixels) of the 'frame' it is to occupy</param>
        /// <returns>the Image identified by pUid</returns>
        public void GetImage(string pUid, int pFrameWidth, int pFrameHeight)
        {
            // TRY checking if _imgManager.ReturnImg throws an exception:
            try
            {
                // SET value of Img property to return value of _imgManager.ReturnImg():
                (_argDict["Image"] as ImageEventArgs).Img = _imgManager.ReturnImg(pUid, pFrameWidth, pFrameHeight);

                // INVOKE _changeImgEvent(), passing this class and _argDict["Image"] as parameters:
                _changeImgEvent.Invoke(this, _argDict["Image"] as ImageEventArgs);
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW a new InvalidStringException(), with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
        }

        /// <summary>
        /// Rotate the image specified by 'pUid'.
        /// The client will need to request a copy of the Image to update its view-copy of the image accordingly.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be rotated</param>
        public void RotateImage(string pUid)
        {
            // TRY checking for InvalidStringException and NullInstanceException from _imgEditor.ImgRotateClockwise:
            try
            {
                // CALL ImgRotateClockwise(), passing ReturnImg() as a parameter:
                _imgEditor.ImgRotateClockwise(_imgManager.ReturnImg(pUid));
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgRotateClockwise:
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        /// <summary>
        /// Flip the image specified by 'pUid' horizontally.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be flipped</param>
        public void HorizontalFlipImage(string pUid)
        {
            // TRY checking for InvalidStringException and NullInstanceException from _imgEditor.ImgFlipXAxis:
            try
            {
                // CALL ImgFlipXAxis(), passing ReturnImg() as a parameter:
                _imgEditor.ImgFlipXAxis(_imgManager.ReturnImg(pUid));
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgFlipXAxis:
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        /// <summary>
        /// Flip the image specified by 'pUid' vertically.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be flipped</param>
        public void VerticalFlipImage(string pUid)
        {
            // TRY checking for InvalidStringException and NullInstanceException from _imgEditor.ImgFlipYAxis:
            try
            {
                // CALL ImgFlipYAxis(), passing ReturnImg() as a parameter:
                _imgEditor.ImgFlipYAxis(_imgManager.ReturnImg(pUid));
            }

            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgFlipYAxis:
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        #endregion


        #region IMPLEMENTATION OF IACROTATE

        /// <summary>
        /// Rotate the image anticlockwise specified by 'pUid'.
        /// The client will need to request a copy of the Image to update its view-copy of the image accordingly.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be rotated</param>
        public void ACRotateImage(string pUid)
        {
            // TRY checking for InvalidStringException and NullInstanceException from _imgEditor.ImgRotateAntiClockwise:
            try
            {
                // CALL ImgRotateAntiClockwise(), passing ReturnImg() as a parameter:
                _imgEditor.ImgRotateAntiClockwise(_imgManager.ReturnImg(pUid));
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgRotateAntiClockwise:
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        #endregion


        #region Colour
        
        /// <summary>
        /// METHOD Contrast provides access to the ContrastImage method in ImgEditor
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pSat"></param>
        public void Contrast(Image pImage, int pSat)
        {
            // CALL the ContrastImg and passes pImage and pSat:
            _imgEditor.ContrastImg(pImage, pSat);
        }
        
        
        #endregion



        #region IMPLEMENTATION OF IINITIALISEPARAM<IEDITIMG>

        /// <summary>
        /// Initialises an object with an IEditImg object
        /// </summary>
        /// <param name="pEditImg"> Reference to IEditImg object </param>
        public void Initialise(IEditImg pEditImg)
        {
            // IF pEditImg DOES HAVE an active instance:
            if (pEditImg != null)
            {
                // INITIALISE _imgEditor with reference to pEditImg:
                _imgEditor = pEditImg;
            }
            // IF pEditImg DOES NOT HAVE an active instance:
            else
            {
                // THROW new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pEditImg does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IMANAGEIMG>

        /// <summary>
        /// Initialises an object with an IManageImg object
        /// </summary>
        /// <param name="pManageImg"> Reference to IManageImg object </param>
        public void Initialise(IManageImg pManageImg)
        {
            // IF pManageImg DOES HAVE an active instance:
            if (pManageImg != null)
            {
                // INITIALISE _imgManager with reference to pManageImg:
                _imgManager = pManageImg;
            }
            // IF pManageImg DOES NOY HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pManageImg does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IDICTIONARY<STRING, EVENTARGS>>

        /// <summary>
        /// Initialises an object with an IDictionary<string, EventArgs> object
        /// </summary>
        /// <param name="pEventDict"> Reference to IDictionary<string, EventArgs> object </param>
        public void Initialise(IDictionary<string, EventArgs> pEventDict)
        {
            // IF pEventDict DOES HAVE an active instance:
            if (pEventDict != null)
            {
                // INITIALISE _argDict with reference to pManageImg:
                _argDict = pEventDict;
            }
            // IF pEventDict DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pEventDict does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<STRING, EVENTARGS>

        /// <summary>
        /// Initialises an object with a string and an EventArgs object
        /// </summary>
        /// <param name="pArgName"> Name of Argument Type </param>
        /// <param name="pArgs"> Reference to EventArgs object </param>
        public void Initialise(string pArgName, EventArgs pArgs)
        {
            // IF pArgName IS NOT blank AND pArgs DOES HAVE an active instance:
            if (pArgName != "" && pArgs != null)
            {
                // ADD pArgName as a key, and pArgs as a value to _argDict:
                _argDict.Add(pArgName, pArgs);
            }
            // IF pArgName IS blank:
            else if (pArgName == "")
            {
                // THROW a new InvalidStringException(), with corresponding message:
                throw new InvalidStringException("ERROR: pArgName is blank therefore requires details on what will be used for!");
            }
            // IF pArgs DOES NOT HAVE an active instance:
            else if (pArgs != null)
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pArgs does not have an active instance!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF ISUBSCRIBE<IMAGEEVENTARGS>

        /// <summary>
        /// Subscribes an object to an Event containing arguments for an Image change
        /// </summary>
        /// <param name="pEvent"> Event Method which contains the arguments for an Image change </param>
        public void Subscribe(EventHandler<ImageEventArgs> pEvent)
        {
            // SUBSCRIBE _changeImgEvent to pEvent:
            _changeImgEvent += pEvent;
        }

        #endregion


        #region IMPLEMENTATION OF ISUBSCRIBE<STRINGLISTEVENTARGS>

        /// <summary>
        /// Subscribes an object to an Event containing arguments for a string list change
        /// </summary>
        /// <param name="pEvent"> Event Method which contains the arguments for a string list change </param>
        public void Subscribe(EventHandler<StringListEventArgs> pEvent)
        {
            // SUBSCRIBE _changeStringListEvent to pEvent:
            _changeStringListEvent += pEvent;
        }

        #endregion


        #region Crop

        /// <summary>
        /// Crop the image specified by 'pUid' vertically.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be flipped</param>
        public void CropImage(string pUid)
        {
            // TRY checking if InvalidStringException and NullInstanceException are thrown:
            try
            {
                // CALL CropImg(), passing ReturnImg() as a parameter:
                _imgEditor.CropImg(_imgManager.ReturnImg(pUid));
            }

            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgFlipYAxis:
            catch (NullInstanceException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }
        
        #endregion
    }
}
