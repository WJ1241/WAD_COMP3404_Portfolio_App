using System;

namespace Server.Exceptions
{
    /// <summary>
    /// Exception class used for testing if a File has not been saved correctly
    /// Author: William Smith
    /// Date: 21/11/21
    /// </summary>
    public class FileNotSavedException : Exception
    {
        /// <summary>
        /// Constructor for objects of FileNotSavedException, calls base 'Exception' constructor to pass 'pMessage' value
        /// </summary>
        /// <param name="pMessage">string value used to display error message to user</param>
        public FileNotSavedException(string pMessage) : base(pMessage)
        {

        }
    }
}
