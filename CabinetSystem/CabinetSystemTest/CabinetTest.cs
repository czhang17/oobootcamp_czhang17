using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CabinetSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CabinetSystemTest
{
    [TestClass]
    public class CabinetTest
    {
        private int boxNumber =10 ;
        [TestMethod]
        public void should_has_empty_box_given_cabinet()
        {
            Cabinet cabinet = new Cabinet(boxNumber);
            Assert.IsTrue(cabinet.HasEmptyBox());
        }

        [TestMethod]
        public void should_return_ticket_given_empty_cabinet_when_store()
        {
            Bag aBag = new Bag();
            Cabinet cabinet = new Cabinet(boxNumber);

            Ticket ticket = cabinet.Store(aBag);
            Assert.IsNotNull(ticket);
        }

        [TestMethod]
        public void should_return_bag_given_valid_ticket_when_pick()
        {
            Bag aBag = new Bag();
            Cabinet cabinet = new Cabinet(boxNumber);

            Ticket ticket = cabinet.Store(aBag);
            Assert.AreEqual(aBag, cabinet.Pick(ticket));
        }

        [TestMethod]
        public void should_return_null_given_used_ticket_when_pick()
        {

            var cabinet = new Cabinet(boxNumber);
            Bag newbag = new Bag();
            Ticket ticket = cabinet.Store(newbag);
            cabinet.Pick(ticket);
            Assert.IsNull(cabinet.Pick(ticket));
        }

        [TestMethod]
        public void should_return_null_given_invalid_ticket_when_pick()
        {
            Cabinet cabinet = new Cabinet(boxNumber);

            Ticket ticket = new Ticket();
            Assert.IsNull(cabinet.Pick(ticket));
        }

        [TestMethod]
        [ExpectedException(typeof(NoEmptyBoxException))]
        public void should_return_null_given_no_empty_box_when_store()
        {
            var cabinet = new Cabinet(boxNumber);
            for (var i = 0; i < boxNumber; i++)
                cabinet.Store(new Bag());
            cabinet.Store(new Bag());
        }
    }


}

