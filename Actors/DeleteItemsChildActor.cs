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
    public class DeleteItemsChildActor: ReceiveActor
    {
        private readonly IDBOperations _dbOperations;

        public DeleteItemsChildActor()
        {
            _dbOperations = new DBOperations();

            Receive<MessageMarkAsCompletedHandler>(message => _dbOperations.MarkAsCompleteInDB(message.guid));

        }
    }
}
