using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconA4.Data
{
    public class PersonSequencer
    {
        private static int personId;
        public static int nextPersonId()
        {           
            return personId++;
        }

        public static void reset()
        {
            personId = 0;
        }
    }
}
