using Server.Delegates;

namespace GUI.InitialisingInterfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with a 'Rotation' Delegate Method
    /// Author: William Smith
    /// Date: 21/11/21
    /// </summary>
    public interface IInitialiseRotationDel
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a 'Rotation' Delegate
        /// </summary>
        /// <param name="pRotationDelegate"> Delegate used for Rotating object(s) </param>
        void Initialise(RotationDelegate pRotationDelegate);

        #endregion
    }
}
