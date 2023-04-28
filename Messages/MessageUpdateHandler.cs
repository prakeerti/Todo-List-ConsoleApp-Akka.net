using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaPractice.Messages
{
    public class MessageUpdateHandler
    {
        public Guid guid { get; private set; }
        public string todoItem { get; private set; }

        public MessageUpdateHandler(string todo, Guid id)
        {
            todoItem = todo;
            guid = id;
        }
    }
}
