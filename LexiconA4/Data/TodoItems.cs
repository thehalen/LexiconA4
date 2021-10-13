using LexiconA4.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconA4.Data
{
    public class TodoItems
    {
        private static Todo[] todoArr = new Todo[0];

        public int Size()
        {
            return todoArr.Length;
        }

        public Todo[] FindAll()
        {
            return todoArr;
        }

        public Todo FindById(int todoId)
        {
            foreach (Todo t in todoArr)
            {
                if (t.TodoID == todoId)
                {
                    return t;
                }
            }
            return null;
        }

        public Todo AddGenericTodo()
        {
            Todo todo = new Todo(TodoSequencer.nextTodoId(), "Become 1337");
            AddToArray(todo);
            return todo;
        }

        /// <summary>
        /// Adds a char to the first free slot in the guesses array
        /// </summary>
        /// <param name="ch"></param>
        static void AddToArray(Todo todo)
        {
            Array.Resize(ref todoArr, todoArr.Length + 1);
            todoArr[todoArr.Length - 1] = todo;
        }


        public void Clear()
        {
            todoArr = new Todo[0];
        }
    }
}

