using System;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to rotate an object(s) anticlockwise
    /// Author: William Smith
    /// Date: 01/12/21
    /// </summary>
    public interface IACRotate
    {
        #region METHODS

        /// <summary>
        /// Rotate the image anticlockwise specified by 'pUid'.
        /// The client will need to request a copy of the Image to update its view-copy of the image accordingly.
        /// </summary>
        /// <param name="pUid">the unique identifier for the image to be rotated</param>
        void ACRotateImage(String pUid);

        #endregion
    }
}
