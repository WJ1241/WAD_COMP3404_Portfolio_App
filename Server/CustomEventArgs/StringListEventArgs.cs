using System;
using System.Collections.Generic;

namespace Server.CustomEventArgs
{
    /// <summary>
    /// Class which contains arguments related to an event involving an Image
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 11/03/22
    /// </summary>
    public class StringListEventArgs : EventArgs
    {
        #region FIELD VARIABLES

        // DECLARE an IList<string>, name it '_stringList':
        private IList<string> _stringList;

        #endregion


        #region PROPERTIES

        /// <summary>
        /// Property which allows read and write access to a string List
        /// </summary>
        public virtual IList<string> List
        {
            get
            {
                // RETURN value of _stringList:
                return _stringList;
            }
            set
            {
                // SET value of _stringList to incoming value:
                _stringList = value;
            }
        }

        #endregion
    }
}
