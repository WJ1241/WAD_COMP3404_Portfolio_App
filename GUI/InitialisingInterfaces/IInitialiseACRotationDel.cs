using Server.Delegates;

namespace GUI.InitialisingInterfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with a 'ACRotation' Delegate Method
    /// Author: William Smith
    /// Date: 01/12/21
    /// </summary>
    public interface IInitialiseACRotationDel
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a 'ACRotation' Delegate
        /// </summary>
        /// <param name="pACRotationDelegate"> Delegate used for Anticlockwise Rotating object(s) </param>
        void Initialise(ACRotationDelegate pACRotationDelegate);

        #endregion
    }
}
