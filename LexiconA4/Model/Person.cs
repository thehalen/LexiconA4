using System;
using static LexiconA4.Exceptions;
using static LexiconA4.Tools;

namespace LexiconA4.Model
{
    public class Person
    {
        private readonly int _personId;
        private readonly string _firstName, _lastName;

        public Person(int personId, string firstName, string lastName)
        {
            this._personId = personId;
            FirstName = firstName;
            LastName = lastName;
        }

        public int PersonId => _personId;
        public string FirstName
        {
            get => _firstName;
            init => _firstName = Tools.SafeString(value);
        }
        public string LastName
        {
            get => _lastName;
            init => _lastName = Tools.SafeString(value);
        }
    }
}
