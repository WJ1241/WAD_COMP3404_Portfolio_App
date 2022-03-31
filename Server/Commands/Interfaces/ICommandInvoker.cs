using Server.GeneralInterfaces;

namespace Server.Commands.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to schedule commands
    /// Author: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 09/03/22
    /// </summary>
    public interface ICommandInvoker : IService
    {
        #region METHODS

        /// <summary>
        /// Method which invokes a command and completes given processes
        /// </summary>
        void InvokeCommand(ICommand pCommand);

        #endregion
    }
}
