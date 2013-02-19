namespace CabinetSystem1
{
    public class Cabinet
    {
        public bool HasEmptyBox()
        {
            return true;
        }

        public Ticket ReturnTicketIfEmptyBox()
        {
            if (this.HasEmptyBox())
            {
                Store();
                return new Ticket();
            }
                
            
            return null;
        }

        private void Store()
        {
            ;
        }
    }

    public class Ticket
    {
    }
}