using Akka.Actor;
using AkkaPractice.Actors;
using AkkaPractice.DataBase;
using AkkaPractice.Messages;

namespace AkkaPractice
{
    public class Program
    {
        private static ActorSystem TodoListActorSystem;

        static void Main(string[] args)
        {
            
            TodoListActorSystem = ActorSystem.Create("TodoListActorSystem");
            ColorConsole.WriteLineGreen("Actor System Created...");


            Props DbActorProps = Props.Create<DbActor>();
            IActorRef DbActorReference = TodoListActorSystem.ActorOf(DbActorProps, "DbActor");
            ColorConsole.WriteLineGreen("Parent Actor Created...");

            var flag = true;
            while (flag) 
            {
                UserInterface.DisplayServices();
                ColorConsole.WriteLineYellow("Select from the above services:");

                if (!int.TryParse(Console.ReadLine(), out int inputValue))
                    continue;
                Console.WriteLine((ToDoServiceChoice)inputValue);

                switch ((ToDoServiceChoice)inputValue)
                {
                    case ToDoServiceChoice.view:
                        ColorConsole.WriteLineYellow("View All My Items");


                        var itemResponse = TodoListActorSystem.ActorSelection("akka://TodoListActorSystem/user/DbActor/GetAllItemsChildActor").Ask<ToDoItemsResponse>(new MessageGetAllTHandler()).Result;
                        List<ToDoItem> list = itemResponse.Items;

                        foreach (var item in itemResponse.Items)
                        {
                            //Console.WriteLine(item.ToDoTask);
                            ColorConsole.WriteLineMagenta(item.ToDoTask + "   " + item.Id+ "   " + item.Status);
                        }
                        break;

                    case ToDoServiceChoice.add:
                        ColorConsole.WriteLineYellow("Add an Item");
                        var userItemInput= Console.ReadLine();
                        var addMessage = new MessageAddToDoHandler(new ToDoItem { Id = Guid.NewGuid(), ToDoTask = userItemInput , Status = ToDoItemStatus.Pending });
                        TodoListActorSystem.ActorSelection("akka://TodoListActorSystem/user/DbActor/AddItemsChildActor").Tell(addMessage);

                        
                         
                        break;

                    case ToDoServiceChoice.update:
                        ColorConsole.WriteLineYellow("Update your Item");
                        ColorConsole.WriteLineMagenta("Please enter the id of the Item you want to update:");
                        string idInput = Console.ReadLine();
                        Guid guid = Guid.Parse(idInput);
                        ColorConsole.WriteLineMagenta("enter the item to replace:");
                        string nameInput = Console.ReadLine();
                        var updateMessage = new MessageUpdateHandler(nameInput, guid);
                        TodoListActorSystem.ActorSelection("akka://TodoListActorSystem/user/DbActor/UpdateItemsChildActor").Tell(updateMessage);
                        break;

                    case ToDoServiceChoice.markcompleted:
                        ColorConsole.WriteLineYellow("Mark your Completed Items");
                        ColorConsole.WriteLineMagenta("enter the id:");
                        string IdInput = Console.ReadLine();
                        Guid id = Guid.Parse(IdInput);
                        var markCompleted = new MessageMarkAsCompletedHandler(id);
                        TodoListActorSystem.ActorSelection("akka://TodoListActorSystem/user/DbActor/DeleteItemsChildActor").Tell(markCompleted);
                        break;

                    case ToDoServiceChoice.exit:
                        ColorConsole.WriteLineYellow("Exiting Application");
                        flag= false;
                        break;

                    default:
                        ColorConsole.WriteLineYellow("You have Given an Invalid Input");
                        break;
                }

            }

            Console.WriteLine("Press Any Key To Shutdown Actor");
            Console.ReadKey();

            TodoListActorSystem.Terminate();               
        }
    }
}