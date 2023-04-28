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
    public class GetItemsChildActor: ReceiveActor
    {
        private readonly IDBOperations _dbOperations;

        public GetItemsChildActor()
        {

            _dbOperations = new DBOperations();

            Receive<MessageGetAllTHandler>(message =>
            {
                var items = _dbOperations.GetAllItemsInDB();
                var response = new ToDoItemsResponse(items);
                Sender.Tell(response);

            }
           );
            //to handle the todo response message 
            Receive<ToDoItemsResponse>(response =>
            {
                Console.WriteLine("Your Items:");
                foreach (var item in response.Items)
                {
                    Console.WriteLine(item);
                }
            });
        }
    }
}
