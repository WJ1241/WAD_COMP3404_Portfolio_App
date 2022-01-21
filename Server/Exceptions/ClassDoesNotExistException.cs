using System;

namespace Server.Exceptions
{
    /// <summary>
    /// Exception class used for testing if a Class Does Not Exist in the program
    /// Author: William Smith
    /// Date: 26/11/21
    /// </summary>
    public class ClassDoesNotExistException : Exception
    {
        /// <summary>
        /// Constructor for objects of ClassDoesNotExistException, calls base 'Exception' constructor to pass 'pMessage' value
        /// </summary>
        /// <param name="pMessage">string value used to display error message to user</param>
        public ClassDoesNotExistException(string pMessage) : base(pMessage)
        {

        }
    }
}
