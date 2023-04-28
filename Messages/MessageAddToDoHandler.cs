using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaPractice.Messages
{
    public class MessageAddToDoHandler
    {
        public ToDoItem toDo { get; private set; }
        
        public MessageAddToDoHandler(ToDoItem todo)
        {
            toDo = todo;
            
        }
    }
}
