using System;

namespace App.Factories
{
    /// <summary>
    /// Interface which allows implementations to create objects of 'IDisposable'
    /// Author: William Smith
    /// Date: 26/11/21
    /// </summary>
    public interface IDisposableFactory
    {
        #region METHODS

        /// <summary>
        /// Instantiates an object of type 'IDisposable' and returns to caller
        /// </summary>
        /// <typeparam name="T"> Generic Type, implements IDisposable </typeparam>
        /// <returns> Newly Created IDisposable object </returns>
        IDisposable Create<T>() where T : IDisposable, new();

        #endregion
    }
}
