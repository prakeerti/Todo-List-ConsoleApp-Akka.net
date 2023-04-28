using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaPractice
{
    public class ToDoItem
    { 
        public string ToDoTask { get; set; }
        public ToDoItemStatus Status { get; set; }
        public Guid Id { get; set; }

        public ToDoItem()
        {

        }

        public ToDoItem(Guid guid, string TaskName, ToDoItemStatus status)
        {
            Id = guid;
            ToDoTask = TaskName;
            Status = status;
        }
    }
}
