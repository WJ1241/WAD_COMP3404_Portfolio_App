using System.Drawing;

namespace TestGUI.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to be tested by allowing an Image reference to be read
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 03/03/22
    /// </summary>
    public interface IGetImageTest
    {
        #region PROPERTIES

        /// <summary>
        /// Property which allows only read access to an Image
        /// </summary>
        Image Img { get; }

        #endregion
    }
}
