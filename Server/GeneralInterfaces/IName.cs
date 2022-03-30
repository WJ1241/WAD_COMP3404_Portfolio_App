

namespace Server.GeneralInterfaces
{
    /// <summary>
    /// Interface which allows implementations to have a string identifier
    /// Author: William Smith
    /// Date: 11/02/22
    /// </summary>
    public interface IName
    {
        /// <summary>
        /// Property which allows read and write access to an implementation's name
        /// </summary>
        string Name { get; set; }
    }
}
