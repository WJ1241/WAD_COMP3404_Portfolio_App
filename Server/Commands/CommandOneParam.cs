using System;

namespace Server.Commands
{
    /// <summary>
    /// Class which contains an Action with ONE Parameter
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    /// <typeparam name="T"> Any Type, 'T' for 'T'ype </typeparam>
    public class CommandOneParam<T> : ICommandOneParam<T>, IName
    {
        #region FIELD VARIABLES

        // DECLARE an Action, name it '_action':
        private Action<T> _action;

        // DECLARE a T, name it '_data':
        private T _data;

        // DECLARE a string, name it '_name':
        private string _name;

        #endregion


        #region IMPLEMENTATION OF ICOMMAND

        /// <summary>
        /// Executes specified method
        /// </summary>
        public void ExecuteMethod()
        {
            // CALL _action(), passing _data as a parameter:
            _action(_data);
        }

        #endregion


        #region IMPLEMENTATION OF ICOMMANDONEPARAM

        /// <summary>
        /// Property which allows write access to the desired first parameter type
        /// </summary>
        public T Data
        {
            set
            {
                // SET value of _data to incoming value:
                _data = value;
            }
        }

        /// <summary>
        /// Property which allows write access to a reference of a method with ONE parameter
        /// </summary>
        public Action<T> MethodRef
        {
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
