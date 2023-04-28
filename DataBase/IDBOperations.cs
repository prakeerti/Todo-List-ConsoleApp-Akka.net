using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaPractice.DataBase
{
    public interface IDBOperations
    {
        public List<ToDoItem> GetAllItemsInDB();

        public void AddToDoInDB(ToDoItem todoItem);

        public void UpdateToDoItemInDB(Guid id, string todoItem);

        public void MarkAsCompleteInDB(Guid id);
    }
}
