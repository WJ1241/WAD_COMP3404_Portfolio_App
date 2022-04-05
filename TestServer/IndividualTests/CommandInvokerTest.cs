using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server.Commands;
using Server.Commands.Interfaces;

namespace TestServer.IndividualTests
{
    /// <summary>
    /// Test Class which checks if CommandInvoker is behaving as expected
    /// Authors: William Smith, William Eardley & Declan Kerby-Collins
    /// Date: 02/03/22
    /// </summary>
    [TestClass]
    public class CommandInvokerTest
    {
        #region INVOKING ICOMMAND

        /// <summary>
        /// Checks if CommandInvoker calls 'Execute()' on an ICommand successfully
        /// </summary>
        [TestMethod]
        public void Call_Execute_On_ICommand()
        {
            #region ARRANGE

            // DECLARE & INSTANTIATE an ICommandInvoker as a new CommandInvoker(), name it 'cmdInvoker':
            ICommandInvoker cmdInvoker = new CommandInvoker();

            // DECLARE & INSTANTIATE a new Mock<ICommand>, name it 'mockCmd':
            Mock<ICommand> mockCmd = new Mock<ICommand>();

            // DECLARE & INITIALISE a bool, name it 'pass', set to true so test passes if no exception is thrown:
            bool pass = true;

            #endregion


            #region ACT

            // CALL InvokeCommand() on cmdInvoker, passing mockCmd as a parameter:
            cmdInvoker.InvokeCommand(mockCmd.Object);

            #endregion


            #region ASSERT

            // TRY checking if _mockCmd.ExecuteMethod() has been called:
            try
            {
                // VERIFY that mockCmd.ExecuteMethod() was called ONCE, to ensure the same behaviour isn't performed twice or more:
                mockCmd.Verify(mockCmd => mockCmd.ExecuteMethod(), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException)
            {
                // SET pass to false, so that test fails:
                pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed or failed depending on the value of pass:
                Assert.IsTrue(pass, "ERROR: CommandInvoker has not called ExecuteMethod() on _mockCmd!");
            }

            #endregion
        }

        #endregion
    }
}
