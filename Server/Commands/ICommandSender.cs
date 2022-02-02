using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3451Project.EnginePackage.Services.Commands
{
    /// <summary>
    /// Interface which allows implementations send commands to another class
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public interface ICommandSender
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows read and write access to a command invoking method
        /// </summary>
        Action<ICommand> InvokeCommand { get; set; }

        #endregion
    }
}
