using System;

namespace Server.Exceptions
{
    /// <summary>
    /// Exception class used for testing if a string value is invalid
    /// Author: William Smith
    /// Date: 12/11/21
    /// </summary>
    public class InvalidStringException : Exception
    {
        /// <summary>
        /// Constructor for objects of InvalidStringException, calls base 'Exception' constructor to pass 'pMessage' value
        /// </summary>
        /// <param name="pMessage">string value used to display error message to user</param>
        public InvalidStringException(string pMessage) : base(pMessage)
        {
            
        }
    }
}
