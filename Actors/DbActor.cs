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
    public class DbActor: ReceiveActor
    {
        public DbActor()
        {

            Console.WriteLine("Creating DB Actor");


            Context.ActorOf(Props.Create<AddItemsChildActor>(), "AddItemsChildActor");
            
            /*IActorRef child1=*/ Context.ActorOf(Props.Create<GetItemsChildActor>(), "GetAllItemsChildActor");
            /*var path = child1.Path.ToString();
            Console.WriteLine(path);*/
            Context.ActorOf(Props.Create<UpdateItemsChildActor>(), "UpdateItemsChildActor");
            Context.ActorOf(Props.Create<DeleteItemsChildActor>(), "DeleteItemsChildActor");

        }

        #region LifeCycle Hooks
        protected override void PreStart()
        {
            ColorConsole.WriteLineGreen("Actor Starting...");
        }

        protected override void PostStop()
        {
            ColorConsole.WriteLineGreen("Actor Commencing Shutdown");
        }

        protected override void PreRestart(Exception reason, object message)
        {
            ColorConsole.WriteLineGreen("Actor Restarting...");
            ColorConsole.WriteLineGreen("Exception:\n"+ reason);
            base.PreRestart(reason, message);
        }

        protected override void PostRestart(Exception reason)
        {
            ColorConsole.WriteLineGreen("Actor Post-Restarting...");
            ColorConsole.WriteLineGreen("Reason:\n" + reason);
            base.PostRestart(reason);
        }

        #endregion
    }
}
