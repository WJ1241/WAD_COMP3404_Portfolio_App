using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Server.Exceptions;
using GUI.Logic.Interfaces;

namespace GUI.Logic
{
    /// <summary>
    /// Class which can Save files on a client's device
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
    /// Date: 02/02/22
    /// </summary>
    public class SaveLogic : ISaveImage
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of SaveLogic
        /// </summary>
        public SaveLogic()
        {
            // EMPTY CONSTRUCTOR
        }

        #endregion


        #region IMPLEMENTATION OF ISAVEIMAGE

        /// <summary>
        /// Saves Image, Gives user choice of where to store
        /// </summary>
        /// <param name="pImage"> Image currently displayed on screen </param>
        public void SaveImage(Image pImage)
        {
            // IF pImage DOES HAVE an active instance:
            if (pImage != null)
            {
                // DECLARE & INSTANTIATE a new SaveFileDialog, name it 'pSFD':
                using (SaveFileDialog pSFD = new SaveFileDialog())
                {
                    // SET InitialDirectory to FishAssets folder:
                    pSFD.InitialDirectory = Path.GetFullPath("..\\..\\..\\..\\Server\\Displayables\\FishAssets");

                    // SET title of Dialog to 'Save Your Image!'
                    pSFD.Title = "Save Your Image!";

                    // FILTER File Extensions to .PNG:
                    pSFD.Filter = "PNG Files (*.png)|*.png";

                    // IF User has clicked 'OK' on OpenFileDialog:
                    if (pSFD.ShowDialog() == DialogResult.OK)
                    {
                        // IF FileName IS NOT empty:
                        if (pSFD.FileName != "")
                        {
                            // DECLARE & ASSIGN a FileStream, name it '_fs', and give result value of pSFD.OpenFile():
                            FileStream _fs = (FileStream)pSFD.OpenFile();

                            // SAVE pImage to the User's device at chosen directory:
                            pImage.Save(_fs, System.Drawing.Imaging.ImageFormat.Png);

                            // CLOSE FileStream:
                            _fs.Close();
                        }
                    }
                }
            }
            // IF pImage DOES NOT HAVE an active instance:
            else
            {
                // THROW new FileNotSavedException, with corresponding message:
                throw new FileNotSavedException("ERROR: Requested Image to be saved does not exist in Program!");
            }
        }

        #endregion
    }
}
