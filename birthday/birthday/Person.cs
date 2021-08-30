using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public class Person
    {
        public DateTime Birthday { get; set; }

        // Leaving this as a list as it is common for someone to have more then two names
        public List<string> Names { get; set; } = new List<string>();
    }
}
