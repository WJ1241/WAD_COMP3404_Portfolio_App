using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Commands
{
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
}
