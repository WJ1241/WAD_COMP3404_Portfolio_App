using Server.CustomEventArgs;
using System;

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to listen to an event involving an image
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 13/03/22
    /// </summary>
    /// <typeparam name="EA"> Event Arguments for an Event Handler </typeparam>
    public interface IEventListener<EA>
    {
        #region EVENTS

        /// <summary>
        /// Event Handler which gives an object the caller of the method as well as necessary arguments to complete required behaviour
        /// </summary>
        /// <param name="pSource"> Object calling this method </param>
        /// <param name="pArgs"> Necessary arguments to complete behaviour </param>
        void OnEvent(object pSource, EA pArgs);

        #endregion
    }
}
