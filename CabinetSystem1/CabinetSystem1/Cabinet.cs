using System.Collections.Generic;
namespace CabinetSystem1
{
    public class Cabinet
    {
        private Dictionary<Ticket, Bag> Bags = new Dictionary<Ticket, Bag>();

        public bool HasEmptyBox()
        {
            return true;
        }

        public Ticket ReturnTicketIfEmptyBox()
        {
            return Store(new Bag());
        }

        private Ticket Store(Bag bag)
        {   
            Ticket ticket = new Ticket();
            Bags.Add(ticket, bag);
            return ticket;
        }

        public Bag PickBagbyTicket(Ticket ticket)
        {
            return Bags[ticket];
        }
    }
}
