

namespace App.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to start an application
    /// Author: William Smith
    /// Date: 12/11/21
    /// </summary>
    public interface IApplicationStart
    {
        #region METHODS

        /// <summary>
        /// Calls Static Application class methods, to create Windows Forms Application
        /// </summary>
        void RunApplication();

        #endregion
    }
}
