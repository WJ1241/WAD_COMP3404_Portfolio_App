using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to hold reference to an event to invoke without needing reference to an entire object which is unrelated
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 12/03/22
    /// </summary>
    /// <typeparam name="EA"> Event Arguments for an Event Handler </typeparam>
    public interface ISubscribe<EA>
    {
        #region METHODS

        /// <summary>
        /// Subscribes an object to an Event containing arguments in place of 'EA'
        /// </summary>
        /// <param name="pEvent"> Event Method which contains the arguments in place of 'EA' </param>
        void Subscribe(EventHandler<EA> pEvent);

        #endregion
    }
}
