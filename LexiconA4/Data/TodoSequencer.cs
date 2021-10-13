using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconA4.Data
{
    public class TodoSequencer
    {
        private static int TodoId;
        public static int nextTodoId()
        {
            return TodoId++;
        }

        public static void reset()
        {
            TodoId = 0;
        }
    }
}
