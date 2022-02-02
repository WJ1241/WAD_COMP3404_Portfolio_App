using System;
using System.Collections.Generic;
using System.Drawing;
using Server.Exceptions;
using Server.InitialisingInterfaces;
using Server.GeneralInterfaces;

namespace Server
{
    /// <summary>
    /// Class which acts as the 'Server' for the Application
    /// Author: William Smith & Marc Price
    /// Date: 03/12/21
    /// </summary>
    /// <REFERENCE> Price, M (2021) 'IServer.cs'. COMP3404: Applied Software Engineering. Available at: https://worcesterbb.blackboard.com/. (Accessed: 20 November 2021). </REFERENCE>
    public class ImageServer : IServer, IACRotate, IInitialiseParam<IEditImg>, IInitialiseParam<IManageImg>
    {
        #region FIELD VARIABLES

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


        #region IMPLEMENTATION OF IINITIALISEPARAM<IEDITIMG>

        /// <summary>
        /// Initialises an implementer with an IEditImg object
        /// </summary>
        /// <param name="pEditImg"> Reference to IEditImg object </param>
        public void Initialise(IEditImg pEditImg)
        {
            // IF pEditImg IS NOT null:
            if (pEditImg != null)
            {
                // INITIALISE _imgEditor with reference to pEditImg:
                _imgEditor = pEditImg;
            }
            // IF pEditImg IS null:
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: Server is being initialised with a null IEditImg object!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<IMANAGEIMG>

        /// <summary>
        /// Initialises an implementer with an IManageImg object
        /// </summary>
        /// <param name="pManageImg"> Reference to IManageImg object </param>
        public void Initialise(IManageImg pManageImg)
        {
            // IF pManageImg IS NOT null:
            if (pManageImg != null)
            {
                // INITIALISE _imgManager with reference to pManageImg:
                _imgManager = pManageImg;
            }
            // IF pManageImg IS null:
            else
            {
                // THROW new NullInstanceException, with corresponding message:
                throw new NullInstanceException("ERROR: Server is being initialised with a null IManageImg object!");
            }
        }

        #endregion


        #region IMPLEMENTATION OF ISERVER

        /// <summary>
        /// Load the media items pointed to by 'pathfilenames' into the Server's data store.
        /// The strings in the collection act as unique identifiers for images in the Server's data store.
        /// </summary>
        /// <param name="pPathfilenames">a collection of one or more strings; each string containing path/filename for an image file to be loaded</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        public IList<String> Load(IList<String> pPathfilenames) 
        {
            // TRY checking if ReturnFilteredList throws an exception:
            try
            {
                // RETURN result of _imgManager's ReturnFilteredList method, passing pPathfilenames as a parameter:
                return _imgManager.ReturnFilteredList(pPathfilenames);
            }
            // CATCH FileAlreadyStoredException from ReturnFilteredList:
            catch (FileAlreadyStoredException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new FileAlreadyStoredException, with corresponding message:
                throw new FileAlreadyStoredException(pException.Message);
            }
        }

        /// <summary>
        /// Request a copy of the image specified by 'pUid', scaled according to the dimensions given by pFrameWidth and pFrameHeight.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image requested</param>
        /// <param name="pFrameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pFrameHeight">the height (in pixles) of the 'frame' it is to occupy</param>
        /// <returns>the Image identified by pUid</returns>
        public Image GetImage(String pUid, int pFrameWidth, int pFrameHeight)
        {
            // TRY checking if _imgManager.ReturnImg throws an exception:
            try
            {
                // RETURN result of _imgManager's ReturnImg method, passing pUid, pFrameWidth, and pFrameHeight as parameters:
                return _imgManager.ReturnImg(pUid, pFrameWidth, pFrameHeight);
            }
            // CATCH InvalidStringException from ReturnImg:
            catch (InvalidStringException pException)
            {
                // WRITE error message to debug console:
                System.Diagnostics.Debug.WriteLine(pException.Message);

                // THROW new InvalidStringException, with corresponding message:
                throw new InvalidStringException(pException.Message);
            }
        }

        /// <summary>
        /// Rotate the image specified by 'pUid'.
        /// The client will need to request a copy of the Image to update its view-copy of the image accordingly.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be rotated</param>
        public void RotateImage(String pUid)
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
        public void HorizontalFlipImage(String pUid)
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
        public void VerticalFlipImage(String pUid)
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
        public void ACRotateImage(String pUid)
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
    }
}
