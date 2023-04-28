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
    public class UpdateItemsChildActor: ReceiveActor
    {
        private readonly IDBOperations _dbOperations;

        public UpdateItemsChildActor()
        {
            _dbOperations = new DBOperations();

            Receive<MessageUpdateHandler>(message => _dbOperations.UpdateToDoItemInDB(message.guid, message.todoItem));

        }
    }
}
