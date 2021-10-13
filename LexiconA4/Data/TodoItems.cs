﻿using LexiconA4.Model;
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
            AddToArray(ref todoArr, todo);
            return todo;
        }

        /// <summary>
        /// Adds a char to the first free slot in the guesses array
        /// </summary>
        /// <param name="ch"></param>
        public void AddToArray(ref Todo[] arr, Todo todo)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = todo;
        }


        public void Clear()
        {
            todoArr = new Todo[0];

        }


        /// <summary>
        /// Returns array with objects that has a matching done status.
        /// </summary>
        /// <param name="doneStatus"></param>
        /// <returns></returns>
        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] found = new Todo[0];
            foreach (Todo t in todoArr)
            {
                if (t.Done == doneStatus)
                {
                    AddToArray(ref found, t);
                }
            }
            return found;
        }


        /// <summary>
        /// Returns array with objects that has an assignee with a personId matching.
        /// </summary>
        public Todo[] FindByAssignee(int personId)
        {
            Todo[] found = new Todo[0];
            foreach (Todo t in todoArr)
            {
                if (t.Assignee.PersonId == personId)
                {
                    AddToArray(ref found, t);
                }
            }
            return found;
        }


        /// <summary>
        /// Returns array with objects that has sent in Person.
        /// </summary>
        /// <param name="assignee"></param>
        /// <returns></returns>
        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] found = new Todo[0];
            foreach (Todo t in todoArr)
            {
                if (t.Assignee == assignee)
                {
                    AddToArray(ref found, t);
                }
            }
            return found;
        }
         
        /// <summary>
        /// Returns an array of objects that does not have an assignee set.
        /// </summary>
        /// <returns></returns>
        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] found = new Todo[0];
            foreach (Todo t in todoArr)
            {
                if (t.Assignee == null)
                {
                    AddToArray(ref found, t);
                }
            }
            return found;
        }
    }
}

