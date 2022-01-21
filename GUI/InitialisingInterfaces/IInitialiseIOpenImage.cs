using GUI.Logic;

namespace GUI.InitialisingInterfaces
{
    /// <summary>
    /// Interface which allows implementations to be initialised with an 'IOpenImage' object
    /// Author: William Smith
    /// Date: 01/12/21
    /// </summary>
    public interface IInitialiseIOpenImage
    {
        #region METHODS

        /// <summary>
        /// Initialises an object with an 'IOpenImage' instance
        /// </summary>
        /// <param name="pOpenImage"> Instance of IOpenImage </param>
        void Initialise(IOpenImage pOpenImage);

        #endregion
    }
}
