using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabinetSystemTest;

namespace CabinetSystem
{
    public class NoEmptyBoxException : ApplicationException
    {
    }

    public class Cabinet
    {
        private Dictionary<Ticket, Bag> _dicTicketBag = new Dictionary<Ticket, Bag>();
        private int boxNumber;


        public Cabinet(int i)
        {
            boxNumber = i;
        }

        public bool HasEmptyBox()
        {
            return _dicTicketBag.Count() < boxNumber;
        }

        public Ticket Store(Bag aBag)
        {
            if (!HasEmptyBox())
            {
                throw new NoEmptyBoxException();
            }

            var ticket = new Ticket();
            _dicTicketBag.Add(ticket,aBag);
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if (!_dicTicketBag.ContainsKey(ticket))
            {
                return null;
            }
           
            var bag = _dicTicketBag[ticket];
            _dicTicketBag.Remove(ticket);
            return bag;
        }
    }
}
