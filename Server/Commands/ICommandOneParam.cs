using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
    /// <summary>
    /// Interface which allows implementations to contain a method with ONE parameter
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 03/03/22
    /// </summary>
    /// <typeparam name="T"> Any Type, 'T' for 'T'ype </typeparam>
    public interface ICommandOneParam<T> : ICommand
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows write access to the desired first parameter type
        /// </summary>
        T Data { set; }

        /// <summary>
        /// Property which allows write access to a reference of a method with ONE parameter
        /// </summary>
        Action<T> MethodRef { get; set; }

        #endregion
    }
}
