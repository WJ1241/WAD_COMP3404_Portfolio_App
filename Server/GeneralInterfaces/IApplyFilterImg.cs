using System;
using Server.CustomEventArgs;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to replace a specified image with a filter layer
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 24/03/22
    /// </summary>
    public interface IApplyFilterImg
    {
        #region FILTERS

        /// <summary>
        /// Applies first specified filter to given image
        /// </summary>
        /// <param name="pUID"> Unique ID for Image </param>
        /// <param name="pFrameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pFrameHeight">the height (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        void ApplyFilterOne(string pUID, int pFrameWidth, int pFrameHeight, EventHandler<ImageEventArgs> pImageEvent);

        /// <summary>
        /// Applies second specified filter to given image
        /// </summary>
        /// <param name="pUID"> Unique ID for Image </param>
        /// <param name="pFrameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pFrameHeight">the height (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        void ApplyFilterTwo(string pUID, int pFrameWidth, int pFrameHeight, EventHandler<ImageEventArgs> pImageEvent);

        /// <summary>
        /// Applies third specified filter to given image
        /// </summary>
        /// <param name="pUID"> Unique ID for Image </param>
        /// <param name="pFrameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pFrameHeight">the height (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        void ApplyFilterThree(string pUID, int pFrameWidth, int pFrameHeight, EventHandler<ImageEventArgs> pImageEvent);

        /// <summary>
        /// Applies fourth specified filter to given image
        /// </summary>
        /// <param name="pUID"> Unique ID for Image </param>
        /// <param name="pFrameWidth">the width (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pFrameHeight">the height (in pixels) of the 'frame' it is to occupy</param>
        /// <param name="pImageEvent"> Event to invoke with changed ImageEventArgs object </param>
        void ApplyFilterFour(string pUID, int pFrameWidth, int pFrameHeight, EventHandler<ImageEventArgs> pImageEvent);

        #endregion
    }
}
