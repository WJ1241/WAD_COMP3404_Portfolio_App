using Server.GeneralInterfaces;

namespace App.Services.Factories.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to create a Factory of any chosen type
    /// Author: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 09/03/22
    /// </summary>
    /// <typeparam name="A"> Any Type, A for 'Abstract' </typeparam>
    public interface IFactory<A> : IService
    {
        #region METHODS

        /// <summary>
        /// Creates an object of type 'C' (Concrete) and returns it as its chosen type 'A' (Abstract)
        /// </summary>
        /// <typeparam name="C"> Generic Type which implements generic 'A' (Abstract) </typeparam>
        /// <returns> New instance of type 'C' (Concrete) </returns>
        A Create<C>() where C : A, new();

        #endregion
    }
}
