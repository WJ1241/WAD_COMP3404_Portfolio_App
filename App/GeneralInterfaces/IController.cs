using System;

namespace App.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to behave as a 'Controller' in an MVC architecture
    /// Author: William Smith, William Eardley and Declan Kerby-Collins
    /// Date: 09/03/21
    /// </summary>
    public interface IController
    {
        #region METHODS

        /// <summary>
        /// Calls Static Application class methods, to create Windows Forms Application
        /// </summary>
        void RunApplication();

        /// <summary>
        /// Creates an edit screen, and initialises with required commands and values
        /// </summary>
        /// <param name="pImageFP"> File path of current image displayed so Edit screen shows the correct image </param>
        void CreateEditScrn(string pImageFP);

        /// <summary>
        /// Disposes of IDisposable objects, used for IDisposable objects not stored in a collection
        /// </summary>
        /// <param name="pDisposable"> IDisposable object to be removed </param>
        void DisposableRemoval(IDisposable pDisposable);

        /// <summary>
        /// Disposes of objects from a collection addressed via integer parameter
        /// </summary>
        /// <param name="pUID"> Integer value to address a specific Form to remove </param>
        void DisposableRemoval(int pUID);

        #endregion
    }
}
