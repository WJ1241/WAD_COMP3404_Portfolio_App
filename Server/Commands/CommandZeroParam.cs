using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    /// <summary>
    /// Class which contains an Action with Zero Parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 03/03/22
    /// </summary>
    public class CommandZeroParam : ICommandZeroParam
    {
        #region FIELD VARIABLES

        // DECLARE an Action, name it '_action':
        private Action _action;

        // DECLARE a string, name it '_name':
        private string _name;

        #endregion


        #region IMPLEMENTATION OF ICOMMAND

        /// <summary>
        /// Executes specified method
        /// </summary>
        public void ExecuteMethod()
        {
            // CALL _action():
            _action();
        }

        #endregion


        #region IMPLEMENTATION OF ICOMMANDZEROPARAM

        /// <summary>
        /// Property which allows write access to a reference of a method with ZERO parameters
        /// </summary>
        public Action Action
        {
            get
            {
                // RETURN value of _action:
                return _action;
            }
            set
            {
                // SET value of _action to incoming value:
                _action = value;
            }
        }

        #endregion


        #region IMPLEMENTATION OF INAME

        /// <summary>
        /// Property which allows read and write access to an implementation's name
        /// </summary>
        public string Name
        {
            get
            {
                // RETURN value of _name:
                return _name;
            }
            set
            {
                // SET value of _name to incoming value:
                _name = value;
            }
        }

        #endregion
    }
}
