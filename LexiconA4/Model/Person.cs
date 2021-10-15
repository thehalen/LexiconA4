using System;
using static LexiconA4.Exceptions;
using static LexiconA4.Tools;

namespace LexiconA4.Model
{
    public class Person
    {
        private readonly int personId;
        private  string firstName, lastName;

        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            FirstName = firstName;
            LastName = lastName;
        }

        public int PersonId => personId;
        public string FirstName
        {
            get => firstName;
            set => firstName = Tools.SafeString(value);
        }
        public string LastName
        {
            get => lastName;
            set => lastName = Tools.SafeString(value);
        }
    }
}
