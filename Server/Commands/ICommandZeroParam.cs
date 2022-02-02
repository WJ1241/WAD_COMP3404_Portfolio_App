using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3451Project.EnginePackage.Services.Commands
{
    /// <summary>
    /// Interface which allows implementations to contain a method with ZERO parameters
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public interface ICommandZeroParam : ICommand
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows write access to a reference of a method with ZERO parameters
        /// </summary>
        Action Action { set; }

        #endregion
    }
}
