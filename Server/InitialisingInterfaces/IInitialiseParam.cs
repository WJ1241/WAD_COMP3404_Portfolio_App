using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.InitialisingInterfaces
{
    #region SINGLE PARAM INITIALISE

    /// <summary>
    /// Interface which allows implementations to be initialised with ONE value/object of any type
    /// Authors: William Smith, Declan Kerby-Collins, William Eardley
    /// Date: 02/02/2022
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    public interface IInitialiseParam<T>
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with ONE value/object of any type
        /// </summary>
        /// <param name="pT"> Value/Object of type T </param>
        void Initialise(T pT);

        #endregion
    }

    #endregion


    #region DOUBLE PARAM INITIALISE

    /// <summary>
    /// Interface which allows implementations to be initialised with TWO values/objects of any type
    /// Authors: William Smith, Declan Kerby-Collins, William Eardley
    /// Date: 02/02/2022
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    /// <typeparam name="U"> Generic 'U', can be any type </typeparam>
    public interface IInitialiseParam<T, U>
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with TWO values/objects of any type
        /// </summary>
        /// <param name="pT"> Value/Object of type T </param>
        /// <param name="pU"> Value/Object of type U </param>
        void Initialise(T pT, U pU);

        #endregion
    }


    #endregion


    #region TRIPLE PARAM INITIALISE

    /// <summary>
    /// Interface which allows implementations to be initialised with THREE values/objects of any type
    /// Authors: William Smith, Declan Kerby-Collins, William Eardley
    /// Date: 02/02/2022
    /// </summary>
    /// <typeparam name="T"> Generic 'T', can be any type </typeparam>
    /// <typeparam name="U"> Generic 'U', can be any type </typeparam>
    /// <typeparam name="V"> Generic 'V', can be any type </typeparam>
    public interface IInitialiseParam<T, U, V>
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with THREE values/objects of any type
        /// </summary>
        /// <param name="pT"> Value/Object of type T </param>
        /// <param name="pU"> Value/Object of type U </param>
        /// <param name="pV"> Value/Object of type V </param>
        void Initialise(T pT, U pU, V pV);

        #endregion
    }

    #endregion
}
