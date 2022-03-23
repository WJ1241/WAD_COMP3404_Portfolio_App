using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    #region ICOMMAND

    /// <summary>
    /// Interface which allows implementations to execute a method
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public interface ICommand
    {
        #region METHODS

        /// <summary>
        /// Executes specified method
        /// </summary>
        void ExecuteMethod();

        #endregion
    }

    #endregion


    #region ICOMMANDZEROPARAM

    /// <summary>
    /// Interface which allows implementations to contain a method with ZERO parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 03/03/22
    /// </summary>
    public interface ICommandZeroParam : ICommand
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows write access to a reference of a method with ZERO parameters
        /// </summary>
        Action MethodRef { get; set; }

        #endregion
    }

    #endregion


    #region ICOMMANDPARAM<T>

    /// <summary>
    /// Interface which allows implementations to contain a method with ONE parameter
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 10/03/22
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    public interface ICommandParam<T> : ICommand
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows write access to the desired first parameter type
        /// </summary>
        T FirstParam { set; }

        /// <summary>
        /// Property which allows write access to a reference of a method with ONE parameter
        /// </summary>
        Action<T> MethodRef { get; set; }

        #endregion
    }

    #endregion


    #region ICOMMANDPARAM<T, U>

    /// <summary>
    /// Interface which allows implementations to contain a method with TWO parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 10/03/22
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    /// <typeparam name="U"> Generic 'U', can be any type </typeparam>
    public interface ICommandParam<T, U> : ICommand
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows write access to the desired first parameter type
        /// </summary>
        T FirstParam { set; }

        /// <summary>
        /// Property which allows write access to the desired second parameter type
        /// </summary>
        U SecondParam { set; }

        /// <summary>
        /// Property which allows write access to a reference of a method with TWO parameters
        /// </summary>
        Action<T, U> MethodRef { get; set; }

        #endregion
    }

    #endregion


    #region ICOMMANDPARAM<T, U, V>

    /// <summary>
    /// Interface which allows implementations to contain a method with THREE parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 10/03/22
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    /// <typeparam name="U"> Generic 'U', can be any type </typeparam>
    /// <typeparam name="V"> Generic 'V', can be any type </typeparam>
    public interface ICommandParam<T, U, V> : ICommand
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows write access to the desired first parameter type
        /// </summary>
        T FirstParam { set; }

        /// <summary>
        /// Property which allows write access to the desired second parameter type
        /// </summary>
        U SecondParam { set; }

        /// <summary>
        /// Property which allows write access to the desired third parameter type
        /// </summary>
        V ThirdParam { set; }

        /// <summary>
        /// Property which allows write access to a reference of a method with THREE parameters
        /// </summary>
        Action<T, U, V> MethodRef { get; set; }

        #endregion
    }

    #endregion


    #region ICOMMANDPARAM<T, U, V>

    /// <summary>
    /// Interface which allows implementations to contain a method with FOUR parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 23/03/22
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    /// <typeparam name="U"> Generic 'U', can be any type </typeparam>
    /// <typeparam name="V"> Generic 'V', can be any type </typeparam>
    /// <typeparam name="W"> Generic 'W', can be any type </typeparam>
    public interface ICommandParam<T, U, V, W> : ICommand
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows write access to the desired first parameter type
        /// </summary>
        T FirstParam { set; }

        /// <summary>
        /// Property which allows write access to the desired second parameter type
        /// </summary>
        U SecondParam { set; }

        /// <summary>
        /// Property which allows write access to the desired third parameter type
        /// </summary>
        V ThirdParam { set; }

        /// <summary>
        /// Property which allows write access to the desired fourth parameter type
        /// </summary>
        W FourthParam { set; }

        /// <summary>
        /// Property which allows write access to a reference of a method with FOUR parameters
        /// </summary>
        Action<T, U, V, W> MethodRef { get; set; }

        #endregion
    }

    #endregion
}
