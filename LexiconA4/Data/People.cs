using LexiconA4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconA4.Data
{
    public class People
    {
        private static Person[] people = new Person[0];

        public int Size()
        {
            return people.Length;
        } 

        public Person[] FindAll()
        {
            return people;
        }

        public Person FindById(int personId)
        {
            foreach (Person p in people)
            {
                if (p.PersonId==personId)
                {
                    return p;
                }
            }
            return null;
        }

        public Person AddGenericPerson()
        {
            Person person = new Person(PersonSequencer.nextPersonId(), "Hacke", "Hackspett");
            AddToArray(person);
            return person;
        }

        /// <summary>
        /// Adds a char to the first free slot in the guesses array
        /// </summary>
        /// <param name="ch"></param>
        static void AddToArray(Person person)
        {
            Array.Resize(ref people, people.Length + 1);
            people[people.Length-1] = person;
        }

        /// <summary>
        /// Removes a person from the array
        /// </summary>
        /// <param name=""></param>
        public void RemoveFromArray(Person person)
        {
            for (int i = 0; i < people.Length - 1; i++)
            {
                if (people[i] == person)
                {
                    people = people.Where((source, index) => index != i).ToArray();
                }
            }
        }


        public void Clear()
        {
            people = new Person[0];
        }
    }
}
