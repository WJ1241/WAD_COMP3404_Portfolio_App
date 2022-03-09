

namespace Server.Commands
{
    /// <summary>
    /// Class which invokes commands from a required process e.g. User input
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public class CommandInvoker : ICommandInvoker
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of CommandScheduler
        /// </summary>
        public CommandInvoker()
        {
            // EMPTY CONSTRUCTOR
        }

        #endregion


        #region IMPLEMENTATION OF ICOMMANDINVOKER

        /// <summary>
        /// Method which invokes a command and completes given processes
        /// </summary>
        public void InvokeCommand(ICommand pCommand)
        {
            // CALL ExecuteMethod() on pCommand:
            pCommand.ExecuteMethod();
        }

        #endregion
    }
}
