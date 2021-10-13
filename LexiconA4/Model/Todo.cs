
using System;
using System.Collections.Generic;
using System.Text;
using static LexiconA4.Exceptions;
using static LexiconA4.Tools;

namespace LexiconA4.Model
{
    public class Todo
    {   
        private readonly int _todoID;
        private string _descripion;
        private bool _done;
        private Person _assignee;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="todoID"></param>
        /// <param name="descripion"></param>
        public Todo(int todoID, string descripion)
        {
            this._todoID = todoID;
            this._descripion = SafeString(descripion);
        }

        public int TodoID => _todoID;
    }
}
