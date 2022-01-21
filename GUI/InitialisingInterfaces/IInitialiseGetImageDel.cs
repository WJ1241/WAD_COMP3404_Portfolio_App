using Server.Delegates;

namespace GUI.InitialisingInterfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with a 'GetImage' Delegate Method
    /// Author: William Smith
    /// Date: 21/11/21
    /// </summary>
    public interface IInitialiseGetImageDel
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a 'GetImage' Delegate
        /// </summary>
        /// <param name="pGetImageDelegate"> Delegate used for getting object(s) </param>
        void Initialise(GetImageDelegate pGetImageDelegate);

        #endregion
    }
}
