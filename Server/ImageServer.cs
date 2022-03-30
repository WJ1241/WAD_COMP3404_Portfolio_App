using System;
using System.Collections.Generic;
using System.Drawing;
using Server.CustomEventArgs;
using Server.Exceptions;
using Server.InitialisingInterfaces;
using Server.GeneralInterfaces;

namespace Server
{
    /// <summary>
    /// Class which acts as the 'Server' for the Application
    /// Author: William Smith, Declan Kerby-Collins, William Eardley & Marc Price
    /// Date: 25/03/22
    /// </summary>
    /// <REFERENCE> Price, M (2021) 'IServer.cs'. COMP3404: Applied Software Engineering. Available at: https://worcesterbb.blackboard.com/. (Accessed: 20 November 2021). </REFERENCE>
    public class ImageServer : IServer, IInitialiseParam<IEditImg>, IInitialiseParam<IManageImg>, IInitialiseParam<IDictionary<string, EventArgs>>,
        IInitialiseParam<string, EventArgs>, IApplyFilterImg, IReplaceColourImg, IReplaceCropImg
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<string, EventArgs>, name it '_argDict':
        private IDictionary<string, EventArgs> _argDict;

        // DECLARE an IEditImg, name it '_imgEditor':
        private IEditImg _imgEditor;

        // DECLARE an IManageImg, name it '_imgManager':
        private IManageImg _imgManager;

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
        /// The media items pointed to by 'pathfilenames' into the Server's data store.
		/// The strings in the collection act as unique identifiers for images in the Server's data store.
        /// </summary>
        /// <param name="pPathFileNames">a collection of one or more strings; each string containing path/filename for an image file to be loaded</param>
        /// <param name="pStringListEvent"> Event to invoke with changed StringListEventArgs object </param>
        public void Load(IList<string> pPathFileNames, EventHandler<StringListEventArgs> pStringListEvent)
        {
            // TRY checking if ReturnFilteredList throws an exception:
            try
            {
                // SET value of List property to return value of _imgManager.ReturnFilteredList() passing pPathFileNames as a parameter:
                (_argDict["StringList"] as StringListEventArgs).List = _imgManager.ReturnFilteredList(pPathFileNames);

                // INVOKE pStringListEvent() Event, passing this class and _argDict["StringList"] as parameters:
                pStringListEvent?.Invoke(this, _argDict["StringList"] as StringListEventArgs);
            }
            // CATCH FileAlreadyStoredException from ReturnFilteredList:
            catch (FileAlreadyStoredException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW a new FileAlreadyStoredException(), with corresponding message:
                throw new FileAlreadyStoredException(pException.Message);
            }
        }

        /// <summary>
        /// Request a copy of the image specified by 'pUid', scaled according to the dimensions given by pFrameWidth and pFrameHeight.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image requested</param>
        /// <param name="pImgWidth">the width (in pixels) of the desired image</param>
        /// <param name="pImgHeight">the height (in pixels) of the desired image</param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        public void GetImage(string pUid, int pImgWidth, int pImgHeight, EventHandler<ImageEventArgs> pImageEvent)
        {
            // TRY checking if _imgManager.ReturnImg throws an exception:
            try
            {
                // SET value of Img property to return value of _imgManager.ReturnImg():
                (_argDict["Image"] as ImageEventArgs).Img = _imgManager.ReturnImg(pUid, pImgWidth, pImgHeight);

                // INVOKE pImageEvent(), passing this class and _argDict["Image"] as parameters:
                pImageEvent.Invoke(this, _argDict["Image"] as ImageEventArgs);
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

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
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgRotateClockwise:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

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
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgRotateAntiClockwise:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

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
            // TRY checking for InvalidStringException and NullInstanceException from _imgEditor.ImgHFlip():
            try
            {
                // CALL ImgHFlip(), passing ReturnImg() as a parameter:
                _imgEditor.ImgHFlip(_imgManager.ReturnImg(pUid));
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgFlipXAxis:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

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
            // TRY checking for InvalidStringException and NullInstanceException from _imgEditor.ImgVFlip():
            try
            {
                // CALL ImgVFlip(), passing ReturnImg() as a parameter:
                _imgEditor.ImgVFlip(_imgManager.ReturnImg(pUid));
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgFlipYAxis:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
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


        #region IMPLEMENTATION OF IAPPLYFILTERIMG

        /// <summary>
        /// Applies first specified filter to given image
        /// </summary>
        /// <param name="pUID"> Unique ID for Image </param>
        /// <param name="pImgWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImgHeight">the height (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        public void ApplyFilterOne(string pUID, int pImgWidth, int pImgHeight, EventHandler<ImageEventArgs> pImageEvent)
        {
            // TRY checking for InvalidStringException and NullInstanceException from _imgEditor.ImgFilterOne():
            try
            {
                // SET value of Img property to return value of _imgEditor.ImgFilterOne(), passing result of _imgManager.ReturnImg() as a parameter:
                (_argDict["Image"] as ImageEventArgs).Img = _imgEditor.ImgFilterOne(_imgManager.ReturnImg(pUID, pImgWidth, pImgHeight));

                // INVOKE pImageEvent(), passing this class and _argDict["Image"] as parameters:
                pImageEvent.Invoke(this, _argDict["Image"] as ImageEventArgs);
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgFilterOne:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        /// <summary>
        /// Applies second specified filter to given image
        /// </summary>
        /// <param name="pUID"> Unique ID for Image </param>
        /// <param name="pImgWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImgHeight">the height (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        public void ApplyFilterTwo(string pUID, int pImgWidth, int pImgHeight, EventHandler<ImageEventArgs> pImageEvent)
        {
            // TRY checking for InvalidStringException and NullInstanceException from _imgEditor.ImgFilterTwo():
            try
            {
                // SET value of Img property to return value of _imgEditor.ImgFilterTwo(), passing result of _imgManager.ReturnImg() as a parameter:
                (_argDict["Image"] as ImageEventArgs).Img = _imgEditor.ImgFilterTwo(_imgManager.ReturnImg(pUID, pImgWidth, pImgHeight));

                // INVOKE pImageEvent(), passing this class and _argDict["Image"] as parameters:
                pImageEvent.Invoke(this, _argDict["Image"] as ImageEventArgs);
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgFilterTwo:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        /// <summary>
        /// Applies third specified filter to given image
        /// </summary>
        /// <param name="pUID"> Unique ID for Image </param>
        /// <param name="pImgWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImgHeight">the height (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        public void ApplyFilterThree(string pUID, int pImgWidth, int pImgHeight, EventHandler<ImageEventArgs> pImageEvent)
        {
            // TRY checking for InvalidStringException and NullInstanceException from _imgEditor.ImgFilterThree():
            try
            {
                // SET value of Img property to return value of _imgEditor.ImgFilterThree(), passing result of _imgManager.ReturnImg() as a parameter:
                (_argDict["Image"] as ImageEventArgs).Img = _imgEditor.ImgFilterThree(_imgManager.ReturnImg(pUID, pImgWidth, pImgHeight));

                // INVOKE pImageEvent(), passing this class and _argDict["Image"] as parameters:
                pImageEvent.Invoke(this, _argDict["Image"] as ImageEventArgs);
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgFilterThree:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        /// <summary>
        /// Applies fourth specified filter to given image
        /// </summary>
        /// <param name="pUID"> Unique ID for Image </param>
        /// <param name="pImgWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImgHeight">the height (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        public void ApplyFilterFour(string pUID, int pImgWidth, int pImgHeight, EventHandler<ImageEventArgs> pImageEvent)
        {
            // TRY checking for InvalidStringException and NullInstanceException from _imgEditor.ImgFilterFour():
            try
            {
                // SET value of Img property to return value of _imgEditor.ImgFilterFour(), passing result of _imgManager.ReturnImg() as a parameter:
                (_argDict["Image"] as ImageEventArgs).Img = _imgEditor.ImgFilterFour(_imgManager.ReturnImg(pUID, pImgWidth, pImgHeight));

                // INVOKE pImageEvent(), passing this class and _argDict["Image"] as parameters:
                pImageEvent.Invoke(this, _argDict["Image"] as ImageEventArgs);
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgFilterFour:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        #endregion


        #region IMPLEMENTATION OF IREPLACECOLOURIMG

        /// <summary>
        /// Replaces an image with a new brightness change
        /// </summary>
        /// <param name="pUID"> Unique ID of Image </param>
        /// <param name="pImgWidth">the width (in pixels) of the desired image</param>
        /// <param name="pImgHeight">the height (in pixels) of the desired image</param>
        /// <param name="pBrt"> Brightness multiplier </param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        public void ReplaceBrightnessImg(string pUID, int pImgWidth, int pImgHeight, int pBrt, EventHandler<ImageEventArgs> pImageEvent)
        {
            // TRY checking if _imgManager.ReturnImg or _imgEditor.ImgBrightness throws an exception:
            try
            {
                // SET value of Img property to return value of _imgEditor.ImgBrightness() passing _imgManager.ReturnImg() and pBrt as parameters:
                (_argDict["Image"] as ImageEventArgs).Img = _imgEditor.ImgBrightness(_imgManager.ReturnImg(pUID, pImgWidth, pImgHeight), pBrt);

                // INVOKE pImageEvent(), passing this class and _argDict["Image"] as parameters:
                pImageEvent.Invoke(this, _argDict["Image"] as ImageEventArgs);
            }
            // CATCH InvalidStringException from ReturnImg():
            catch (InvalidStringException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW a new InvalidStringException(), with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgBrightness:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        /// <summary>
        /// Replaces an image with a new contrast change
        /// </summary>
        /// <param name="pUID"> Unique ID of Image </param>
        /// <param name="pImgWidth">the width (in pixels) of the desired image</param>
        /// <param name="pImgHeight">the height (in pixels) of the desired image</param>
        /// <param name="pCon"> Contrast multiplier </param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        public void ReplaceContrastImg(string pUID, int pImgWidth, int pImgHeight, int pCon, EventHandler<ImageEventArgs> pImageEvent)
        {
            // TRY checking if _imgManager.ReturnImg or _imgEditor.ImgContrast throws an exception:
            try
            {
                // SET value of Img property to return value of _imgEditor.ImgContrast() passing _imgManager.ReturnImg() and pCon as a parameters:
                (_argDict["Image"] as ImageEventArgs).Img = _imgEditor.ImgContrast(_imgManager.ReturnImg(pUID, pImgWidth, pImgHeight), pCon);

                // INVOKE pImageEvent(), passing this class and _argDict["Image"] as parameters:
                pImageEvent.Invoke(this, _argDict["Image"] as ImageEventArgs);
            }
            // CATCH InvalidStringException from ReturnImg():
            catch (InvalidStringException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW a new InvalidStringException(), with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgContrast:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        /// <summary>
        /// Replaces an image with a new saturation change
        /// </summary>
        /// <param name="pUID"> Unique ID of Image </param>
        /// <param name="pImgWidth">the width (in pixels) of the desired image</param>
        /// <param name="pImgHeight">the height (in pixels) of the desired image</param>
        /// <param name="pSat"> Saturation multiplier </param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        public void ReplaceSaturationImg(string pUID, int pImgWidth, int pImgHeight, int pSat, EventHandler<ImageEventArgs> pImageEvent)
        {
            // TRY checking if _imgManager.ReturnImg  or _imgEditor.ImgSaturation throws an exception:
            try
            {
                // SET value of Img property to return value of _imgEditor.ImgSaturation() passing _imgManager.ReturnImg() and pSat as parameters:
                (_argDict["Image"] as ImageEventArgs).Img = _imgEditor.ImgSaturation(_imgManager.ReturnImg(pUID, pImgWidth, pImgHeight), pSat);

                // INVOKE pImageEvent(), passing this class and _argDict["Image"] as parameters:
                pImageEvent.Invoke(this, _argDict["Image"] as ImageEventArgs);
            }
            // CATCH InvalidStringException from ReturnImg():
            catch (InvalidStringException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW a new InvalidStringException(), with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
            // CATCH NullInstanceException from _imgEditor.ImgSaturation:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        #endregion


        #region IMPLEMENTATION OF IREPLACECROPIMG

        /// <summary>
        /// Replaces an image with a crop change
        /// </summary>
        /// <param name="pFrame"> Frame for cropped image </param>
        /// <param name="pCropBox"> User cropped rectangle </param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        public void ReplaceCropImg(Bitmap pFrame, Rectangle pCropBox, EventHandler<ImageEventArgs> pImageEvent)
        {
            // TRY checking if _imgEditor.Crop throws an exception:
            try
            {
                // SET value of Img property to return value of _imgEditor.ImgBrightness() passing _imgManager.ReturnImg() and pBrt as parameters:
                (_argDict["Image"] as ImageEventArgs).Img = _imgEditor.ImgCrop(pFrame, pCropBox);

                // INVOKE pImageEvent(), passing this class and _argDict["Image"] as parameters:
                pImageEvent.Invoke(this, _argDict["Image"] as ImageEventArgs);
            }
            // CATCH NullInstanceException from _imgEditor.ImgCrop:
            catch (NullInstanceException pException)
            {
                // WRITE error message to console:
                Console.WriteLine(pException.Message);

                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException(pException.Message);
            }
        }

        #endregion


        #region IMPLEMENTATION OF IREPLACESIZEIMG



        #endregion
    }
}
