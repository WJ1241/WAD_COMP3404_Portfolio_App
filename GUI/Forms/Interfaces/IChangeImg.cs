using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Forms.Interfaces
{
    /// <summary>
    /// Interface which allows implementations to change a currently displayed image
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 13/03/22
    /// </summary>
    public interface IChangeImg
    {
        #region METHODS

        /// <summary>
        /// Changes currently displayed image to a desired image
        /// </summary>
        void ChangeImg();

        #endregion
    }
}
