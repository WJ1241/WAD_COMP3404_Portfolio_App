using System;

namespace Server.Exceptions
{
    /// <summary>
    /// Exception class used for testing if a File name has already been stored in the program
    /// Author: William Smith
    /// Date: 26/11/21
    /// </summary>
    public class FileAlreadyStoredException : Exception
    {
        /// <summary>
        /// Constructor for objects of FileAlreadyStoredException, calls base 'Exception' constructor to pass 'pMessage' value
        /// </summary>
        /// <param name="pMessage">string value used to display error message to user</param>
        public FileAlreadyStoredException(string pMessage) : base(pMessage)
        {

        }
    }
}
