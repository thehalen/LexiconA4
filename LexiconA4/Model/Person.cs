using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconA4.Model
{
    public class Person
    {
        private readonly int personId;
        private readonly string firstName, lastName;

        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            if (!String.IsNullOrWhiteSpace(firstName)) 
            {
                this.firstName = firstName;
            }
            else
            {
                throw new ArgumentIsNullOrWhiteSpaceException(nameof(firstName));
            }


            if (!String.IsNullOrWhiteSpace(lastName))
            {
                this.lastName = lastName;
            }
            else
            {
                throw new ArgumentIsNullOrWhiteSpaceException(nameof(lastName));
            }
        }
    }


}
