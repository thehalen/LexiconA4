using System;
using static LexiconA4.Exceptions;
using static LexiconA4.Tools;

namespace LexiconA4.Model
{
    public class Person
    {
        private readonly int _personId;
        private  string _firstName, _lastName;

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
            set => _firstName = Tools.SafeString(value);
        }
        public string LastName
        {
            get => _lastName;
            set => _lastName = Tools.SafeString(value);
        }
    }
}
