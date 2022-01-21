using Server.Delegates;

namespace GUI.InitialisingInterfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with a 'VFlipImage' Delegate Method
    /// Author: William Smith
    /// Date: 21/11/21
    /// </summary>
    public interface IInitialiseVFlipImgDel
    {
        #region METHODS

        /// <summary>
        /// Method which initialises an object with a 'VFlipImage' Delegate
        /// </summary>
        /// <param name="pVFlipImageDelegate"> Delegate used for Vorizontally flipping image </param>
        void Initialise(VFlipImageDelegate pVFlipImageDelegate);

        #endregion
    }
}
