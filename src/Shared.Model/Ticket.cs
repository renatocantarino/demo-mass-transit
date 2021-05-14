﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Model
{
    public class Ticket
    {
        public string UserName { get; set; }
        public string Location { get; set; }
        public DateTime Booked { get; set; }
        public Guid Id { get; set; }

        public Ticket() => Id = Guid.NewGuid();
    }
}