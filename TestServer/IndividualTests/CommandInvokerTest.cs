using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Server.Commands;

namespace TestServer.IndividualTests
{
    /// <summary>
    /// Test Class which checks if CommandInvoker is behaving as expected
    /// Authors: William Smith, Declan Kerby-Collins & William Eardley
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

            // DECLARE & INSTANTIATE a new CommandInvoker, name it '_cmdInvoker':
            ICommandInvoker _cmdInvoker = new CommandInvoker();

            // DECLARE & INSTANTIATE a new Mock<ICommand>, name it '_mockCmd':
            Mock<ICommand> _mockCmd = new Mock<ICommand>();

            // DECLARE & INITIALISE a bool, name it '_pass', set to true so test passes if no exception is thrown:
            bool _pass = true;

            #endregion


            #region ACT

            // CALL InvokeCommand() on _cmdInvoker, passing _mockCmd as a parameter:
            _cmdInvoker.InvokeCommand(_mockCmd.Object);

            #endregion


            #region ASSERT

            // TRY checking if _mockCmd.ExecuteMethod() has been called:
            try
            {
                // VERIFY that _mockCmd.ExecuteMethod() was called ONCE, to ensure the same behaviour isn't performed twice or more:
                _mockCmd.Verify(_mockCmd => _mockCmd.ExecuteMethod(), Times.Once);
            }
            // CATCH MockException from Verify():
            catch (MockException e)
            {
                // SET _pass to false, so that test fails:
                _pass = false;
            }
            // FINALISE try and catch block with test pass/fail:
            finally
            {
                // ASSERT if test has passed or failed depending on the value of _pass:
                Assert.IsTrue(_pass, "ERROR: CommandInvoker has not called ExecuteMethod() on _mockCmd!");
            }

            #endregion
        }

        #endregion
    }
}
