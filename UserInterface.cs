using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaPractice
{
    public  class UserInterface
    {
        public static void DisplayServices()
        {
            ColorConsole.WriteLineCyan("---To Do Application---");
            ColorConsole.WriteLineCyan("1. View");
            ColorConsole.WriteLineCyan("2. Add");
            ColorConsole.WriteLineCyan("3. Update Text");
            ColorConsole.WriteLineCyan("4. Mark as done");
            ColorConsole.WriteLineCyan("5. Exit");
        }
    }
}
