using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP3451Project.EnginePackage.Services.Commands
{
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
}
