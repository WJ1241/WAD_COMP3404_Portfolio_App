﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3451Project.EnginePackage.Services.Commands
{
    /// <summary>
    /// Class which contains an Action with Zero Parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public class CommandZeroParam : ICommandZeroParam
    {
        #region FIELD VARIABLES

        // DECLARE an Action, name it '_action':
        private Action _action;

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
            set
            {
                // SET value of _action to incoming value:
                _action = value;
            }
        }

        #endregion
    }
}
