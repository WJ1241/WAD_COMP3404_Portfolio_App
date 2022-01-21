using System;
using Server.Exceptions;

namespace App.Factories
{
    /// <summary>
    /// Class used for creating and returning an 'IDisposable' type object
    /// Author: William Smith
    /// Date: 26/11/21
    /// </summary>
    public class DisposableFactory : IDisposableFactory
    {
        #region CONSTRUCTOR

        /// Constructor for objects of DisposableFactory
        /// </summary>
        public DisposableFactory()
        {

        }

        #endregion


        #region IMPLEMENTATION OF IDISPOSABLEFACTORY

        /// <summary>
        /// Instantiates an object of type 'IDisposable' and returns to caller
        /// </summary>
        /// <typeparam name="T"> Generic Type, implements IDisposable </typeparam>
        /// <returns> Newly Created IDisposable object </returns>
        public IDisposable Create<T>() where T : IDisposable, new()
        {
            // DECLARE an IDisposable, name it '_tempDisposable':
            IDisposable _tempDisposable;

            // TRY checking if class implements IDisposable
            try
            {
                // INSTANTIATE _tempDisposable as new IDisposable():
                _tempDisposable = new T();
            }
            // CATCH Exception from creation of object:
            catch (Exception)
            {
                // THROW new ClassDoesNotExistException, with corresponding message:
                throw new ClassDoesNotExistException("ERROR: Class passed through parameter of method does not exist or implement IDisposable!");
            }

            // RETURN _tempDisposable:
            return _tempDisposable;
        }

        #endregion
    }
}
