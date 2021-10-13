
using System;
using System.Collections.Generic;
using System.Text;
using static LexiconA4.Exceptions;
using static LexiconA4.Tools;

namespace LexiconA4.Model
{
    public class Todo
    {   
        private readonly int todoID;
        private string descripion;
        private bool done;
        private Person assignee;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="todoID"></param>
        /// <param name="descripion"></param>
        public Todo(int todoID, string descripion)
        {
            this.todoID = todoID;
            this.descripion = SafeString(descripion);
        }

        public int TodoID => todoID;

        public bool Done { get => done; set => done = value; }
        public Person Assignee { get => assignee; set => assignee = value; }
        public string Descripion { get => descripion; set => descripion = value; }
    }
}
