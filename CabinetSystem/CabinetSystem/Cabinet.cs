using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CabinetSystemTest;

namespace CabinetSystem
{
    public class Cabinet
    {
        private Dictionary<Ticket, Bag> _dicTicketBag = new Dictionary<Ticket, Bag>();
        private int boxNumber;


        public Cabinet(int i)
        {
            boxNumber = i;
        }

        public Cabinet()
        {
            boxNumber = 10;
        }

        public bool HasEmptyBox()
        {
            return _dicTicketBag.Count() < boxNumber;
        }

        public Ticket Store(Bag aBag)
        {
            if (HasEmptyBox())
            {
                Ticket ticket = new Ticket();
                _dicTicketBag.Add(ticket,aBag);
                return ticket;

            }
            return null;
        }

        public Bag Pick(Ticket ticket)
        {
            if (_dicTicketBag.ContainsKey(ticket))
            {
                var bag = _dicTicketBag[ticket];
                _dicTicketBag.Remove(ticket);
                return bag;
            }
            else
            {
                return null;
            }
        }
    }
}
