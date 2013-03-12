using System;
using System.Collections.Generic;
using System.Linq;
using CabinetSystem;
using CabinetSystemTest;

namespace CabinetSystem
{
    public class Robot
    {
        private List<Cabinet> _cabinets = new List<Cabinet>();

        public bool Add(Cabinet c1)
        {
            if (c1 == null) return false;
           
            _cabinets.Add(c1);
            return true;
        }

        public bool HasEmptyBox()
        {
            if (_cabinets.Count == 0) return false;

            return _cabinets.Any(x => x.HasEmptyBox());
        }

        public Ticket Store(Bag bag)
        {
            if (bag == null) throw new ArgumentException("Null bag is not allowed!");

            var emptyCabinet = _cabinets.FirstOrDefault(x => x.HasEmptyBox());

            return (emptyCabinet) == null ? null : emptyCabinet.Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return _cabinets.Select(cabinet => cabinet.Pick(ticket)).FirstOrDefault(bag => bag != null);
        }
    }
}