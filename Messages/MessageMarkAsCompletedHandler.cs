using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkkaPractice.Messages
{
    public class MessageMarkAsCompletedHandler
    {
        public Guid guid { get; }
        public MessageMarkAsCompletedHandler(Guid id)
        {
            guid = id;
        }
    }
}
