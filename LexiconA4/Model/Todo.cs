
using System;
using System.Collections.Generic;
using System.Text;

namespace LexiconA4.Model
{
    public class Todo
    {
        private readonly int todoID;
        private string descripion;
        private bool done;
        private Person assignee;

        public Todo(int todoID, string descripion)
        {
            this.todoID = todoID;
            this.descripion = descripion ?? throw new ArgumentNullException(nameof(descripion));
        }
    }
}
