using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    /// <summary>
    /// Interface which allows implementations send commands to another class
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/03/22
    /// </summary>
    public interface ICommandSender
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows write access to a command invoking Action
        /// </summary>
        Action<ICommand> InvokeCommand { set; }

        #endregion
    }
}
