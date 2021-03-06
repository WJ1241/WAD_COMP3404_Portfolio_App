using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using GUI.Logic.Interfaces;
using Server.Exceptions;
using Server.InitialisingInterfaces;

namespace GUI.Logic
{
    /// <summary>
    /// Class which can Open files on a client's device
    /// Authors: William Smith, Declan Kerby-Collins, William Eardley & 'Hassan'
    /// Date: 12/03/22
    /// </summary>
    /// <REFERENCE> Hassan (2014) How to get file path from OpenFileDialog and FolderBrowserDialog? Available at: https://stackoverflow.com/questions/24449988/how-to-get-file-path-from-openfiledialog-and-folderbrowserdialog. (Accessed: 26 November 2021) </REFERENCE>
    public class OpenLogic : IOpenImage, IInitialiseParam<IList<string>>
    {
        #region FIELD VARIABLES

        // DECLARE an IList<string>, name it '_fpList':
        private IList<string> _fpList;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of OpenLogic
        /// </summary>
        public OpenLogic()
        {
            // EMPTY CONSTRUCTOR
        }

        #endregion


        #region IMPLEMENTATION OF IOPENIMAGE

        /// <summary>
        /// Open Image, User is directed to App's Displayable folder
        /// </summary>
        /// <returns> List of File Names </returns>
        /// <CITATION> (Hassan, 2014) </CITATION>
        public IList<string> OpenImage()
        {
            // CLEAR _fpList so that there are no old file paths no longer required:
            _fpList.Clear();

            // DECLARE & INSTANTIATE a new OpenFileDialog, name it 'pOFD':
            using (OpenFileDialog pOFD = new OpenFileDialog())
            {
                // SET InitialDirectory to FishAssets folder:
                pOFD.InitialDirectory = Path.GetFullPath("..\\..\\..\\..\\Server\\Displayables\\FishAssets");

                // SET title of Dialog to 'Load Your Image!'
                pOFD.Title = "Load Your Image!";

                // SET Multiselect Property to true:
                pOFD.Multiselect = true;

                // FILTER File Extensions to .PNG:
                pOFD.Filter = "PNG Files (*.png)|*.png";

                // IF User has clicked 'OK' on OpenFileDialog:
                if (pOFD.ShowDialog() == DialogResult.OK)
                {
                    // FOREACH String in selected FileNames array:
                    foreach (String pString in pOFD.FileNames)
                    {
                        // ADD pString to _fpList:
                        _fpList.Add(Path.GetFullPath(pString));
                    }
                }
            }

            // RETURN value of _fpList:
            return _fpList;
        }

        #endregion


        #region IMPLEMENTATION OF IINITIALISEPARAM<ILIST<STRING>>

        /// <summary>
        /// Initialises an object with an IList<string> object 
        /// </summary>
        /// <param name="pStringList"> IList<string> object </param>
        public void Initialise(IList<string> pStringList)
        {
            // IF pStringList DOES HAVE an active instance:
            if (pStringList != null)
            {
                // INITIALISE _fpList with reference to pStringList:
                _fpList = pStringList;
            }
            // IF pStringList DOES NOT HAVE an active instance:
            else
            {
                // THROW a new NullInstanceException(), with corresponding message:
                throw new NullInstanceException("ERROR: pStringList does not have an active instance!");
            }
        }

        #endregion
    }
}
