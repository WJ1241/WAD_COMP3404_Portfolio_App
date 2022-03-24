using System;
using System.Collections.Generic;
using System.Drawing;
using Server.CustomEventArgs;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface that allows implementations to act as a Server to an Application
    /// Author: William Smith, William Eardley, Declan Kerby-Collins & Marc Price
    /// Date: 24/03/22
    /// </summary>
    public interface IServer : IService
    {
        #region METHODS

        #region IMAGE UPLOAD

        /// <summary>
        /// The media items pointed to by 'pathfilenames' into the Server's data store.
        /// The strings in the collection act as unique identifiers for images in the Server's data store.
        /// </summary>
        /// <param name="pPathFileNames">a collection of one or more strings; each string containing path/filename for an image file to be loaded</param>
        /// /// <param name="pStringListEvent"> Event to invoke with changed StringListEventArgs object </param>
        void Load(IList<string> pPathFileNames, EventHandler<StringListEventArgs> pStringListEvent);

        /// <summary>
        /// Request a copy of the image specified by 'pUid', scaled according to the dimensions given by pFrameWidth and pFrameHeight.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image requested</param>
        /// <param name="pFrameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pFrameHeight">the height (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        void GetImage(string pUid, int pFrameWidth, int pFrameHeight, EventHandler<ImageEventArgs> pImageEvent);

        #endregion


        #region IMAGE MODIFICATION

        #region ORIENTATION

        /// <summary>
        /// Rotate the image specified by 'pUid'.
        /// The client will need to request a copy of the Image to update its view-copy of the image accordingly.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be rotated</param>
        void RotateImage(string pUid);

        /// <summary>
        /// Rotate the image anticlockwise specified by 'pUid'.
        /// The client will need to request a copy of the Image to update its view-copy of the image accordingly.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be rotated</param>
        void ACRotateImage(string pUid);

        /// <summary>
        /// Flip the image specified by 'pUid' horizontally.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be flipped</param>
        void HorizontalFlipImage(string pUid);

        /// <summary>
        /// Flip the image specified by 'pUid' vertically.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be flipped</param>
        void VerticalFlipImage(string pUid);

        #endregion

        #endregion

        #endregion
    }
}
