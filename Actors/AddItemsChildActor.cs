using Akka.Actor;
using AkkaPractice.DataBase;
using AkkaPractice.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaPractice.Actors
{
    public class AddItemsChildActor: ReceiveActor
    {
        private readonly IDBOperations _dbOperations;

        public AddItemsChildActor()
        {
            _dbOperations = new DBOperations();

            Receive<MessageAddToDoHandler>(message => _dbOperations.AddToDoInDB(message.toDo));

        }
    }
}
