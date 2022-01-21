using Server.GeneralInterfaces;

namespace Server.InitialisingInterfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with an IManageImg object
    /// Author: William Smith
    /// Date: 21/11/21
    /// </summary>
    public interface IInitialiseIManageImg
    {
        #region METHODS

        /// <summary>
        /// Initialises an implementation with an IManageImg object
        /// </summary>
        /// <param name="pManageImg"> Reference to IManageImg object </param>
        void Initialise(IManageImg pManageImg);

        #endregion
    }
}
