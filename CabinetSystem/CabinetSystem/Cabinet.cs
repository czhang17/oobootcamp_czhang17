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
        public bool HasEmptyBox()
        {
            return true;
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
            return _dicTicketBag.ContainsKey(ticket) ? _dicTicketBag[ticket] : null;
        }
    }
}
