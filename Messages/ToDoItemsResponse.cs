using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaPractice.Messages
{
    public class ToDoItemsResponse
    {
        public List<ToDoItem> Items = new List<ToDoItem>();
        public ToDoItemsResponse(List<ToDoItem> item)
        {
            Items = item;
        }
    }
}
