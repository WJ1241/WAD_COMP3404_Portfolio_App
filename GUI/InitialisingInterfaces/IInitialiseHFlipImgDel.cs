using Server.Delegates;

namespace GUI.InitialisingInterfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with a 'HFlipImg' Delegate Method
    /// Author: William Smith
    /// Date: 21/11/21
    /// </summary>
    public interface IInitialiseHFlipImgDel
    {
        #region METHODS

        /// <summary>
        /// Method which initialises an object with a 'HFlipImage' Delegate
        /// </summary>
        /// <param name="pHFlipImageDelegate"> Delegate used for Horizontally flipping image </param>
        void Initialise(HFlipImageDelegate pHFlipImageDelegate);

        #endregion
    }
}
