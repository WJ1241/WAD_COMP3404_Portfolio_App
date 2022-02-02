using Server.GeneralInterfaces;

namespace App.Services
{
    /// <summary>
    /// Interface which allows implementations to return Services to a 
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public interface IServiceLocator
    {
        #region METHODS

        /// <summary>
        /// Returns an Instance of IService, but allows user to choose the concrete implementation
        /// </summary>
        /// <typeparam name="C"> 'C'oncrete type chosen by user </typeparam>
        /// <returns> Instance of IService </returns>
        public IService GetService<C>() where C : IService, new();

        #endregion
    }
}
