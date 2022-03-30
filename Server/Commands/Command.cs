using System;
using Server.GeneralInterfaces;


namespace Server.Commands
{
    #region COMMANDZEROPARAM

    /// <summary>
    /// Class which contains an Action with Zero Parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 03/03/22
    /// </summary>
    public class CommandZeroParam : ICommandZeroParam, IName
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
        public Action MethodRef
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

    #endregion


    #region COMMANDPARAM<T>

    /// <summary>
    /// Class which contains an Action with ONE Parameter
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 10/03/22
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    public class CommandParam<T> : ICommandParam<T>, IName
    {
        #region FIELD VARIABLES

        // DECLARE an Action, name it '_action':
        private Action<T> _action;

        // DECLARE a T, name it '_firstParam':
        private T _firstParam;

        // DECLARE a string, name it '_name':
        private string _name;

        #endregion


        #region IMPLEMENTATION OF ICOMMAND

        /// <summary>
        /// Executes specified method
        /// </summary>
        public void ExecuteMethod()
        {
            // CALL _action(), passing _firstParam as a parameter:
            _action(_firstParam);
        }

        #endregion


        #region IMPLEMENTATION OF ICOMMANDPARAM<T>

        /// <summary>
        /// Property which allows write access to the desired first parameter type
        /// </summary>
        public T FirstParam
        {
            set
            {
                // SET value of _firstParam to incoming value:
                _firstParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to a reference of a method with ONE parameter
        /// </summary>
        public Action<T> MethodRef
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

    #endregion


    #region COMMANDPARAM<T, U>

    /// <summary>
    /// Class which contains an Action with TWO Parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 10/03/22
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    /// <typeparam name="U"> Generic 'U', can be any type </typeparam>
    public class CommandParam<T, U> : ICommandParam<T, U>, IName
    {
        #region FIELD VARIABLES

        // DECLARE an Action, name it '_action':
        private Action<T, U> _action;

        // DECLARE a T, name it '_firstParam':
        private T _firstParam;

        // DECLARE a U, name it '_secondParam':
        private U _secondParam;

        // DECLARE a string, name it '_name':
        private string _name;

        #endregion


        #region IMPLEMENTATION OF ICOMMAND

        /// <summary>
        /// Executes specified method
        /// </summary>
        public void ExecuteMethod()
        {
            // CALL _action(), passing _firstParam and _secondParam as parameters:
            _action(_firstParam, _secondParam);
        }

        #endregion


        #region IMPLEMENTATION OF ICOMMANDPARAM<T, U>

        /// <summary>
        /// Property which allows write access to the desired first parameter type
        /// </summary>
        public T FirstParam
        {
            set
            {
                // SET value of _firstParam to incoming value:
                _firstParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to the desired second parameter type
        /// </summary>
        public U SecondParam
        {
            set
            {
                // SET value of _firstParam to incoming value:
                _secondParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to a reference of a method with TWO parameters
        /// </summary>
        public Action<T, U> MethodRef
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

    #endregion


    #region COMMANDPARAM<T, U, V>

    /// <summary>
    /// Class which contains an Action with THREE Parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 10/03/22
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    /// <typeparam name="U"> Generic 'U', can be any type </typeparam>
    /// <typeparam name="V"> Generic 'V', can be any type </typeparam>
    public class CommandParam<T, U, V> : ICommandParam<T, U, V>, IName
    {
        #region FIELD VARIABLES

        // DECLARE an Action, name it '_action':
        private Action<T, U, V> _action;

        // DECLARE a T, name it '_firstParam':
        private T _firstParam;

        // DECLARE a U, name it '_secondParam':
        private U _secondParam;

        // DECLARE a V, name it '_thirdParam':
        private V _thirdParam;

        // DECLARE a string, name it '_name':
        private string _name;

        #endregion


        #region IMPLEMENTATION OF ICOMMAND

        /// <summary>
        /// Executes specified method
        /// </summary>
        public void ExecuteMethod()
        {
            // CALL _action(), passing _firstParam, _secondParam and _thirdParam as parameters:
            _action(_firstParam, _secondParam, _thirdParam);
        }

        #endregion


        #region IMPLEMENTATION OF ICOMMANDPARAM<T, U, V>

        /// <summary>
        /// Property which allows write access to the desired first parameter type
        /// </summary>
        public T FirstParam
        {
            set
            {
                // SET value of _firstParam to incoming value:
                _firstParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to the desired second parameter type
        /// </summary>
        public U SecondParam
        {
            set
            {
                // SET value of _firstParam to incoming value:
                _secondParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to the desired third parameter type
        /// </summary>
        public V ThirdParam
        {
            set
            {
                // SET value of _thirdParam to incoming value:
                _thirdParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to a reference of a method with THREE parameters
        /// </summary>
        public Action<T, U, V> MethodRef
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

    #endregion


    #region COMMANDPARAM<T, U, V, W>

    /// <summary>
    /// Class which contains an Action with FOUR Parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 23/03/22
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    /// <typeparam name="U"> Generic 'U', can be any type </typeparam>
    /// <typeparam name="V"> Generic 'V', can be any type </typeparam>
    /// <typeparam name="W"> Generic 'W', can be any type </typeparam>
    public class CommandParam<T, U, V, W> : ICommandParam<T, U, V, W>, IName
    {
        #region FIELD VARIABLES

        // DECLARE an Action, name it '_action':
        private Action<T, U, V, W> _action;

        // DECLARE a T, name it '_firstParam':
        private T _firstParam;

        // DECLARE a U, name it '_secondParam':
        private U _secondParam;

        // DECLARE a V, name it '_thirdParam':
        private V _thirdParam;

        // DECLARE a W, name it '_fourthParam':
        private W _fourthParam;

        // DECLARE a string, name it '_name':
        private string _name;

        #endregion


        #region IMPLEMENTATION OF ICOMMAND

        /// <summary>
        /// Executes specified method
        /// </summary>
        public void ExecuteMethod()
        {
            // CALL _action(), passing _firstParam, _secondParam, _thirdParam and _fourthParam as parameters:
            _action(_firstParam, _secondParam, _thirdParam, _fourthParam);
        }

        #endregion


        #region IMPLEMENTATION OF ICOMMANDPARAM<T, U, V, W>

        /// <summary>
        /// Property which allows write access to the desired first parameter type
        /// </summary>
        public T FirstParam
        {
            set
            {
                // SET value of _firstParam to incoming value:
                _firstParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to the desired second parameter type
        /// </summary>
        public U SecondParam
        {
            set
            {
                // SET value of _firstParam to incoming value:
                _secondParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to the desired third parameter type
        /// </summary>
        public V ThirdParam
        {
            set
            {
                // SET value of _thirdParam to incoming value:
                _thirdParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to the desired fourth parameter type
        /// </summary>
        public W FourthParam
        {
            set
            {
                // SET value of _fourthParam to incoming value:
                _fourthParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to a reference of a method with FOUR parameters
        /// </summary>
        public Action<T, U, V, W> MethodRef
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

    #endregion


    #region COMMANDPARAM<T, U, V, W, X>

    /// <summary>
    /// Class which contains an Action with FIVE Parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 25/03/22
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    /// <typeparam name="U"> Generic 'U', can be any type </typeparam>
    /// <typeparam name="V"> Generic 'V', can be any type </typeparam>
    /// <typeparam name="W"> Generic 'W', can be any type </typeparam>
    /// <typeparam name="X"> Generic 'X', can be any type </typeparam>
    public class CommandParam<T, U, V, W, X> : ICommandParam<T, U, V, W, X>, IName
    {
        #region FIELD VARIABLES

        // DECLARE an Action, name it '_action':
        private Action<T, U, V, W, X> _action;

        // DECLARE a T, name it '_firstParam':
        private T _firstParam;

        // DECLARE a U, name it '_secondParam':
        private U _secondParam;

        // DECLARE a V, name it '_thirdParam':
        private V _thirdParam;

        // DECLARE a W, name it '_fourthParam':
        private W _fourthParam;

        // DECLARE an X, name it '_fifthParam':
        private X _fifthParam;

        // DECLARE a string, name it '_name':
        private string _name;

        #endregion


        #region IMPLEMENTATION OF ICOMMAND

        /// <summary>
        /// Executes specified method
        /// </summary>
        public void ExecuteMethod()
        {
            // CALL _action(), passing _firstParam, _secondParam, _thirdParam _fourthParam and _fifthParam as parameters:
            _action(_firstParam, _secondParam, _thirdParam, _fourthParam, _fifthParam);
        }

        #endregion


        #region IMPLEMENTATION OF ICOMMANDPARAM<T, U, V, W, X>

        /// <summary>
        /// Property which allows write access to the desired first parameter type
        /// </summary>
        public T FirstParam
        {
            set
            {
                // SET value of _firstParam to incoming value:
                _firstParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to the desired second parameter type
        /// </summary>
        public U SecondParam
        {
            set
            {
                // SET value of _firstParam to incoming value:
                _secondParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to the desired third parameter type
        /// </summary>
        public V ThirdParam
        {
            set
            {
                // SET value of _thirdParam to incoming value:
                _thirdParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to the desired fourth parameter type
        /// </summary>
        public W FourthParam
        {
            set
            {
                // SET value of _fourthParam to incoming value:
                _fourthParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to the desired fourth parameter type
        /// </summary>
        public X FifthParam
        {
            set
            {
                // SET value of _fifthParam to incoming value:
                _fifthParam = value;
            }
        }

        /// <summary>
        /// Property which allows write access to a reference of a method with FOUR parameters
        /// </summary>
        public Action<T, U, V, W, X> MethodRef
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

    #endregion
}
