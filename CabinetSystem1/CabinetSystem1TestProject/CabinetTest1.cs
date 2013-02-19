using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CabinetSystem1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetSystem1TestProject
{
    /// <summary>
    /// Summary description for CabinetTest1
    /// </summary>
    [TestClass]
    public class CabinetTest1
    {
        public CabinetTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void should_has_empty_box_given_Cabinet()
        {
            var cabinet = new Cabinet();
            var hasEmptyBox = cabinet.HasEmptyBox();
            Assert.IsTrue(hasEmptyBox);
        }

        [TestMethod]
        public void should_return_ticket_if_empty_box()
        {
            var cabinet = new Cabinet();
            var ticket = cabinet.ReturnTicketIfEmptyBox();
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        public void can_pick_bag_by_ticket()
        {
            var cabinet = new Cabinet();
            var ticket = cabinet.ReturnTicketIfEmptyBox();
            var bag = cabinet.PickBagbyTicket(ticket);
            Assert.IsNotNull(bag);
        }
    }
}
