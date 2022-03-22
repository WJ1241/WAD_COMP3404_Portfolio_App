using System;
using System.Drawing;

namespace Server.CustomEventArgs
{
    /// <summary>
    /// Class which contains arguments related to an event involving an Image
    /// Authors: William Smith, Declan Kerby-Collins
    /// Date: 02/03/22
    /// </summary>
    public class ImageEventArgs : EventArgs
    {
        #region FIELD VARIABLES

        // DECLARE an Image, name it '_img':
        private Image _img;

        #endregion


        #region PROPERTIES

        /// <summary>
        /// Property which allows read and write access to an Image
        /// </summary>
        public virtual Image Img
        {
            get
            {
                // RETURN value of _img:
                return _img;
            }
            set
            {
                // SET value of _img to incoming value:
                _img = value;
            }
        }

        #endregion
    }
}
