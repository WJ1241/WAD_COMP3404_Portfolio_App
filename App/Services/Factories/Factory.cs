using App.Services.Factories.Interfaces;
using Server.Exceptions;

namespace App.Services.Factories
{
    /// <summary>
    /// Class which creates and returns an object of any type chosen by the user
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 09/03/22
    /// </summary>
    public class Factory<A> : IFactory<A>
    {
        #region IMPLEMENTATION OF IFACTORY<A>

        /// <summary>
        /// Creation method which returns an object of type 'A'
        /// </summary>
        /// <typeparam name="C"> Generic Type which implements generic 'A' </typeparam>
        /// <returns> New instance of type 'C' </returns>
        public A Create<C>() where C : A, new()
        {
            // DECLARE an object of type 'A' and instantiate an instance of 'C', name it '_tempObj':
            A _tempObj = new C();

            // IF _tempObj is an instance of type 'A':
            if (_tempObj is A)
            {
                // RETURN _tempObj to method caller:
                return _tempObj;
            }
            else
            {
                // THROW new ClassDoesNotExistException, with corresponding message:
                throw new ClassDoesNotExistException("ERROR: Class or Interface passed in placement for generic does not exist in program");
            }
        }

        #endregion
    }
}
