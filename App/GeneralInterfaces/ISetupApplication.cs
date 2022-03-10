

namespace App.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to setup and run an application
    /// Authors: William Smith, William Eardley, Declan Kerby-Collins
    /// Date: 10/03/22
    /// </summary>
    public interface ISetupApplication
    {
        #region METHODS

        /// <summary>
        /// Setups all necessary dependencies and requirements for an application to start
        /// </summary>
        void SetupApplication();

        /// <summary>
        /// Calls Static Application class methods, to create Windows Forms Application
        /// </summary>
        void RunApplication();

        #endregion
    }
}
