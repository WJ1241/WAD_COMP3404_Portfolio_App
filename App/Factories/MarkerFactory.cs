using System;
using Server.Exceptions;
using Server.GeneralInterfaces;

namespace App.Factories
{
    /// <summary>
    /// Class used for creating and returning an 'IMarker' type object
    /// Author: William Smith
    /// Date: 26/11/21
    /// </summary>
    public class MarkerFactory : IMarkerFactory
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of MarkerFactory
        /// </summary>
        public MarkerFactory()
        {

        }

        #endregion


        #region IMPLEMENTATION OF IMARKERFACTORY

        /// <summary>
        /// Instantiates an object of type 'IMarker' and returns to caller
        /// </summary>
        /// <typeparam name="T"> Generic Type, implements IMarker </typeparam>
        /// <returns> Newly Created IMarker object </returns>
        public IMarker Create<T>() where T : IMarker, new()
        {
            // DECLARE an IMarker, name it '_tempMarker':
            IMarker _tempMarker;

            // TRY checking if class implements IMarker
            try
            {
                // INSTANTIATE _tempMarker as new IMarker():
                _tempMarker = new T();
            }
            // CATCH Exception from creation of object:
            catch (Exception)
            {
                // THROW new ClassDoesNotExistException, with corresponding message:
                throw new ClassDoesNotExistException("ERROR: Class passed through parameter of method does not exist or implement IMarker!");
            }

            // RETURN _tempMarker:
            return _tempMarker;
        }

        #endregion
    }
}
