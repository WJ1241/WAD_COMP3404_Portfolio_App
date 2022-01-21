using System;

namespace Server.Exceptions
{
    /// <summary>
    /// Exception class used for testing if an addressed variable/property has no value.
    /// Author: William Smith
    /// Date: 12/11/21
    /// </summary>
    public class NullValueException : Exception
    {
        /// <summary>
        /// Constructor for objects of NullValueException, calls base 'Exception' constructor to pass 'pMessage' value
        /// </summary>
        /// <param name="pMessage">string value used to display error message to user</param>
        public NullValueException(string pMessage) : base(pMessage)
        {

        }
    }
}
