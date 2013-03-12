using System;
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

        private static Robot SetupTwoCabinetRobot()
        {
            Robot robot = new Robot();
            robot.Add(new Cabinet(50));
            robot.Add(new Cabinet(50));

            return robot;
        }

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
            var robot = SetupTwoCabinetRobot();

            Bag aBag = new Bag();
            Ticket ticket = robot.Store(aBag);
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        public void should_not_store_bag_given_full_cabinet()
        {
            var robot = new Robot();
            var cabinet = new Cabinet(1);
            robot.Add(cabinet);
            var bagA = new Bag();
            robot.Store(bagA);

            var bagB = new Bag();
            Ticket ticket = robot.Store(bagB);
            Assert.IsNull(ticket);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void should_throw_argument_exception_given_null_when_store_bag()
        {
            var robot = SetupTwoCabinetRobot();
            robot.Store(null);
        }



        [TestMethod]
        public void should_store_bags_sequentially_given_bags()
        {
            var robot = new Robot();
            var cabinet1 = new Cabinet(1);
            var cabinet2 = new Cabinet(1);

            robot.Add(cabinet1);
            robot.Add(cabinet2);

            var bag1 = new Bag();
            var bag2 = new Bag();

            robot.Store(bag1);
            Assert.IsFalse(cabinet1.HasEmptyBox());
            Assert.IsTrue(cabinet2.HasEmptyBox());

            robot.Store(bag2);
            Assert.IsFalse(cabinet1.HasEmptyBox());
            Assert.IsFalse(cabinet2.HasEmptyBox());
        }

        [TestMethod]
        public void should_return_bag_given_valid_ticket()
        {
            var robot = SetupTwoCabinetRobot();

            Bag bagToStore = new Bag();
            Ticket ticket = robot.Store(bagToStore);
            Bag bagPicked = robot.Pick(ticket);

            Assert.AreEqual(bagToStore, bagPicked);
        }
    }
}
