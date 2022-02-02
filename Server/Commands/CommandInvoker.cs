using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.GeneralInterfaces;

namespace COMP3451Project.EnginePackage.Services.Commands
{
    /// <summary>
    /// Class which invokes commands from a required process e.g. User input
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public class CommandInvoker : IService, ICommandInvoker
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
