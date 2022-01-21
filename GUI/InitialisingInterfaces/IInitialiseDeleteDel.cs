using System;
using Server.Delegates;

namespace GUI.InitialisingInterfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with a 'Delete' Delegate Method
    /// Author: William Smith
    /// Date: 01/12/21
    /// </summary>
    public interface IInitialiseDeleteDel
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with a 'Delete' Delegate
        /// </summary>
        /// <param name="pDeleteDelegate"> Delegate used for getting object(s) </param>
        void Initialise(DeleteDelegate pDeleteDelegate);

        #endregion
    }
}
