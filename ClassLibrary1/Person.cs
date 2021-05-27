using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BDay { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
