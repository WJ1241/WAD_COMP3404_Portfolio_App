using System;

namespace App.Services
{
    /// <summary>
    /// Static Class which trims Generic Arity information to allow tidier naming and easier addressing
    /// Author: William Smith, 'LukeH', Declan Kerby-Collins & William Eardley
    /// Date: 07/02/22
    /// </summary>
    /// <REFERENCE> LukeH (2010) C# Get Generic Type Name. Available at: https://stackoverflow.com/questions/4185521/c-sharp-get-generic-type-name. (Accessed: 4 February 2022) </REFERENCE>
    public static class GenericTypeNameTrimmer
    {
        #region METHODS

        /// <summary>
        /// Trims ONE generic from a type name so that addressing becomes easier
        /// </summary>
        /// <param name="pType"> Type including Generic parameters </param>
        /// <returns> Trimmed string name </returns>
        /// <CITATION> LukeH (2010) </CITATION>
        public static string TrimOneGeneric(Type pType)
        {
            // IF pType.Name contains generic arity information and DOES NOT contain "Proxy":
            // Proxy is used within Moq as it does not specify Generic info:
            if (pType.Name.Contains("`") && !pType.Name.Contains("Proxy"))
            {
                // RETURN a trimmed string to remove generic info for easier addressing:
                return pType.Name.Remove(pType.Name.IndexOf("`")) + "<" + pType.GetGenericArguments()[0].Name + ">";
            }
            // IF pType.Name contains generic arity information and "Proxy":
            else
            {
                // RETURN pType.Name if condition was not met:
                // (Moq Testing throws an exception for prior logic)
                return pType.Name;
            }
        }

        /// <summary>
        /// Trims TWO generics from a type name so that addressing becomes easier
        /// </summary>
        /// <param name="pType"> Type including Generic parameters </param>
        /// <returns> Trimmed string name </returns>
        /// <CITATION> LukeH (2010) </CITATION>
        public static string TrimTwoGeneric(Type pType)
        {
            // RETURN a trimmed string to remove generic info for easier addressing:
            return pType.Name.Remove(pType.Name.IndexOf("`")) + "<" + pType.GetGenericArguments()[0].Name + ", " + pType.GetGenericArguments()[1].Name + ">";
        }

        #endregion
    }
}
