using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3451Project.EnginePackage.Services.Commands
{
    /// <summary>
    /// Interface which allows implementations to schedule commands
    /// Author: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public interface ICommandInvoker
    {
        #region METHODS

        /// <summary>
        /// Method which invokes a command and completes given processes
        /// </summary>
        void InvokeCommand(ICommand pCommand);

        #endregion
    }
}
