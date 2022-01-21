using Server.GeneralInterfaces;

namespace App.Factories
{
    /// <summary>
    /// Interface which allows implementations to create objects of 'IMarker'
    /// Author: William Smith
    /// Date: 26/11/21
    /// </summary>
    public interface IMarkerFactory
    {
        #region METHODS

        /// <summary>
        /// Instantiates an object of type 'IMarker' and returns to caller
        /// </summary>
        /// <typeparam name="T"> Generic Type, implements IMarker </typeparam>
        /// <returns> Newly Created IMarker object </returns>
        IMarker Create<T>() where T : IMarker, new();

        #endregion
    }
}
