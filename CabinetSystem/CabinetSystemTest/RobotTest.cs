using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetSystemTest
{
    /// <summary>
    /// Summary description for RobotTest
    /// </summary>
    [TestClass]
    public class RobotTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void should_return_true_given_cabinet_when_add_cabinet()
        {
            var robot = new Robot();
            var c1 = new Cabinet(2);
            Assert.IsTrue(robot.Add(c1));
            
        }
        [TestMethod]
        public void should_return_false_given_null_cabinet_when_add_cabinet()
        {
            var robot = new Robot();
            Assert.IsFalse(robot.Add(null));
        }

        [TestMethod]
        public void should_return_true_given_robot_with_empty_cabinet_when_check_availability()
        {
            var robot = new Robot();
            robot.Add(new Cabinet(50));
            Assert.IsTrue(robot.HasEmptyBox());
        }

        [TestMethod]
        public void should_return_false_given_null_cabinet_when_check_availability()
        {
            var robot = new Robot();
            Assert.IsFalse( robot.HasEmptyBox());
        }

        [TestMethod]
        public void should_store_bag_given_empty_cabinet()
        {
            var robot = new Robot();
            var cabinet = new Cabinet(50);

            robot.Add(cabinet);

            Bag aBag = new Bag();
            Ticket ticket = robot.Store(aBag);
            Assert.IsNotNull(ticket);
        }

    }
}
