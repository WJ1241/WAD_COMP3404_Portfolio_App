using Server.Delegates;

namespace GUI.InitialisingInterfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with a 'Load' Delegate Method
    /// Author: William Smith
    /// Date: 01/12/21
    /// </summary>
    public interface IInitialiseLoadDel
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a 'Load' Delegate
        /// </summary>
        /// <param name="pLoadDelegate"> Delegate used for getting object(s) </param>
        void Initialise(LoadDelegate pLoadDelegate);

        #endregion
    }
}
