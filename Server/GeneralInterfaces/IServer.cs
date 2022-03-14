using System;
using System.Collections.Generic;
using System.Drawing;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface that allows implementations to act as a Server to an Application
    /// Author: William Smith, William Eardley, Declan Kerby-Collins & Marc Price
    /// Date: 26/11/21
    /// </summary>
    public interface IServer : IService
    {
        /// <summary>
        /// 
        /// the media items pointed to by 'pathfilenames' into the Server's data store.
		/// The strings in the collection act as unique identifiers for images in the Server's data store.
        /// </summary>
        /// <param name="pPathfilenames">a collection of one or more strings; each string containing path/filename for an image file to be loaded</param>
        /// <returns>the unique identifiers of the images that have been loaded</returns>
        void Load(IList<string> pPathfilenames);

        /// <summary>
        /// Request a copy of the image specified by 'pUid', scaled according to the dimensions given by pFrameWidth and pFrameHeight.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image requested</param>
        /// <param name="pFrameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pFrameHeight">the height (in pixles) of the 'frame' it is to occupy</param>
        /// <returns>the Image identified by pUid</returns>
        void GetImage(string pUid, int pFrameWidth, int pFrameHeight);

        /// <summary>
        /// Rotate the image specified by 'pUid'.
        /// The client will need to request a copy of the Image to update its view-copy of the image accordingly.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be rotated</param>
        void RotateImage(string pUid);

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

        /// <summary>
        /// Contrast change image.
        /// </summary>
        /// <param name="pImage"></param>
        /// <param name="pSat"></param>
        void Contrast(Image pImage, int pSat);

    }
}
