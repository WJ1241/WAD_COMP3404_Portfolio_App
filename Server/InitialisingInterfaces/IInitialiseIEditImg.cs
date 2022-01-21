using Server.GeneralInterfaces;

namespace Server.InitialisingInterfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with an IEditImg object
    /// Author: William Smith
    /// Date: 21/11/21
    /// </summary>
    public interface IInitialiseIEditImg
    {
        #region METHODS

        /// <summary>
        /// Initialises an implementation with an IEditImg object
        /// </summary>
        /// <param name="pEditImg"> Reference to IEditImg object </param>
        void Initialise(IEditImg pEditImg);

        #endregion
    }
}
