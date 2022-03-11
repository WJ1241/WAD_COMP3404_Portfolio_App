

namespace TestGUI.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to have accessible bool Properties to ensure that EventHandlers are being used correctly
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 11/03/22
    /// </summary>
    public interface IMockFishyHome
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows read access to a boolean to test if ImgChangeEvent was called
        /// </summary>
        public bool ImgChangeEventCalled { get; }

        /// <summary>
        /// Property which allows read access to a boolean to test if StringListEvent was called
        /// </summary>
        public bool StringListEventCalled { get; }

        #endregion
    }
}

