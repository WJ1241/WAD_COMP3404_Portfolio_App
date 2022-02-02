using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GUI.Logic
{
    /// <summary>
    /// Class which can Open files on a client's device
    /// Authors: William Smith, 'Hassan', Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    /// <REFERENCE> Hassan (2014) How to get file path from OpenFileDialog and FolderBrowserDialog? Available at: https://stackoverflow.com/questions/24449988/how-to-get-file-path-from-openfiledialog-and-folderbrowserdialog. (Accessed: 26 November 2021) </REFERENCE>
    public class OpenLogic : IOpenImage
    {
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
        public IList<String> OpenImage()
        {
            // DECLARE & INSTANTIATE a temporary IList<String>, name it '_tempList', holds file paths collected from OpenFileDialog:
            IList<String> _tempList = new List<String>();

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
                        // ADD pString to _tempList:
                        _tempList.Add(Path.GetFullPath(pString));
                    }
                }
            }

            // RETURN _tempList:
            return _tempList;
        }

        #endregion
    }
}
