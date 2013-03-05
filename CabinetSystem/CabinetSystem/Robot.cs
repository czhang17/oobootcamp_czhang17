using System;
using System.Collections.Generic;
using CabinetSystem;

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
    }
}